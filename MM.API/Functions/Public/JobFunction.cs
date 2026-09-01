using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using MM.Shared.Core.Types;
using MM.Shared.Models.Auth;
using MM.Shared.Models.Job;

namespace MM.API.Functions.Public;

public class JobFunction(CosmosMainRepository repoMain, CosmosJobRepository repoJob, IHttpClientFactory factory)
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
        var jobs = await repoJob.Query<GoPublicModel>(JobType.GoPublic, job => job.RunAt <= DateTimeOffset.UtcNow, transform: null, cancellationToken);
        var zepto = new ZeptoMailClient(factory, ApiStartup.Configurations.ZeptoMail!.JobApiKey!);

        foreach (var job in jobs)
        {
            var userId = job.Identity.RawId;

            var principal = await repoMain.ReadItemAsync<AuthPrincipal>(new MainIdentity(MainType.Principal, userId), cancellationToken);

            //principal may no longer exist.
            if (principal != null && !principal.PublicProfile && job.Email.NotEmpty())
            {
                await zepto.SendGoPublicEmail(job.Email, userId!, cancellationToken);
            }

            await repoJob.DeleteItemAsync<GoPublicModel>(new JobIdentity(JobType.GoPublic, job.Id));
        }
    }
}