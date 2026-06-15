using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using MM.Shared.Models.Auth;
using MM.Shared.Models.Job;

namespace MM.API.Functions;

public class JobFunction(CosmosJobRepository repo, CosmosRepository repoMain)
{
    [Function("GoPublic")]
    public async Task GoPublic([HttpTrigger(AuthorizationLevel.Anonymous, Method.Post, Route = "job/gopublic")] HttpRequestData req, CancellationToken cancellationToken)
    {
        var jobs = await repo.Query<GoPublicModel>(job => job.RunAt <= DateTimeOffset.UtcNow, JobType.GoPublic, cancellationToken);
        var zepto = new ZeptoMailClient(ApiStartup.Configurations.ZeptoMail!.JobApiKey!);

        foreach (var job in jobs)
        {
            var userId = job.Id.Split(":")[1];

            var principal = await repoMain.Get<AuthPrincipal>(DocumentType.Principal, userId, cancellationToken);

            if (!principal!.PublicProfile && job.Email.NotEmpty())
            {
                await zepto.SendGoPublicEmail(job.Email, userId, cancellationToken);
            }

            await repo.Delete(job, cancellationToken);
        }
    }
}