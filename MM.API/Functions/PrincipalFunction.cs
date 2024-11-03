using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using MM.Shared.Models.Auth;

namespace MM.API.Functions
{
    public class PrincipalFunction(CosmosRepository repo)
    {
        //[OpenApiOperation("PrincipalGet", "Azure (Cosmos DB)")]
        //[OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(ClientePrincipal))]
        [Function("PrincipalGet")]
        public async Task<ClientePrincipal?> PrincipalGet(
           [HttpTrigger(AuthorizationLevel.Anonymous, Method.GET, Route = "Principal/Get")] HttpRequestData req, CancellationToken cancellationToken)
        {
            try
            {
                var userId = req.GetUserId();

                return await repo.Get<ClientePrincipal>(DocumentType.Principal, userId, cancellationToken);
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw new UnhandledException(ex.BuildException());
            }
        }

        [Function("PrincipalGetEmail")]
        public async Task<string?> PrincipalGetEmail(
          [HttpTrigger(AuthorizationLevel.Anonymous, Method.GET, Route = "Public/Principal/GetEmail")] HttpRequestData req, CancellationToken cancellationToken)
        {
            try
            {
                var token = req.GetQueryParameters()["token"];

                var principal = await repo.Get<ClientePrincipal>(DocumentType.Principal, token, cancellationToken);
                return principal?.Email;
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw new UnhandledException(ex.BuildException());
            }
        }

        //[OpenApiOperation("PrincipalAdd", "Azure (Cosmos DB)")]
        //[OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(ClientePrincipal))]
        [Function("PrincipalAdd")]
        public async Task<ClientePrincipal?> PrincipalAdd(
            [HttpTrigger(AuthorizationLevel.Anonymous, Method.POST, Route = "Principal/Add")] HttpRequestData req, CancellationToken cancellationToken)
        {
            try
            {
                var body = await req.GetBody<ClientePrincipal>(cancellationToken);

                return await repo.Upsert(body, cancellationToken);
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw new UnhandledException(ex.BuildException());
            }
        }

        [Function("PrincipalPaddle")]
        public async Task<ClientePrincipal> PrincipalPaddle(
           [HttpTrigger(AuthorizationLevel.Anonymous, Method.PUT, Route = "Principal/Paddle")] HttpRequestData req, CancellationToken cancellationToken)
        {
            try
            {
                var userId = req.GetUserId();

                var Client = await repo.Get<ClientePrincipal>(DocumentType.Principal, userId, cancellationToken) ?? throw new NotificationException("Client null");
                var body = await req.GetBody<ClientePrincipal>(cancellationToken);

                Client.ClientePaddle = body.ClientePaddle;

                return await repo.Upsert(Client, cancellationToken);
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw new UnhandledException(ex.BuildException());
            }
        }

        [Function("PrincipalRemove")]
        public async Task PrincipalRemove(
           [HttpTrigger(AuthorizationLevel.Anonymous, Method.DELETE, Route = "Principal/Remove")] HttpRequestData req, CancellationToken cancellationToken)
        {
            try
            {
                var userId = req.GetUserId();

                var myPrincipal = await repo.Get<ClientePrincipal>(DocumentType.Principal, userId, cancellationToken);
                if (myPrincipal != null) await repo.Delete(myPrincipal, cancellationToken);

                //var myProviders = await repo.Get<MyProviders>(DocumentType.MyProvider, userId, cancellationToken);
                //if (myProviders != null) await repo.Delete(myProviders, cancellationToken);

                var myLogins = await repo.Get<ClienteLogin>(DocumentType.Login, userId, cancellationToken);
                if (myLogins != null) await repo.Delete(myLogins, cancellationToken);

                //var mySuggestions = await repo.Get<MySuggestions>(DocumentType.MySuggestions, userId, cancellationToken);
                //if (mySuggestions != null) await repo.Delete(mySuggestions, cancellationToken);

                //var myWatched = await repo.Get<WatchedList>(DocumentType.WatchedList, userId, cancellationToken);
                //if (myWatched != null) await repo.Delete(myWatched, cancellationToken);

                //var myWatching = await repo.Get<WatchingList>(DocumentType.WatchingList, userId, cancellationToken);
                //if (myWatching != null) await repo.Delete(myWatching, cancellationToken);

                //var myWish = await repo.Get<WishList>(DocumentType.WishList, userId, cancellationToken);
                //if (myWish != null) await repo.Delete(myWish, cancellationToken);
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw new UnhandledException(ex.BuildException());
            }
        }
    }
}