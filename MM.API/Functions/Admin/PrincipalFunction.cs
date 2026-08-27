namespace MM.API.Functions.Admin;

public class PrincipalFunction(CosmosMainRepository repo)
{
    //[Function("PrincipalGetAll")]
    //public async Task<HttpResponseData?> PrincipalGetAll(
    //   [HttpTrigger(AuthorizationLevel.Anonymous, Method.Get, Route = "principal/get-all")] HttpRequestData req, CancellationToken cancellationToken)
    //{
    //    var data = await repo.ListAll<AuthPrincipal>(DocumentType.Principal, cancellationToken);

    //    return await req.CreateResponse(data, TtlCache.OneDay, cancellationToken);
    //}

    //[Function("PrincipalPrivateModeUser")]
    //public async Task<AuthPrincipal?> PrincipalPrivateModeUser(
    //    [HttpTrigger(AuthorizationLevel.Anonymous, Method.Put, Route = "principal/private/{userId}")] HttpRequestData req, string userId, CancellationToken cancellationToken)
    //{
    //    var profile = await repoOn.Get<ProfileModel>(userId, cancellationToken) ?? throw new NotificationException("profile not found");
    //    await repoOff.UpsertItemAsync(profile, cancellationToken);
    //    await repoOn.DeleteItemAsync(profile, cancellationToken);

    //    var principal = await repo.Get<AuthPrincipal>(DocumentType.Principal, userId, cancellationToken) ?? throw new UnhandledException("AuthPrincipal is null");
    //    principal.PublicProfile = false;

    //    var zepto = new ZeptoMailClient(ApiStartup.Configurations.ZeptoMail!.JobApiKey!);
    //    await zepto.SendGoPublicAgainEmail(principal.Email, userId, cancellationToken);

    //    return await repo.UpsertItemAsync(principal, cancellationToken);
    //}

    //[Function("PrincipalMigrate")]
    //public async Task PrincipalMigrate(
    //    [HttpTrigger(AuthorizationLevel.Anonymous, Method.Put, Route = "principal/migrate/{oldId}/{newId}")] HttpRequestData req, string oldId, string newId, CancellationToken cancellationToken)
    //{
    //    var myPrincipal = await repo.Get<AuthPrincipal>(DocumentType.Principal, oldId, cancellationToken);
    //    if (myPrincipal != null)
    //    {
    //        var model = myPrincipal.DeepClone();
    //        model.Initialize(newId);
    //        await repo.CreateItemAsync(model, cancellationToken);
    //        await repo.Delete(myPrincipal, cancellationToken);
    //    }

    //    var myLogins = await repo.Get<AuthLogin>(DocumentType.Login, oldId, cancellationToken);
    //    if (myLogins != null)
    //    {
    //        var model = myLogins.DeepClone();
    //        model.Initialize(newId);
    //        await repo.CreateItemAsync(model, cancellationToken);
    //        await repo.Delete(myLogins, cancellationToken);
    //    }

    //    var myFilters = await repo.Get<FilterModel>(DocumentType.Filter, oldId, cancellationToken);
    //    if (myFilters != null)
    //    {
    //        var model = myFilters.DeepClone();
    //        model.Initialize(newId);
    //        await repo.CreateItemAsync(model, cancellationToken);
    //        await repo.Delete(myFilters, cancellationToken);
    //    }

    //    var mySettings = await repo.Get<SettingModel>(DocumentType.Setting, oldId, cancellationToken);
    //    if (mySettings != null)
    //    {
    //        var model = mySettings.DeepClone();
    //        model.Initialize(newId);
    //        await repo.CreateItemAsync(model, cancellationToken);
    //        await repo.Delete(mySettings, cancellationToken);
    //    }

    //    var myValidation = await repo.Get<ValidationModel>(DocumentType.Validation, oldId, cancellationToken);
    //    if (myValidation != null)
    //    {
    //        var model = myValidation.DeepClone();
    //        model.Initialize(newId);
    //        await repo.CreateItemAsync(model, cancellationToken);
    //        await repo.Delete(myValidation, cancellationToken);
    //    }

    //    //profile off

    //    var profileOff = await repoOff.Get<ProfileModel>(oldId, cancellationToken);
    //    if (profileOff != null)
    //    {
    //        var model = profileOff.DeepClone();
    //        model.Id = newId;
    //        await repoOff.UpsertItemAsync(model, cancellationToken);
    //        await repoOff.DeleteItemAsync(profileOff, cancellationToken);
    //    }

    //    //profile on

    //    var profileOn = await repoOn.Get<ProfileModel>(oldId, cancellationToken);
    //    if (profileOn != null)
    //    {
    //        var model = profileOn.DeepClone();
    //        model.Id = newId;
    //        await repoOn.UpsertItemAsync(model, cancellationToken);
    //        await repoOn.DeleteItemAsync(profileOn, cancellationToken);
    //    }
    //}
}
