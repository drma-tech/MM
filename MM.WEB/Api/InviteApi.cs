using Microsoft.Extensions.Caching.Memory;
using MM.Shared.Models.Profile;

namespace MM.WEB.Api
{
    public class InviteApi(IHttpClientFactory http, IMemoryCache memoryCache) : ApiCosmos<InviteModel>(http, memoryCache, "InviteApi")
    {
        public struct InviteEndpoint
        {
            public static string Get(string email) => $"Invite/Get?email={email}";

            public const string Add = "Invite/Add";
            public const string Update = "Invite/Update";
        }

        public async Task<InviteModel?> Invite_Get(string email)
        {
            return await GetAsync(InviteEndpoint.Get(email), null);
        }

        public async Task<InviteModel?> Invite_Add(InviteModel obj)
        {
            return await PostAsync(InviteEndpoint.Add, null, obj);
        }

        public async Task<InviteModel?> Invite_Update(InviteModel obj)
        {
            return await PutAsync(InviteEndpoint.Update, null, obj);
        }
    }
}