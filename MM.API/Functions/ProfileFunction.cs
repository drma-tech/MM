using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using MM.Shared.Models.Profile;

namespace MM.API.Functions
{
    public class ProfileFunction(CosmosProfileRepository repo)
    {
        private readonly CosmosProfileRepository _repo = repo;

        [Function("ProfileGet")]
        public async Task<ProfileModel?> ProfileGet(
           [HttpTrigger(AuthorizationLevel.Function, Method.GET, Route = "profile/get")] HttpRequestData req, CancellationToken cancellationToken)
        {
            try
            {
                var userId = req.GetUserId();

                return await _repo.Get<ProfileModel>(userId, cancellationToken);
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw new UnhandledException(ex.BuildException());
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

        [Function("ProfileUpdate")]
        public async Task<ProfileModel> ProfileUpdate(
            [HttpTrigger(AuthorizationLevel.Function, Method.PUT, Route = "profile/update")] HttpRequestData req, CancellationToken cancellationToken)
        {
            try
            {
                var body = await req.GetBody<ProfileModel>(cancellationToken);

                return await _repo.Upsert(body, cancellationToken);
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw new UnhandledException(ex.BuildException());
            }
        }

        //[Function("ProfileUpdateLooking")]
        //public async Task<ProfileModel> UpdateLooking(
        //    [HttpTrigger(AuthorizationLevel.Function, Method.PUT, Route = "profile/update-preference")] HttpRequestData req, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        var userId = req.GetUserId();
        //        var body = await req.GetPublicBody<ProfileModel>(cancellationToken);

        //        var operations = new List<PatchOperation> {
        //            PatchOperation.Set("/preference", body.Preference),
        //            PatchOperation.Add("/dtUpdate", DateTime.UtcNow)
        //        };

        //        return await _repo.PatchItem<ProfileModel>(userId, operations, cancellationToken);
        //    }
        //    catch (Exception ex)
        //    {
        //        req.ProcessException(ex);
        //        throw new UnhandledException(ex.BuildException());
        //    }
        //}
    }
}