using FluentValidation;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using MM.API.Core.Auth;
using MM.Shared.Core.Types;
using MM.Shared.Models.Auth;
using MM.Shared.Models.Profile;
using MM.Shared.Models.Profile.Core;

namespace MM.API.Functions;

public static class ProfileHelper
{
    public static async Task<ProfileModel?> GetProfile(CosmosProfileOffRepository repoOff,
        CosmosProfileOnRepository repoOn, string? userId, CancellationToken cancellationToken)
    {
        //todo: on second phase, exchange to ON by default

        var profile = await repoOff.ReadItemAsync<ProfileModel>(new ProfileIdentity(userId), cancellationToken);

        profile ??= await repoOn.ReadItemAsync<ProfileModel>(new ProfileIdentity(userId), cancellationToken);

        return profile;
    }

    public static async Task<MyLikesModel> GetMyLikes(this CosmosMainRepository repo, string userId, CancellationToken cancellationToken)
    {
        var myLikes = await repo.ReadItemAsync<MyLikesModel>(new MainIdentity(MainType.Likes, userId), cancellationToken);
        myLikes ??= new MyLikesModel(userId);

        return myLikes;
    }

    public static async Task<MyMatchesModel> GetMyMatches(this CosmosMainRepository repo, string userId, CancellationToken cancellationToken)
    {
        var myLikes = await repo.ReadItemAsync<MyMatchesModel>(new MainIdentity(MainType.Matches, userId), cancellationToken);
        myLikes ??= new MyMatchesModel(userId);

        return myLikes;
    }

    public static async Task SetMyMatches(this CosmosMainRepository repo,
        (ProfileModel profile, MyLikesModel likes, MyMatchesModel matches) user,
        (ProfileModel profile, MyLikesModel likes, MyMatchesModel matches) partner, CancellationToken cancellationToken)
    {
        if (user.profile.Id == partner.profile.Id)
            throw new NotificationException("invalid operation. profiles are the same.");
        if (user.likes.Id == partner.likes.Id)
            throw new NotificationException("invalid operation. likes are the same.");
        if (user.matches.Id == partner.matches.Id)
            throw new NotificationException("invalid operation. matches are the same.");

        var userSettings = await repo.ReadItemAsync<SettingModel>(new MainIdentity(MainType.Setting, user.profile.Id), cancellationToken);
        var partnerSettings = await repo.ReadItemAsync<SettingModel>(new MainIdentity(MainType.Setting, partner.profile.Id), cancellationToken);

        user.likes.Items.RemoveWhere(w => w.UserId == partner.profile.Id);
        user.matches.Items.Add(new PersonModel(partner.profile, userSettings?.BlindDate ?? false));

        partner.likes.Items.RemoveWhere(w => w.UserId == user.profile.Id);
        partner.matches.Items.Add(new PersonModel(user.profile, partnerSettings?.BlindDate ?? false));

        await repo.UpsertItemAsync(user.likes);
        await repo.UpsertItemAsync(user.matches);

        await repo.UpsertItemAsync(partner.likes);
        await repo.UpsertItemAsync(partner.matches);
    }
}

public class ProfileFunction(CosmosMainRepository repoGen, CosmosProfileOffRepository repoOff, CosmosProfileOnRepository repoOn)
{
    private readonly CosmosMainRepository _repoGen = repoGen;

    //[Function("ProfileGetAll")]
    //public async Task<HttpResponseData?> ProfileGetAll(
    //   [HttpTrigger(AuthorizationLevel.Anonymous, Method.Get, Route = "profile/get-all")] HttpRequestData req, CancellationToken cancellationToken)
    //{
    //    var dataPrincipal = await repoGen.ListAll<AuthPrincipal>(DocumentType.Principal, cancellationToken);
    //    var dataOff = await repoOff.ListAll<ProfileModel>(cancellationToken);
    //    var dataOn = await repoOn.ListAll<ProfileModel>(cancellationToken);
    //    var merge = dataOff.Union(dataOn);

    //    HashSet<ProfileManage> profileManages = [];
    //    foreach (var item in dataPrincipal.OrderByDescending(p => p.DateTimeCreated))
    //    {
    //        profileManages.Add(new ProfileManage { Principal = item, Profile = merge.SingleOrDefault(p => p.Id == item.UserId) });
    //    }

    //    return await req.CreateResponse(profileManages, TtlCache.OneDay, cancellationToken);
    //}

    [Function("ProfileGetData")]
    public async Task<HttpResponseData?> ProfileGetData(
        [HttpTrigger(AuthorizationLevel.Function, Method.Get, Route = "profile/get-data")] HttpRequestData req, CancellationToken cancellationToken)
    {
        var userId = await req.GetUserIdAsync(cancellationToken);
        var profile = await ProfileHelper.GetProfile(repoOff, repoOn, userId, cancellationToken);

        return await req.CreateResponse(profile, TtlCache.OneDay, cancellationToken);
    }

    [Function("ProfileGetFilter")]
    public async Task<HttpResponseData?> ProfileGetFilter(
        [HttpTrigger(AuthorizationLevel.Function, Method.Get, Route = "profile/get-filter")] HttpRequestData req, CancellationToken cancellationToken)
    {
        var userId = await req.GetUserIdAsync(cancellationToken);
        var doc = await _repoGen.ReadItemAsync<FilterModel>(new MainIdentity(MainType.Filter, userId), cancellationToken);

        return await req.CreateResponse(doc, TtlCache.OneDay, cancellationToken);
    }

    [Function("ProfileGetSetting")]
    public async Task<HttpResponseData?> ProfileGetSetting(
        [HttpTrigger(AuthorizationLevel.Function, Method.Get, Route = "profile/get-setting")] HttpRequestData req, CancellationToken cancellationToken)
    {
        var userId = await req.GetUserIdAsync(cancellationToken);
        var doc = await _repoGen.ReadItemAsync<SettingModel>(new MainIdentity(MainType.Setting, userId), cancellationToken);

        return await req.CreateResponse(doc, TtlCache.OneDay, cancellationToken);
    }

    [Function("ProfileValidation")]
    public async Task<HttpResponseData?> ProfileValidation(
        [HttpTrigger(AuthorizationLevel.Function, Method.Get, Route = "profile/get-validation")] HttpRequestData req, CancellationToken cancellationToken)
    {
        var userId = await req.GetUserIdAsync(cancellationToken);
        var doc = await _repoGen.ReadItemAsync<ValidationModel>(new MainIdentity(MainType.Validation, userId), cancellationToken);

        return await req.CreateResponse(doc, TtlCache.OneDay, cancellationToken);
    }

    [Function("ProfileGetView")]
    public async Task<HttpResponseData?> GetView(
        [HttpTrigger(AuthorizationLevel.Function, Method.Get, Route = "profile/get-view/{id}")] HttpRequestData req, string id, CancellationToken cancellationToken)
    {
        //var userId = await req.GetUserIdAsync(cancellationToken);
        var profile = await ProfileHelper.GetProfile(repoOff, repoOn, id, cancellationToken);

        if (profile == null) return null;

        profile.Age = profile.BirthDate.GetAge();
        profile.BirthDate = null;

        profile.Gallery = null; //todo: temporary

        //var userSettings = await _repoGen.Get<SettingModel>(DocumentType.Setting, userId, cancellationToken);

        //if (userSettings?.BlindDate ?? false) profile.Gallery?.SimulateBlindDate();

        //profile.ActivityStatus = ActivityStatus.Today;

        //if (profile.DtLastLogin >= DateTime.UtcNow.AddDays(-1)) profile.ActivityStatus = ActivityStatus.Today;
        //else if (profile.DtLastLogin >= DateTime.UtcNow.AddDays(-7)) profile.ActivityStatus = ActivityStatus.Week;
        //else if (profile.DtLastLogin >= DateTime.UtcNow.AddMonths(-1)) profile.ActivityStatus = ActivityStatus.Month;
        //else profile.ActivityStatus = ActivityStatus.Disabled;

        return await req.CreateResponse(profile, TtlCache.OneDay, cancellationToken);
    }

    //[Function("ProfileListSearch")]
    //public async Task<List<ProfileSearch>> ListSearch(
    //   [HttpTrigger(AuthorizationLevel.Function, Method.GET, Route = "Profile/ListSearch")] HttpRequestData req, CancellationToken cancellationToken)
    //{
    //        var request = req.BuildRequestQuery<ProfileListSearchCommand, List<ProfileSearch>>();

    //        var result = await _mediator.Send(request, source.Token);

    //        return new OkObjectResult(result);

    //}

    [Function("ProfileUpdateData")]
    public async Task<ProfileModel> ProfileUpdateData(
        [HttpTrigger(AuthorizationLevel.Function, Method.Put, Route = "profile/update-data")] HttpRequestData req, CancellationToken cancellationToken)
    {
        var userId = await req.GetUserIdAsync(cancellationToken);
        var body = await req.GetBody<ProfileModel>(cancellationToken);
        var principal = await _repoGen.ReadItemAsync<AuthPrincipal>(new MainIdentity(MainType.Principal, userId), cancellationToken) ?? throw new NotificationException("user not found");

        await req.ValidateUser(body.Identity.RawId, cancellationToken);
        body.SanitizeOpenTextFields();

        if (principal.PublicProfile) throw new NotificationException("Changes not allowed in public mode");

        var validator = new ProfileValidation();
        var result = await validator.ValidateAsync(body, options => options.IncludeRuleSets("BASIC"), cancellation: cancellationToken);
        if (!result.IsValid) throw new NotificationException(result.Errors[0].ErrorMessage);

        return await repoOff.UpsertItemAsync(body);
    }

    [Function("ProfileUpdateFilter")]
    public async Task<FilterModel> ProfileUpdateFilter(
        [HttpTrigger(AuthorizationLevel.Function, Method.Put, Route = "profile/update-filter")] HttpRequestData req, CancellationToken cancellationToken)
    {
        var body = await req.GetBody<FilterModel>(cancellationToken);

        await req.ValidateUser(body.Identity.RawId, cancellationToken);

        var validator = new FilterValidation();
        var result = await validator.ValidateAsync(body, cancellationToken);
        if (!result.IsValid) throw new NotificationException(result.Errors[0].ErrorMessage);

        return await _repoGen.UpsertItemAsync(body);
    }

    [Function("ProfileUpdateSetting")]
    public async Task<SettingModel> ProfileUpdateSetting(
        [HttpTrigger(AuthorizationLevel.Function, Method.Put, Route = "profile/update-setting")] HttpRequestData req, CancellationToken cancellationToken)
    {
        var body = await req.GetBody<SettingModel>(cancellationToken);

        await req.ValidateUser(body.Identity.RawId, cancellationToken);

        return await _repoGen.UpsertItemAsync(body);
    }

    [Function("ProfileGetMyLikes")]
    public async Task<HttpResponseData?> ProfileGetMyLikes(
        [HttpTrigger(AuthorizationLevel.Function, Method.Get, Route = "profile/get-mylikes")] HttpRequestData req, CancellationToken cancellationToken)
    {
        var userId = await req.GetUserIdAsync(cancellationToken);

        var obj = await _repoGen.ReadItemAsync<MyLikesModel>(new MainIdentity(MainType.Likes, userId), cancellationToken);

        return await req.CreateResponse(obj, TtlCache.OneDay, cancellationToken);
    }

    [Function("ProfileGetMyMatches")]
    public async Task<HttpResponseData?> ProfileGetMyMatches(
        [HttpTrigger(AuthorizationLevel.Function, Method.Get, Route = "profile/get-mymatches")] HttpRequestData req, CancellationToken cancellationToken)
    {
        var userId = await req.GetUserIdAsync(cancellationToken);

        var obj = await _repoGen.ReadItemAsync<MyMatchesModel>(new MainIdentity(MainType.Matches, userId), cancellationToken);

        return await req.CreateResponse(obj, TtlCache.OneDay, cancellationToken);
    }
}