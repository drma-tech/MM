using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using MM.Shared.Models.Profile;

namespace MM.API.Functions
{
    public class ProfileFunction(CosmosProfileRepository repo, CosmosRepository repoFilter)
    {
        private readonly CosmosProfileRepository _repoProfile = repo;
        private readonly CosmosRepository _repo = repoFilter;

        [Function("ProfileGetData")]
        public async Task<HttpResponseData?> ProfileGetData(
           [HttpTrigger(AuthorizationLevel.Function, Method.GET, Route = "profile/get-data")] HttpRequestData req, CancellationToken cancellationToken)
        {
            try
            {
                var userId = req.GetUserId();

                var doc = await _repoProfile.Get<ProfileModel>(userId, cancellationToken);

                return await req.CreateResponse(doc, ttlCache.one_day, doc?.ETag, cancellationToken);
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

                var doc = await _repo.Get<FilterModel>(DocumentType.Filter, userId, cancellationToken);

                return await req.CreateResponse(doc, ttlCache.one_day, doc?.ETag, cancellationToken);
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

                var doc = await _repo.Get<SettingModel>(DocumentType.Setting, userId, cancellationToken);

                return await req.CreateResponse(doc, ttlCache.one_day, doc?.ETag, cancellationToken);
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw;
            }
        }

        //[Function("ProfileGetView")]
        //public async Task<ProfileModel?> GetView(
        //   [HttpTrigger(AuthorizationLevel.Function, Method.GET, Route = "Profile/GetView/{IdUserView}")] HttpRequestData req, string IdUserView, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        var profile = await _repo.Get<ProfileView>(DocumentType.Profile + ":" + IdUserView, new PartitionKey(IdUserView), cancellationToken);
        //        if (profile == null) return null;

        //        profile.Age = profile.BirthDate.GetAge();
        //        profile.BirthDate = DateTime.MinValue;
        //        profile.ActivityStatus = ActivityStatus.Today;

        //        if (profile.DtLastLogin >= DateTime.UtcNow.AddDays(-1)) profile.ActivityStatus = ActivityStatus.Today;
        //        else if (profile.DtLastLogin >= DateTime.UtcNow.AddDays(-7)) profile.ActivityStatus = ActivityStatus.Week;
        //        else if (profile.DtLastLogin >= DateTime.UtcNow.AddMonths(-1)) profile.ActivityStatus = ActivityStatus.Month;
        //        else profile.ActivityStatus = ActivityStatus.Disabled;

        //        return profile;
        //    }
        //    catch (Exception ex)
        //    {
        //        req.ProcessException(ex);
        //        throw new UnhandledException(ex.BuildException());
        //    }
        //}

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
                var body = await req.GetBody<ProfileModel>(cancellationToken);

                return await _repoProfile.Upsert(body, cancellationToken);
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

                return await _repo.Upsert(body, cancellationToken);
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

                return await _repo.Upsert(body, cancellationToken);
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw;
            }
        }
    }
}