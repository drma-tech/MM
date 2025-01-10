using MM.Shared.Models.Profile;
using MM.WEB.Shared;

namespace MM.WEB.Modules.Profile.Core
{
    public class InteractionApi(IHttpClientFactory http) : ApiCosmos<InteractionModel>(http, "profile-interaction")
    {
        public struct ProfileEndpoint
        {
            public static string GetInteraction(string id) => $"profile/get-interaction/{id}";
        }

        public async Task<InteractionModel?> GetInteraction(string? IdUserView, RenderControlCore<InteractionModel?>? core)
        {
            if (IdUserView == null) return default;

            return await GetAsync(ProfileEndpoint.GetInteraction(IdUserView), core);
        }
    }
}