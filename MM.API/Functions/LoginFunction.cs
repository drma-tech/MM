using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using MM.Shared.Models.Auth;
using System.Net;

namespace MM.API.Functions;

public class LoginFunction(CosmosRepository repo)
{
    [Function("LoginAdd")]
    public async Task LoginAdd(
        [HttpTrigger(AuthorizationLevel.Anonymous, Method.Post, Route = "login/add")]
        HttpRequestData req, CancellationToken cancellationToken)
    {
        try
        {
            var platform = req.GetQueryParameters()["platform"] ?? "webapp";
            var ip = req.GetQueryParameters()["ip"] ?? "null ip";
            var userId = req.GetUserId();
            if (string.IsNullOrEmpty(userId)) throw new InvalidOperationException("unauthenticated user");
            var login = await repo.Get<ClienteLogin>(DocumentType.Login, userId, cancellationToken);

            if (login == null)
            {
                var newLogin = new ClienteLogin
                {
                    UserId = userId,
                    Accesses = [new Access { Date = DateTimeOffset.Now, Platform = platform, Ip = ip }]
                };
                newLogin.Initialize(userId);

                await repo.Upsert(newLogin, cancellationToken);
            }
            else
            {
                login.Accesses = login.Accesses
                    .Union([new Access { Date = DateTimeOffset.Now, Platform = platform, Ip = ip }]).ToArray();

                await repo.Upsert(login, cancellationToken);
            }
        }
        catch (Exception ex)
        {
            req.ProcessException(ex);
            throw;
        }
    }

    [Function("Test")]
    public static HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "public/test")] HttpRequestData req)
    {
        var response = req.CreateResponse(HttpStatusCode.OK);
        response.WriteString("OK");
        return response;
    }
}
