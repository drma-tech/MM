using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace VerusDate.Api.Function
{
    public class SignalRFunction
    {
        // This will manage connections to SignalR
        [Function("negotiate")]
        public static SignalRConnectionInfo GetSignalRInfo(
            [HttpTrigger(AuthorizationLevel.Anonymous, Method.POST)] HttpRequestData req,
            [SignalRConnectionInfo(HubName = "chatHub")] SignalRConnectionInfo connectionInfo)
        {
            return connectionInfo;
        }

        //Send the messages!
        [Function("messages")]
        public static Task SendMessage(
            [HttpTrigger(AuthorizationLevel.Anonymous, Method.POST)] ChatModel chat,
            [SignalR(HubName = "chatHub")] IAsyncCollector<SignalRMessage> signalRMessages)
        {
            return signalRMessages.AddAsync(
                new SignalRMessage
                {
                    Target = chat.Id,
                    Arguments = new[] { chat }
                });
        }
    }
}