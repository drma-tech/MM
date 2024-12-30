using MM.Shared.Requests;

namespace MM.WEB.Modules.Profile.Core
{
    public class InviteApi(IHttpClientFactory http) : ApiCosmos<InviteRequest>(http, "invite")
    {
        public struct ProfileEndpoint
        {
            public const string SendInvite = "profile/send-invite";
        }

        public async Task SendInvite(InviteRequest request)
        {
            await PostAsync(ProfileEndpoint.SendInvite, null, request);
        }
    }
}