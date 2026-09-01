using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using MM.Shared.Core.Types;
using MM.Shared.Models.Auth;
using MM.Shared.Models.Profile;

namespace MM.API.Functions.Admin;

public class PrincipalFunction(CosmosMainRepository repo, CosmosProfileOffRepository repoOff, CosmosProfileOnRepository repoOn)
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

    //private const string CloneFailed = "DeepClone failed";

    //[Function("PrincipalMigrate")]
    //public async Task PrincipalMigrate(
    //    [HttpTrigger(AuthorizationLevel.Anonymous, Method.Post, Route = "principal/migrate")] HttpRequestData req, CancellationToken cancellationToken)
    //{
    //    var principais = await repo.Query<AuthPrincipal>(MainType.Principal, p => !p.UserId!.StartsWith("user_"), transform: null, cancellationToken);
    //    var sdk = new ClerkBackendApi(bearerAuth: ApiStartup.Configurations.ClerkAuth!.SecretKey);

    //    foreach (var principal in principais)
    //    {
    //        try
    //        {
    //            var request = new CreateUserRequestBody()
    //            {
    //                FirstName = principal.DisplayName?.Split(" ").ElementAtIndex(0),
    //                LastName = principal.DisplayName?.Split(" ").ElementAtIndex(1),
    //                EmailAddress = [principal.Email!],
    //            };

    //            var user = await sdk.Users.CreateAsync(request);

    //            var clone = principal.DeepClone() ?? throw new NotificationException(CloneFailed);
    //            clone.ChangeIdentity(new MainIdentity(MainType.Principal, user.User!.Id));
    //            clone.UserId = user.User.Id;
    //            await repo.CreateItemAsync(clone);
    //            await repo.DeleteItemAsync<AuthPrincipal>(new MainIdentity(MainType.Principal, principal.Id));

    //            var myLogins = await repo.ReadItemAsync<AuthLogin>(new MainIdentity(MainType.Login, principal.Id), cancellationToken);
    //            if (myLogins != null)
    //            {
    //                var model = myLogins.DeepClone() ?? throw new NotificationException(CloneFailed);
    //                model.ChangeIdentity(new MainIdentity(MainType.Login, user.User.Id));
    //                model.UserId = user.User.Id;
    //                await repo.CreateItemAsync(model);
    //                await repo.DeleteItemAsync<AuthLogin>(new MainIdentity(MainType.Login, principal.Id));
    //            }

    //            var myFilter = await repo.ReadItemAsync<FilterModel>(new MainIdentity(MainType.Filter, principal.Id), cancellationToken);
    //            if (myFilter != null)
    //            {
    //                var model = myFilter.DeepClone() ?? throw new NotificationException(CloneFailed);
    //                model.ChangeIdentity(new MainIdentity(MainType.Filter, user.User.Id));
    //                await repo.CreateItemAsync(model);
    //                await repo.DeleteItemAsync<FilterModel>(new MainIdentity(MainType.Filter, principal.Id));
    //            }

    //            var mySetting = await repo.ReadItemAsync<SettingModel>(new MainIdentity(MainType.Setting, principal.Id), cancellationToken);
    //            if (mySetting != null)
    //            {
    //                var model = mySetting.DeepClone() ?? throw new NotificationException(CloneFailed);
    //                model.ChangeIdentity(new MainIdentity(MainType.Setting, user.User.Id));
    //                await repo.CreateItemAsync(model);
    //                await repo.DeleteItemAsync<SettingModel>(new MainIdentity(MainType.Setting, principal.Id));
    //            }

    //            var myValidation = await repo.ReadItemAsync<ValidationModel>(new MainIdentity(MainType.Validation, principal.Id), cancellationToken);
    //            if (myValidation != null)
    //            {
    //                var model = myValidation.DeepClone() ?? throw new NotificationException(CloneFailed);
    //                model.ChangeIdentity(new MainIdentity(MainType.Validation, user.User.Id));
    //                await repo.CreateItemAsync(model);
    //                await repo.DeleteItemAsync<ValidationModel>(new MainIdentity(MainType.Validation, principal.Id));
    //            }

    //            var myProfileOff = await repoOff.ReadItemAsync<ProfileModel>(new ProfileIdentity(principal.Identity.RawId), cancellationToken);
    //            if (myProfileOff != null)
    //            {
    //                var model = myProfileOff.DeepClone() ?? throw new NotificationException(CloneFailed);
    //                model.ChangeIdentity(new ProfileIdentity(user.User.Id));
    //                await repoOff.CreateItemAsync(model);
    //                await repoOff.DeleteItemAsync<ProfileModel>(new ProfileIdentity(principal.Identity.RawId));
    //            }

    //            var myProfileOn = await repoOn.ReadItemAsync<ProfileModel>(new ProfileIdentity(principal.Identity.RawId), cancellationToken);
    //            if (myProfileOn != null)
    //            {
    //                var model = myProfileOn.DeepClone() ?? throw new NotificationException(CloneFailed);
    //                model.ChangeIdentity(new ProfileIdentity(user.User.Id));
    //                await repoOn.CreateItemAsync(model);
    //                await repoOn.DeleteItemAsync<ProfileModel>(new ProfileIdentity(principal.Identity.RawId));
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }
    //    }
    //}
}