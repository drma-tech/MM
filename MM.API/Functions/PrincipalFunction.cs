using FluentValidation;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using MM.API.Core.Auth;
using MM.Shared.Models.Auth;
using MM.Shared.Models.Blocked;
using MM.Shared.Models.Profile;
using MM.Shared.Models.Profile.Core;

namespace MM.API.Functions;

public class PrincipalFunction(CosmosRepository repo, CosmosCacheRepository repoCache, CosmosProfileOffRepository repoOff, CosmosProfileOnRepository repoOn)
{
    [Function("PrincipalGet")]
    public async Task<HttpResponseData?> PrincipalGet(
        [HttpTrigger(AuthorizationLevel.Anonymous, Method.Get, Route = "principal/get")] HttpRequestData req, CancellationToken cancellationToken)
    {
        try
        {
            var userId = await req.GetUserIdAsync(cancellationToken);
            if (string.IsNullOrEmpty(userId)) throw new InvalidOperationException("GetUserId null");

            var model = await repo.Get<AuthPrincipal>(DocumentType.Principal, userId, cancellationToken);

            return await req.CreateResponse(model, TtlCache.OneDay, cancellationToken);
        }
        catch (Exception ex)
        {
            req.LogError(ex);
            throw;
        }
    }

    //[Function("PrincipalGetAll")]
    //public async Task<HttpResponseData?> PrincipalGetAll(
    //   [HttpTrigger(AuthorizationLevel.Anonymous, Method.Get, Route = "principal/get-all")] HttpRequestData req, CancellationToken cancellationToken)
    //{
    //    try
    //    {
    //        var data = await repo.ListAll<AuthPrincipal>(DocumentType.Principal, cancellationToken);

    //        return await req.CreateResponse(data, TtlCache.OneDay, cancellationToken);
    //    }
    //    catch (Exception ex)
    //    {
    //        req.LogError(ex);
    //        throw;
    //    }
    //}

    [Function("PrincipalAdd")]
    public async Task<AuthPrincipal?> PrincipalAdd(
        [HttpTrigger(AuthorizationLevel.Anonymous, Method.Post, Route = "principal/add")] HttpRequestData req, CancellationToken cancellationToken)
    {
        //note: its called once per user (first access)

        try
        {
            var userId = await req.GetUserIdAsync(cancellationToken);
            var body = await req.GetBody<AuthPrincipal>(cancellationToken);

            if (userId.Empty()) throw new InvalidOperationException("unauthenticated user");

            //check if user ip is blocked for insert
            var ip = req.GetUserIP(false) ?? throw new UnhandledException("Failed to retrieve IP");
            var blockedIp = await repoCache.Get<DataBlocked>($"block-{ip}", cancellationToken);
            if (blockedIp?.Data != null)
            {
                blockedIp.Data.Quantity++;
                await repoCache.UpsertItemAsync(blockedIp, cancellationToken);

                if (blockedIp.Data?.Quantity > 2)
                {
                    //todo: create a mechanism to increase block time if user persist on this action (first = block one hour, second = block 24 hours)
                    req.LogWarning($"PrincipalAdd blocked IP {ip}");
                    throw new NotificationException("You've reached the limit for creating profiles. Please try again later.");
                }
            }
            else
            {
                _ = repoCache.CreateItemAsync(new DataBlockedCache(new DataBlocked(), $"block-{ip}", TtlCache.OneWeek), cancellationToken);
            }

            foreach (var item in body.Events.Where(w => w.Ip.Empty()))
            {
                item.Ip = ip;
            }

            var model = new AuthPrincipal
            {
                AuthProviders = body.AuthProviders,
                DisplayName = body.DisplayName,
                Email = body.Email,
                Events = body.Events
            };
            model.Initialize(userId);

            return await repo.CreateItemAsync(model, cancellationToken);
        }
        catch (Exception ex)
        {
            req.LogError(ex);
            throw;
        }
    }

    [Function("PrincipalUpdate")]
    public async Task<AuthPrincipal?> PrincipalUpdate(
       [HttpTrigger(AuthorizationLevel.Anonymous, Method.Put, Route = "principal/update")] HttpRequestData req, CancellationToken cancellationToken)
    {
        try
        {
            var userId = await req.GetUserIdAsync(cancellationToken);
            var body = await req.GetBody<AuthPrincipal>(cancellationToken);

            if (userId.Empty()) throw new InvalidOperationException("unauthenticated user");

            var model = await repo.Get<AuthPrincipal>(DocumentType.Principal, userId, cancellationToken);

            model!.AuthProviders = body.AuthProviders;

            return await repo.UpsertItemAsync(model, cancellationToken);
        }
        catch (Exception ex)
        {
            req.LogError(ex);
            throw;
        }
    }

    [Function("PrincipalEvent")]
    public async Task<AuthPrincipal> PrincipalEvent(
       [HttpTrigger(AuthorizationLevel.Anonymous, Method.Put, Route = "principal/event")] HttpRequestData req, CancellationToken cancellationToken)
    {
        try
        {
            var userId = await req.GetUserIdAsync(cancellationToken);
            var ip = req.GetUserIP(true);

            var model = await repo.Get<AuthPrincipal>(DocumentType.Principal, userId, cancellationToken) ?? throw new UnhandledException("Client null");

            var app = req.GetQueryParameters()["app"];
            var msg = req.GetQueryParameters()["msg"];

            model.Events.Add(new Event(app, msg, ip));

            return await repo.UpsertItemAsync(model, cancellationToken);
        }
        catch (Exception ex)
        {
            req.LogError(ex);
            throw;
        }
    }

    [Function("PrincipalRemove")]
    public async Task PrincipalRemove(
        [HttpTrigger(AuthorizationLevel.Anonymous, Method.Delete, Route = "principal/remove")] HttpRequestData req, CancellationToken cancellationToken)
    {
        try
        {
            var userId = await req.GetUserIdAsync(cancellationToken);

            var myPrincipal = await repo.Get<AuthPrincipal>(DocumentType.Principal, userId, cancellationToken);
            if (myPrincipal != null) await repo.Delete(myPrincipal, cancellationToken);

            var myLogins = await repo.Get<AuthLogin>(DocumentType.Login, userId, cancellationToken);
            if (myLogins != null) await repo.Delete(myLogins, cancellationToken);

            var myProfileOff = await repoOff.Get<ProfileModel>(userId, cancellationToken);
            if (myProfileOff != null) await repoOff.DeleteItemAsync(myProfileOff, cancellationToken);

            var myProfileOn = await repoOn.Get<ProfileModel>(userId, cancellationToken);
            if (myProfileOn != null) await repoOn.DeleteItemAsync(myProfileOn, cancellationToken);

            var myFilter = await repo.Get<FilterModel>(DocumentType.Filter, userId, cancellationToken);
            if (myFilter != null) await repo.Delete(myFilter, cancellationToken);

            var mySettings = await repo.Get<SettingModel>(DocumentType.Setting, userId, cancellationToken);
            if (mySettings != null) await repo.Delete(mySettings, cancellationToken);

            var mySuggestions = await repo.Get<MySuggestionsModel>(DocumentType.Suggestions, userId, cancellationToken);
            if (mySuggestions != null) await repo.Delete(mySuggestions, cancellationToken);

            var myLikes = await repo.Get<MyLikesModel>(DocumentType.Likes, userId, cancellationToken);
            if (myLikes != null) await repo.Delete(myLikes, cancellationToken);

            var myMatches = await repo.Get<MyMatchesModel>(DocumentType.Matches, userId, cancellationToken);
            if (myMatches != null) await repo.Delete(myMatches, cancellationToken);

            //todo: interactions belongs to two users. decide what to do.
            //var myInteractions = await repo.Get<InteractionModel>(DocumentType.Interaction, userId, cancellationToken);
            //await repo.Delete(myInteractions, cancellationToken);

            var myValidations = await repo.Get<ValidationModel>(DocumentType.Validation, userId, cancellationToken);
            if (myValidations != null) await repo.Delete(myValidations, cancellationToken);
        }
        catch (Exception ex)
        {
            req.LogError(ex);
            throw;
        }
    }

    [Function("PrincipalPublicMode")]
    public async Task<AuthPrincipal?> PrincipalPublicMode(
     [HttpTrigger(AuthorizationLevel.Anonymous, Method.Put, Route = "principal/public")] HttpRequestData req, CancellationToken cancellationToken)
    {
        try
        {
            var userId = await req.GetUserIdAsync(cancellationToken);

            var profile = await repoOff.Get<ProfileModel>(userId, cancellationToken) ?? throw new NotificationException("profile not found");
            var ProfileValidator = new ProfileValidation();
            var ProfileValid = (await ProfileValidator.ValidateAsync(profile, options => options.IncludeAllRuleSets(), cancellationToken)).IsValid;

            var filter = await repo.Get<FilterModel>(DocumentType.Filter, userId, cancellationToken) ?? throw new NotificationException("filter not found");
            var FilterValidator = new FilterValidation();
            var FilterValid = filter != null && FilterValidator.Validate(filter).IsValid;

            var setting = await repo.Get<SettingModel>(DocumentType.Setting, userId, cancellationToken) ?? throw new NotificationException("setting not found");
            var SettingValid = setting != null;

            var PhotoValidator = new PhotoValidation();
            var GalleryValid = profile.Gallery != null && PhotoValidator.Validate(profile.Gallery).IsValid;

            var validation = await repo.Get<ValidationModel>(DocumentType.Validation, userId, cancellationToken) ?? throw new NotificationException("validation not found");
            var ValidationsValid = validation != null && validation.Gallery;

            if (!ProfileValid || !FilterValid || !SettingValid || !GalleryValid || !ValidationsValid)
            {
                throw new NotificationException("Please complete all steps before making your profile public.");
            }

            await repoOn.UpsertItemAsync(profile, cancellationToken);
            await repoOff.DeleteItemAsync(profile, cancellationToken);

            var principal = await repo.Get<AuthPrincipal>(DocumentType.Principal, userId, cancellationToken) ?? throw new UnhandledException("AuthPrincipal null");
            principal.PublicProfile = true;

            return await repo.UpsertItemAsync(principal, cancellationToken);
        }
        catch (Exception ex)
        {
            req.LogError(ex);
            throw;
        }
    }

    [Function("PrincipalPrivateMode")]
    public async Task<AuthPrincipal?> PrincipalPrivateMode(
    [HttpTrigger(AuthorizationLevel.Anonymous, Method.Put, Route = "principal/private")] HttpRequestData req, CancellationToken cancellationToken)
    {
        try
        {
            var userId = await req.GetUserIdAsync(cancellationToken);

            var profile = await repoOn.Get<ProfileModel>(userId, cancellationToken) ?? throw new NotificationException("profile not found");
            await repoOff.UpsertItemAsync(profile, cancellationToken);
            await repoOn.DeleteItemAsync(profile, cancellationToken);

            var principal = await repo.Get<AuthPrincipal>(DocumentType.Principal, userId, cancellationToken) ?? throw new UnhandledException("AuthPrincipal null");
            principal.PublicProfile = false;

            return await repo.UpsertItemAsync(principal, cancellationToken);
        }
        catch (Exception ex)
        {
            req.LogError(ex);
            throw;
        }
    }

    //[Function("PrincipalMigrate")]
    //public async Task PrincipalMigrate(
    //    [HttpTrigger(AuthorizationLevel.Anonymous, Method.Put, Route = "principal/migrate/{oldId}/{newId}")] HttpRequestData req, string oldId, string newId, CancellationToken cancellationToken)
    //{
    //    try
    //    {
    //        var myPrincipal = await repo.Get<AuthPrincipal>(DocumentType.Principal, oldId, cancellationToken);
    //        if (myPrincipal != null)
    //        {
    //            var model = myPrincipal.DeepClone();
    //            model.Initialize(newId);
    //            await repo.CreateItemAsync(model, cancellationToken);
    //            await repo.Delete(myPrincipal, cancellationToken);
    //        }

    //        var myLogins = await repo.Get<AuthLogin>(DocumentType.Login, oldId, cancellationToken);
    //        if (myLogins != null)
    //        {
    //            var model = myLogins.DeepClone();
    //            model.Initialize(newId);
    //            await repo.CreateItemAsync(model, cancellationToken);
    //            await repo.Delete(myLogins, cancellationToken);
    //        }

    //        var myProviders = await repo.Get<MyProviders>(DocumentType.MyProvider, oldId, cancellationToken);
    //        if (myProviders != null)
    //        {
    //            var model = myProviders.DeepClone();
    //            model.Initialize(newId);
    //            await repo.CreateItemAsync(model, cancellationToken);
    //            await repo.Delete(myProviders, cancellationToken);
    //        }

    //        var mySuggestions = await repo.Get<MySuggestions>(DocumentType.MySuggestions, oldId, cancellationToken);
    //        if (mySuggestions != null)
    //        {
    //            var model = mySuggestions.DeepClone();
    //            model.Initialize(newId);
    //            await repo.CreateItemAsync(model, cancellationToken);
    //            await repo.Delete(mySuggestions, cancellationToken);
    //        }

    //        var myWatched = await repo.Get<WatchedList>(DocumentType.WatchedList, oldId, cancellationToken);
    //        if (myWatched != null)
    //        {
    //            var model = myWatched.DeepClone();
    //            model.Initialize(newId);
    //            await repo.CreateItemAsync(model, cancellationToken);
    //            await repo.Delete(myWatched, cancellationToken);
    //        }

    //        var myWatching = await repo.Get<WatchingList>(DocumentType.WatchingList, oldId, cancellationToken);
    //        if (myWatching != null)
    //        {
    //            var model = myWatching.DeepClone();
    //            model.Initialize(newId);
    //            await repo.CreateItemAsync(model, cancellationToken);
    //            await repo.Delete(myWatching, cancellationToken);
    //        }

    //        var myWish = await repo.Get<WishList>(DocumentType.WishList, oldId, cancellationToken);
    //        if (myWish != null)
    //        {
    //            var model = myWish.DeepClone();
    //            model.Initialize(newId);
    //            await repo.CreateItemAsync(model, cancellationToken);
    //            await repo.Delete(myWish, cancellationToken);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        req.LogError(ex);
    //        throw;
    //    }
    //}
}