using MM.Shared.Models.Profile;
using MM.WEB.Shared;

namespace MM.WEB.Modules.Profile.Core
{
    public class EventApi(IHttpClientFactory http) : ApiCosmos<InteractionModel>(http, "event")
    {
        public struct ProfileEndpoint
        {
            public static string Like(Origin origin, string id) => $"event/like/{origin}/{id}";

            public static string Dislike(string id) => $"event/dislike/{id}";
        }

        public async Task<InteractionModel?> Like(Origin origin, string? IdUserView, RenderControlCore<InteractionModel?>? core)
        {
            if (IdUserView == null) return default;

            return await PostAsync(ProfileEndpoint.Like(origin, IdUserView), core, null);
        }

        public async Task<InteractionModel?> Dislike(string? IdUserView, RenderControlCore<InteractionModel?>? core)
        {
            if (IdUserView == null) return default;

            return await PostAsync(ProfileEndpoint.Dislike(IdUserView), core, null);
        }
    }
}