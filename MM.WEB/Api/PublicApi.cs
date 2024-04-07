using Blazored.SessionStorage;
using MM.Shared.ModelQuery;
using MM.WEB.Core;

namespace VerusDate.Web.Api
{
    public struct PublicEndpoint
    {
        public const string ListDestaques = "Public/ListDestaques";
    }

    public static class PublicApi
    {
        public static async Task<List<ProfileSearch>> Public_ListDestaques(this HttpClient http, ISyncSessionStorageService storage)
        {
            return await http.GetList<ProfileSearch>(PublicEndpoint.ListDestaques, storage);
        }
    }
}