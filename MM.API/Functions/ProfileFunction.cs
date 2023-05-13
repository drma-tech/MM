using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using MM.API.Repository.Core;
using MM.Shared.Core.Models;
using MM.Shared.Models.Profile;

namespace VerusDate.Api.Function
{
    public class ProfileFunction
    {
        private readonly IRepository _repo;

        public ProfileFunction(IRepository repo)
        {
            _repo = repo;
        }

        [Function("ProfileGet")]
        public async Task<ProfileModel?> Get(
           [HttpTrigger(AuthorizationLevel.Function, Method.GET, Route = "Profile/Get")] HttpRequestData req, CancellationToken cancellationToken)
        {
            try
            {
                var userId = req.GetUserId();

                return await _repo.Get<ProfileModel>(DocumentType.Profile + ":" + userId, new PartitionKey(userId), cancellationToken);
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw new UnhandledException(ex.BuildException());
            }
        }

        [Function("ProfileGetView")]
        public async Task<ProfileModel?> GetView(
           [HttpTrigger(AuthorizationLevel.Function, Method.GET, Route = "Profile/GetView/{IdUserView}")] HttpRequestData req, string IdUserView, CancellationToken cancellationToken)
        {
            try
            {
                var profile = await _repo.Get<ProfileView>(DocumentType.Profile + ":" + IdUserView, new PartitionKey(IdUserView), cancellationToken);
                if (profile == null) return null;

                profile.Age = profile.BirthDate.GetAge();
                profile.BirthDate = DateTime.MinValue;
                profile.ActivityStatus = ActivityStatus.Today;

                if (profile.DtLastLogin >= DateTime.UtcNow.AddDays(-1)) profile.ActivityStatus = ActivityStatus.Today;
                else if (profile.DtLastLogin >= DateTime.UtcNow.AddDays(-7)) profile.ActivityStatus = ActivityStatus.Week;
                else if (profile.DtLastLogin >= DateTime.UtcNow.AddMonths(-1)) profile.ActivityStatus = ActivityStatus.Month;
                else profile.ActivityStatus = ActivityStatus.Disabled;

                return profile;
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw new UnhandledException(ex.BuildException());
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

        [Function("ProfileUpdate")]
        public async Task<ProfileModel> Update(
            [HttpTrigger(AuthorizationLevel.Function, Method.PUT, Route = "Profile/Update")] HttpRequestData req, CancellationToken cancellationToken)
        {
            //TODO: https://docs.microsoft.com/pt-br/learn/modules/configure-azure-cosmos-db-sql-api-sdk/3-handle-connection-errors

            try
            {
                var body = await req.GetBody<ProfileModel>(cancellationToken);

                //request.Gamification = new ProfileGamificationModel();

                //request.Gamification.ResetFood();
                //request.Gamification.AddXP(30);

                return await _repo.Upsert(body, cancellationToken);
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw new UnhandledException(ex.BuildException());
            }
        }

        [Function("ProfileUpdateLooking")]
        public async Task<ProfileModel> UpdateLooking(
            [HttpTrigger(AuthorizationLevel.Function, Method.PUT, Route = "Profile/UpdateLooking")] HttpRequestData req, CancellationToken cancellationToken)
        {
            try
            {
                var userId = req.GetUserId();
                var body = await req.GetPublicBody<ProfileModel>(cancellationToken);

                var operations = new List<PatchOperation> {
                    PatchOperation.Set("/preference", body.Preference),
                    PatchOperation.Add("/dtUpdate", DateTime.UtcNow)
                };

                return await _repo.PatchItem<ProfileModel>(DocumentType.Profile + ":" + userId, new PartitionKey(userId), operations, cancellationToken);
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw new UnhandledException(ex.BuildException());
            }
        }

        //[Function("ProfileViewUpdatePatner")]
        //public async Task<IActionResult> UpdatePatner(
        //   [HttpTrigger(AuthorizationLevel.Function, Method.PUT, Route = "Profile/UpdatePatner")] HttpRequestData req, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        var request = await req.BuildRequestCommand<ProfileUpdatePartnerCommand>(source.Token, false);
        //        request.LoggedUserId = req.GetUserId();

        //        var result = await _mediator.Send(request, source.Token);

        //        return new OkObjectResult(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        req.ProcessException(ex);
        //        throw new UnhandledException(ex.BuildException());
        //    }
        //}
    }
}