using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using MM.Shared.Models.Auth;
using MM.Shared.Models.Job;

namespace MM.API.Functions;

public class JobFunction(CosmosRepository repoMain, CosmosJobRepository repoJob)
{
    //[Function("GoPublicTransfer")]
    //public async Task GoPublicTransfer([HttpTrigger(AuthorizationLevel.Anonymous, Method.Post, Route = "job/gopublic-transfer")] HttpRequestData req, CancellationToken cancellationToken)
    //{
    //    var users = await repoMain.Query<AuthPrincipal>(job => job.PublicProfile == false, DocumentType.Principal, cancellationToken);

    //    var hour = 0;
    //    foreach (var user in users)
    //    {
    //        hour++;

    //        var job = new GoPublicModel
    //        {
    //            RunAt = DateTimeOffset.UtcNow.AddHours(hour),
    //            Email = user.Email
    //        };
    //        job.Initialize(user.UserId);

    //        await repoJob.CreateItemAsync(job, cancellationToken);
    //    }
    //}

    [Function("GoPublic")]
    public async Task GoPublic([HttpTrigger(AuthorizationLevel.Anonymous, Method.Post, Route = "job/gopublic")] HttpRequestData req, CancellationToken cancellationToken)
    {
        var jobs = await repoJob.Query<GoPublicModel>(job => job.RunAt <= DateTimeOffset.UtcNow, JobType.GoPublic, cancellationToken);
        var zepto = new ZeptoMailClient(ApiStartup.Configurations.ZeptoMail!.JobApiKey!);

        foreach (var job in jobs)
        {
            var userId = job.Id.Split(":")[1];

            var principal = await repoMain.Get<AuthPrincipal>(DocumentType.Principal, userId, cancellationToken);

            if (!principal!.PublicProfile && job.Email.NotEmpty())
            {
                await zepto.SendGoPublicEmail(job.Email, userId, cancellationToken);
            }

            await repoJob.Delete(job, cancellationToken);
        }
    }
}