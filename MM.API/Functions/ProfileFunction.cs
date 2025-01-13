using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using MM.Shared.Models.Auth;
using MM.Shared.Models.Profile;
using MM.Shared.Requests;

namespace MM.API.Functions
{
    public static class ProfileHelper
    {
        public static async Task<ProfileModel?> GetProfile(CosmosProfileOffRepository repoOff, CosmosProfileOnRepository repoOn, string? userId, CancellationToken cancellationToken)
        {
            //todo: after online mode, change to ON by default

            var profile = await repoOff.Get<ProfileModel>(userId, cancellationToken);

            profile ??= await repoOn.Get<ProfileModel>(userId, cancellationToken);

            return profile;
        }

        public static async Task<MyLikesModel> GetMyLikes(this CosmosRepository repo, string? userId, CancellationToken cancellationToken)
        {
            var myLikes = await repo.Get<MyLikesModel>(DocumentType.Likes, userId, cancellationToken);

            if (myLikes == null)
            {
                myLikes = new MyLikesModel();
                myLikes.Initialize(userId);
            }

            return myLikes;
        }

        public static async Task<MyMatchesModel> GetMyMatches(this CosmosRepository repo, string? userId, CancellationToken cancellationToken)
        {
            var myLikes = await repo.Get<MyMatchesModel>(DocumentType.Matches, userId, cancellationToken);

            if (myLikes == null)
            {
                myLikes = new MyMatchesModel();
                myLikes.Initialize(userId);
            }

            return myLikes;
        }

        public static async Task SetMyMatches(this CosmosRepository repo, (ProfileModel profile, MyLikesModel likes, MyMatchesModel matches) user,
            (ProfileModel profile, MyLikesModel likes, MyMatchesModel matches) partner, CancellationToken cancellationToken)
        {
            if (user.profile.Id == partner.profile.Id) throw new NotificationException("invalid operation. profiles are the same.");
            if (user.likes.Id == partner.likes.Id) throw new NotificationException("invalid operation. likes are the same.");
            if (user.matches.Id == partner.matches.Id) throw new NotificationException("invalid operation. matches are the same.");

            user.likes.Items.RemoveWhere(w => w.UserId == partner.profile.Id);
            user.matches.Items.Add(new PersonModel(partner.profile));

            partner.likes.Items.RemoveWhere(w => w.UserId == user.profile.Id);
            partner.matches.Items.Add(new PersonModel(user.profile));

            await repo.Upsert(user.likes, cancellationToken);
            await repo.Upsert(user.matches, cancellationToken);

            await repo.Upsert(partner.likes, cancellationToken);
            await repo.Upsert(partner.matches, cancellationToken);
        }
    }

    public class ProfileFunction(CosmosRepository repoGen, CosmosCacheRepository repoCache, CosmosProfileOffRepository repoOff, CosmosProfileOnRepository repoOn)
    {
        private readonly CosmosRepository _repoGen = repoGen;
        private readonly CosmosCacheRepository _repoCache = repoCache;

        [Function("ProfileGetData")]
        public async Task<HttpResponseData?> ProfileGetData(
            [HttpTrigger(AuthorizationLevel.Function, Method.GET, Route = "profile/get-data")] HttpRequestData req, CancellationToken cancellationToken)
        {
            try
            {
                var userId = req.GetUserId();
                var profile = await ProfileHelper.GetProfile(repoOff, repoOn, userId, cancellationToken);

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
                var profile = await ProfileHelper.GetProfile(repoOff, repoOn, id, cancellationToken);

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

        [Function("ProfileGetInteraction")]
        public async Task<HttpResponseData?> GetInteraction(
           [HttpTrigger(AuthorizationLevel.Function, Method.GET, Route = "profile/get-interaction/{id}")] HttpRequestData req, string id, CancellationToken cancellationToken)
        {
            try
            {
                var userId = req.GetUserId();

                var interaction = await _repoGen.GetInteractionModel(userId, id, cancellationToken);

                return await req.CreateResponse(interaction, ttlCache.one_hour, cancellationToken);
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

                return await repoOff.Upsert(body, cancellationToken);
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
                    var profile = await ProfileHelper.GetProfile(repoOff, repoOn, userId, cancellationToken);

                    //add like to partner
                    var partnerLikes = await _repoGen.GetMyLikes(partner.UserId, cancellationToken);
                    partnerLikes.Items.Add(new PersonModel(profile));

                    //create interaction between users
                    await _repoGen.SetInteractionNew(profile!.Id, partner.UserId, EventType.Like, cancellationToken);

                    await _repoGen.Upsert(partnerLikes, cancellationToken);
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