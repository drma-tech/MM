using FluentValidation;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using MM.API.Core.Auth;
using MM.Shared.Core.Types;
using MM.Shared.Models.Auth;
using MM.Shared.Models.Job;
using MM.Shared.Models.Profile;
using MM.Shared.Models.Profile.Core;
using MM.Shared.Models.Safety;
using System.Text;
using System.Text.Json;

namespace MM.API.Functions.Auth;

public class PrincipalFunction(CosmosMainRepository repo, CosmosCacheRepository repoCache, CosmosSafetyRepository repoSafety, StorageHelper storageHelper,
    CosmosProfileOffRepository repoOff, CosmosProfileOnRepository repoOn, CosmosTrashRepository repoTrash, CosmosJobRepository repoJob, IHttpClientFactory factory)
{
    [Function("PrincipalGet")]
    public async Task<HttpResponseData?> PrincipalGet(
        [HttpTrigger(AuthorizationLevel.Anonymous, Method.Get, Route = "principal/get")] HttpRequestData req, CancellationToken cancellationToken)
    {
        var userId = await req.GetUserIdAsync();

        var model = await repo.ReadItemAsync<AuthPrincipal>(new MainIdentity(MainType.Principal, userId), cancellationToken);

        return await req.CreateResponse(model, TtlCache.OneHour, cancellationToken);
    }

    [Function("PrincipalAdd")]
    public async Task<AuthPrincipal?> PrincipalAdd(
        [HttpTrigger(AuthorizationLevel.Anonymous, Method.Post, Route = "principal/add")] HttpRequestData req, CancellationToken cancellationToken)
    {
        //note: its called once per user (first access)

        var userId = await req.GetUserIdAsync();
        var body = await req.GetBody<AuthPrincipal>(cancellationToken);
        var platform = req.GetQueryParameters()["platform"];
        var country = req.GetQueryParameters()["country"];

        await req.ValidateUser(body.UserId, cancellationToken);

        var ip = req.GetUserIP(includePort: false) ?? throw new UnhandledException("Failed to retrieve IP");

        foreach (var item in body.Events.Where(w => w.Ip.Empty()))
        {
            item.Ip = ip;
        }

        var job7 = new GoPublicModel(userId, DateTimeOffset.UtcNow.AddDays(7))
        {
            Email = body.Email,
        };

        await repoJob.UpsertItemAsync(job7);

        var job30 = new GoPublicModel(userId, DateTimeOffset.UtcNow.AddDays(30))
        {
            Email = body.Email,
        };

        await repoJob.UpsertItemAsync(job30);

        var zepto = new ZeptoMailClient(factory, ApiStartup.Configurations.ZeptoMail!.JobApiKey!);
        if (body.Email.NotEmpty()) _ = zepto.SendWelcomeEmail(body.Email, userId, cancellationToken);

        var principal = new AuthPrincipal(userId)
        {
            DisplayName = body.DisplayName,
            Email = body.Email,
            Events = body.Events,
        };

        principal = await repo.CreateItemAsync(principal);

        if (platform.NotEmpty())
        {
            var newLogin = new AuthLogin(userId)
            {
                UserId = userId,
                Accesses = new HashSet<Access> { new() { Date = DateTimeOffset.UtcNow, Platform = platform, Ip = ip, Country = country } },
            };

            await repo.CreateItemAsync(newLogin);
        }

        return principal;
    }

    [Function("PrincipalEvent")]
    public async Task<AuthPrincipal> PrincipalEvent(
       [HttpTrigger(AuthorizationLevel.Anonymous, Method.Post, Route = "principal/event")] HttpRequestData req, CancellationToken cancellationToken)
    {
        var userId = await req.GetUserIdAsync();
        var ip = req.GetUserIP(includePort: true);

        var principal = await repo.ReadItemAsync<AuthPrincipal>(new MainIdentity(MainType.Principal, userId), cancellationToken) ?? throw new UnhandledException("Client null");

        var app = req.GetQueryParameters()["app"];
        var msg = req.GetQueryParameters()["msg"];

        principal.Events.Add(new Event(app, msg, ip));

        return await repo.UpsertItemAsync(principal);
    }

    [Function("PrincipalRemove")]
    public async Task PrincipalRemove(
        [HttpTrigger(AuthorizationLevel.Anonymous, Method.Delete, Route = "principal/remove")] HttpRequestData req, CancellationToken cancellationToken)
    {
        var userId = await req.GetUserIdAsync();

        var myPrincipal = await repo.ReadItemAsync<AuthPrincipal>(new MainIdentity(MainType.Principal, userId), cancellationToken);
        if (myPrincipal != null)
        {
            await repoTrash.UpsertItemAsync(myPrincipal);
            await repo.DeleteItemAsync<AuthPrincipal>(new MainIdentity(MainType.Principal, userId));
        }

        var myLogins = await repo.ReadItemAsync<AuthLogin>(new MainIdentity(MainType.Login, userId), cancellationToken);
        if (myLogins != null)
        {
            await repoTrash.UpsertItemAsync(myLogins);
            await repo.DeleteItemAsync<AuthLogin>(new MainIdentity(MainType.Login, userId));
        }

        var myProfileOff = await repoOff.ReadItemAsync<ProfileModel>(new ProfileIdentity(userId), cancellationToken);
        if (myProfileOff != null)
        {
            if (myProfileOff.Gallery?.FaceId != null) await storageHelper.DeletePhoto(ImageHelper.PhotoType.Face, myProfileOff.Gallery.FaceId, cancellationToken);
            if (myProfileOff.Gallery?.BodyId != null) await storageHelper.DeletePhoto(ImageHelper.PhotoType.Body, myProfileOff.Gallery.BodyId, cancellationToken);

            await repoOff.DeleteItemAsync<ProfileModel>(new ProfileIdentity(userId));
        }

        var myProfileOn = await repoOn.ReadItemAsync<ProfileModel>(new ProfileIdentity(userId), cancellationToken);
        if (myProfileOn != null)
        {
            if (myProfileOn.Gallery?.FaceId != null) await storageHelper.DeletePhoto(ImageHelper.PhotoType.Face, myProfileOn.Gallery.FaceId, cancellationToken);
            if (myProfileOn.Gallery?.BodyId != null) await storageHelper.DeletePhoto(ImageHelper.PhotoType.Body, myProfileOn.Gallery.BodyId, cancellationToken);

            await repoOn.DeleteItemAsync<ProfileModel>(new ProfileIdentity(userId));
        }

        await repo.DeleteItemAsync<FilterModel>(new MainIdentity(MainType.Filter, userId));
        await repo.DeleteItemAsync<SettingModel>(new MainIdentity(MainType.Setting, userId));
        await repo.DeleteItemAsync<MySuggestionsModel>(new MainIdentity(MainType.Suggestions, userId));
        await repo.DeleteItemAsync<MyLikesModel>(new MainIdentity(MainType.Likes, userId));
        await repo.DeleteItemAsync<MyMatchesModel>(new MainIdentity(MainType.Matches, userId));

        //todo: interactions belongs to two users. decide what to do.
        //var myInteractions = await repo.Get<InteractionModel>(DocumentType.Interaction, userId, cancellationToken);
        //await repo.Delete(myInteractions, cancellationToken);

        await repo.DeleteItemAsync<ValidationModel>(new MainIdentity(MainType.Validation, userId));

        //delete didit data if exists
        var safety = await repoSafety.ReadItemAsync<SafetyModel>(new SafetyIdentity(userId), cancellationToken);
        if (safety != null)
        {
            using var http = factory.CreateClient();

            //todo: delete only after 6/12 months
            if (safety.Id.NotEmpty())
            {
                var userUrl = "https://verification.didit.me/v3/users/delete/";
                var payload = new
                {
                    vendor_data_list = new[] { safety.Id },
                };

                using var userRequest = new HttpRequestMessage(HttpMethod.Post, userUrl);

                userRequest.Headers.Add("x-api-key", ApiStartup.Configurations.Didit?.ApiKey);
                userRequest.Content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

                await http.SendAsync(userRequest, cancellationToken);
            }
        }
    }

    [Function("PrincipalPublicMode")]
    public async Task<AuthPrincipal?> PrincipalPublicMode(
     [HttpTrigger(AuthorizationLevel.Anonymous, Method.Post, Route = "principal/public")] HttpRequestData req, CancellationToken cancellationToken)
    {
        var userId = await req.GetUserIdAsync();

        var profile = await repoOff.ReadItemAsync<ProfileModel>(new ProfileIdentity(userId), cancellationToken) ?? throw new NotificationException("profile not found");
        var ProfileValidator = new ProfileValidation();
        var ProfileValid = (await ProfileValidator.ValidateAsync(profile, options => options.IncludeAllRuleSets(), cancellationToken)).IsValid;

        if (profile.MaritalStatus == MaritalStatus.Married || profile.MaritalStatus == MaritalStatus.CommonLawCohabiting)
        {
            throw new NotificationException(
                "You cannot make your profile public while in a committed relationship. Once your status changes, you can activate it."
            );
        }

        var filter = await repo.ReadItemAsync<FilterModel>(new MainIdentity(MainType.Filter, userId), cancellationToken) ?? throw new NotificationException("filter not found");
        var FilterValidator = new FilterValidation();
        var FilterValid = filter != null && (await FilterValidator.ValidateAsync(filter, cancellationToken)).IsValid;

        var setting = await repo.ReadItemAsync<SettingModel>(new MainIdentity(MainType.Setting, userId), cancellationToken) ?? throw new NotificationException("setting not found");
        var SettingValid = setting != null;

        var PhotoValidator = new PhotoValidation();
        var GalleryValid = profile.Gallery != null && (await PhotoValidator.ValidateAsync(profile.Gallery, cancellationToken)).IsValid;

        var validation = await repo.ReadItemAsync<ValidationModel>(new MainIdentity(MainType.Validation, userId), cancellationToken) ?? throw new NotificationException("validation not found");
        var ValidationsValid = validation != null && validation.Gallery;

        if (!ProfileValid || !FilterValid || !SettingValid || !GalleryValid || !ValidationsValid)
        {
            throw new NotificationException("Please complete all steps before making your profile public.");
        }

        await repoOn.UpsertItemAsync(profile);
        await repoOff.DeleteItemAsync<ProfileModel>(new ProfileIdentity(profile.Id));

        var principal = await repo.ReadItemAsync<AuthPrincipal>(new MainIdentity(MainType.Principal, userId), cancellationToken) ?? throw new UnhandledException("AuthPrincipal is null");
        principal.PublicProfile = true;

        return await repo.UpsertItemAsync(principal);
    }

    [Function("PrincipalPrivateMode")]
    public async Task<AuthPrincipal?> PrincipalPrivateMode(
        [HttpTrigger(AuthorizationLevel.Anonymous, Method.Post, Route = "principal/private")] HttpRequestData req, CancellationToken cancellationToken)
    {
        var userId = await req.GetUserIdAsync();

        var profile = await repoOn.ReadItemAsync<ProfileModel>(new ProfileIdentity(userId), cancellationToken) ?? throw new NotificationException("profile not found");
        await repoOff.UpsertItemAsync(profile);
        await repoOn.DeleteItemAsync<ProfileModel>(new ProfileIdentity(userId));

        var principal = await repo.ReadItemAsync<AuthPrincipal>(new MainIdentity(MainType.Principal, userId), cancellationToken) ?? throw new UnhandledException("AuthPrincipal is null");
        principal.PublicProfile = false;

        return await repo.UpsertItemAsync(principal);
    }
}