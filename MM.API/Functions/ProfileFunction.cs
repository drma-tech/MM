using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using MM.Shared.Models.Auth;
using MM.Shared.Models.Profile;
using MM.Shared.Requests;

namespace MM.API.Functions
{
    public class ProfileFunction(CosmosRepository repoGen, CosmosCacheRepository repoCache, CosmosProfileOffRepository repoOff, CosmosProfileOnRepository repoOn)
    {
        private readonly CosmosRepository _repoGen = repoGen;
        private readonly CosmosCacheRepository _repoCache = repoCache;
        private readonly CosmosProfileOffRepository _repoProfileOff = repoOff;
        private readonly CosmosProfileOnRepository _repoProfileOn = repoOn;

        [Function("ProfileGetData")]
        public async Task<HttpResponseData?> ProfileGetData(
            [HttpTrigger(AuthorizationLevel.Function, Method.GET, Route = "profile/get-data")] HttpRequestData req, CancellationToken cancellationToken)
        {
            try
            {
                var userId = req.GetUserId();
                ProfileModel? profile = null;

                var principal = await _repoGen.Get<ClientePrincipal>(DocumentType.Principal, userId, cancellationToken) ?? throw new NotificationException("user not found");

                if (principal.PublicProfile)
                    profile = await _repoProfileOn.Get<ProfileModel>(userId, cancellationToken);
                else
                    profile = await _repoProfileOff.Get<ProfileModel>(userId, cancellationToken);

                return await req.CreateResponse(profile, ttlCache.one_day, cancellationToken);
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw;
            }
        }

        [Function("ProfileGetFilter")]
        public async Task<HttpResponseData?> ProfileGetFilter(
            [HttpTrigger(AuthorizationLevel.Function, Method.GET, Route = "profile/get-filter")] HttpRequestData req, CancellationToken cancellationToken)
        {
            try
            {
                var userId = req.GetUserId();

                var doc = await _repoGen.Get<FilterModel>(DocumentType.Filter, userId, cancellationToken);

                return await req.CreateResponse(doc, ttlCache.one_day, cancellationToken);
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw;
            }
        }

        [Function("ProfileGetSetting")]
        public async Task<HttpResponseData?> ProfileGetSetting(
            [HttpTrigger(AuthorizationLevel.Function, Method.GET, Route = "profile/get-setting")] HttpRequestData req, CancellationToken cancellationToken)
        {
            try
            {
                var userId = req.GetUserId();

                var doc = await _repoGen.Get<SettingModel>(DocumentType.Setting, userId, cancellationToken);

                return await req.CreateResponse(doc, ttlCache.one_day, cancellationToken);
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw;
            }
        }

        [Function("ProfileGetView")]
        public async Task<HttpResponseData?> GetView(
            [HttpTrigger(AuthorizationLevel.Function, Method.GET, Route = "profile/get-view/{id}")] HttpRequestData req, string id, CancellationToken cancellationToken)
        {
            try
            {
                var principal = await _repoGen.Get<ClientePrincipal>(DocumentType.Principal, id, cancellationToken) ?? throw new NotificationException("user not found");
                ProfileModel? profile = null;

                if (principal.PublicProfile)
                    profile = await _repoProfileOn.Get<ProfileModel>(id, cancellationToken);
                else
                    profile = await _repoProfileOff.Get<ProfileModel>(id, cancellationToken);

                if (profile == null) return null;

                profile.Age = profile.BirthDate.GetAge();
                profile.BirthDate = DateTime.MinValue;
                //profile.ActivityStatus = ActivityStatus.Today;

                //if (profile.DtLastLogin >= DateTime.UtcNow.AddDays(-1)) profile.ActivityStatus = ActivityStatus.Today;
                //else if (profile.DtLastLogin >= DateTime.UtcNow.AddDays(-7)) profile.ActivityStatus = ActivityStatus.Week;
                //else if (profile.DtLastLogin >= DateTime.UtcNow.AddMonths(-1)) profile.ActivityStatus = ActivityStatus.Month;
                //else profile.ActivityStatus = ActivityStatus.Disabled;

                return await req.CreateResponse(profile, ttlCache.one_day, cancellationToken);
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw;
            }
        }

        //[Function("ProfileListSearch")]
        //public async Task<List<ProfileSearch>> ListSearch(
        //   [HttpTrigger(AuthorizationLevel.Function, Method.GET, Route = "Profile/ListSearch")] HttpRequestData req, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        var request = req.BuildRequestQuery<ProfileListSearchCommand, List<ProfileSearch>>();

        //        var result = await _mediator.Send(request, source.Token);

        //        return new OkObjectResult(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        req.ProcessException(ex);
        //        throw new UnhandledException(ex.BuildException());
        //    }
        //}

        [Function("ProfileUpdateData")]
        public async Task<ProfileModel> ProfileUpdateData(
            [HttpTrigger(AuthorizationLevel.Function, Method.PUT, Route = "profile/update-data")] HttpRequestData req, CancellationToken cancellationToken)
        {
            try
            {
                var userId = req.GetUserId();
                var body = await req.GetBody<ProfileModel>(cancellationToken);
                var principal = await _repoGen.Get<ClientePrincipal>(DocumentType.Principal, userId, cancellationToken) ?? throw new NotificationException("user not found");

                if (principal.PublicProfile) throw new NotificationException("Changes not allowed in public mode");

                return await _repoProfileOff.Upsert(body, cancellationToken);
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw;
            }
        }

        [Function("ProfileUpdateFilter")]
        public async Task<FilterModel> ProfileUpdateFilter(
            [HttpTrigger(AuthorizationLevel.Function, Method.PUT, Route = "profile/update-filter")] HttpRequestData req, CancellationToken cancellationToken)
        {
            try
            {
                var body = await req.GetBody<FilterModel>(cancellationToken);

                return await _repoGen.Upsert(body, cancellationToken);
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw;
            }
        }

        [Function("ProfileUpdateSetting")]
        public async Task<SettingModel> ProfileUpdateSetting(
           [HttpTrigger(AuthorizationLevel.Function, Method.PUT, Route = "profile/update-setting")] HttpRequestData req, CancellationToken cancellationToken)
        {
            try
            {
                var body = await req.GetBody<SettingModel>(cancellationToken);

                return await _repoGen.Upsert(body, cancellationToken);
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw;
            }
        }

        [Function("ProfileSendInvite")]
        public async Task ProfileSendInvite(
            [HttpTrigger(AuthorizationLevel.Function, Method.POST, Route = "profile/send-invite")] HttpRequestData req, CancellationToken cancellationToken)
        {
            try
            {
                var request = await req.GetPublicBody<InviteRequest>(cancellationToken);
                var partners = await _repoGen.Query<ClientePrincipal>((x) => x.Email == request.Email, DocumentType.Principal, cancellationToken);
                var userId = req.GetUserId();

                if (partners.Count != 0) //if user already registered, register a like
                {
                    var partner = partners.Single();

                    var myLikes = await _repoGen.Get<MyLikesModel>(DocumentType.Likes, partner.UserId, cancellationToken);

                    if (myLikes == null)
                    {
                        myLikes = new MyLikesModel();
                        myLikes.Initialize(partner.UserId!);
                    }

                    ProfileModel? profile = null;
                    var principal = await _repoGen.Get<ClientePrincipal>(DocumentType.Principal, userId, cancellationToken) ?? throw new NotificationException("user not found");

                    if (principal.PublicProfile)
                        profile = await _repoProfileOn.Get<ProfileModel>(userId, cancellationToken);
                    else
                        profile = await _repoProfileOff.Get<ProfileModel>(userId, cancellationToken);

                    myLikes.Items.Add(new PersonModel(principal.UserId, profile?.NickName ?? principal.Email?.Split("@")[0], profile?.GetPhoto(ImageHelper.PhotoType.Face)));

                    await _repoGen.Upsert(myLikes, cancellationToken);

                    //generates the interaction
                    var id = InteractionModel.FormatId($"{userId}:{partner.UserId}");
                    var interaction = await _repoGen.Get<InteractionModel>(DocumentType.Interaction, id, cancellationToken);

                    if (interaction == null)
                    {
                        interaction = new InteractionModel();
                        interaction.Initialize(id);
                    }

                    interaction.AddEventUser(userId, EventType.Like);

                    await _repoGen.Upsert(interaction, cancellationToken);
                }
                else //if not, generate a temporary invite
                {
                    var invite = await _repoCache.Get<InviteModel>($"invite-{request.Email}", cancellationToken);

                    if (invite == null)
                    {
                        invite = new CacheDocument<InviteModel>($"invite-{request.Email}", new InviteModel() { UserIds = [userId] }, ttlCache.one_month);
                    }
                    else
                    {
                        invite.Data!.UserIds.Add(userId!);
                    }

                    await _repoCache.UpsertItemAsync(invite, cancellationToken);
                }
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw;
            }
        }

        [Function("ProfileGetMyLikes")]
        public async Task<HttpResponseData?> ProfileGetMyLikes(
            [HttpTrigger(AuthorizationLevel.Function, Method.GET, Route = "profile/get-mylikes")] HttpRequestData req, CancellationToken cancellationToken)
        {
            try
            {
                var userId = req.GetUserId();

                var obj = await _repoGen.Get<MyLikesModel>(DocumentType.Likes, userId, cancellationToken);

                return await req.CreateResponse(obj, ttlCache.one_day, cancellationToken);
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw;
            }
        }

        [Function("ProfileGetMyMatches")]
        public async Task<HttpResponseData?> ProfileGetMyMatches(
            [HttpTrigger(AuthorizationLevel.Function, Method.GET, Route = "profile/get-mymatches")] HttpRequestData req, CancellationToken cancellationToken)
        {
            try
            {
                var userId = req.GetUserId();

                var obj = await _repoGen.Get<MyMatchesModel>(DocumentType.Matches, userId, cancellationToken);

                return await req.CreateResponse(obj, ttlCache.one_day, cancellationToken);
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw;
            }
        }
    }
}