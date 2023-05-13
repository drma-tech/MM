using Microsoft.Extensions.Caching.Memory;
using MM.Shared.Models.Profile;

namespace VerusDate.Web.Api
{
    public class InviteApi : ApiServices
    {
        public InviteApi(IHttpClientFactory http, IMemoryCache memoryCache) : base(http, memoryCache)
        {
        }

        public struct InviteEndpoint
        {
            public static string Get(string email) => $"Invite/Get?email={email}";

            public const string Add = "Invite/Add";
            public const string Update = "Invite/Update";
        }

        public async Task<InviteModel?> Invite_Get(string email)
        {
            return await GetAsync<InviteModel>(InviteEndpoint.Get(email), false);
        }

        public async Task<InviteModel?> Invite_Add(InviteModel obj)
        {
            return await PostAsync(InviteEndpoint.Add, false, obj);
        }

        public async Task<InviteModel?> Invite_Update(InviteModel obj)
        {
            return await PutAsync(InviteEndpoint.Update, false, obj);
        }
    }
}