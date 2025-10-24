using MM.Shared.Models.Profile;
using MM.WEB.Shared;

namespace MM.WEB.Modules.Profile.Core;

public class InteractionApi(IHttpClientFactory http) : ApiCosmos<InteractionModel>(http, ApiType.Authenticated, "interaction")
{
    public async Task<InteractionModel?> GetInteraction(string? IdUserView, RenderControlCore<InteractionModel?>? core)
    {
        if (IdUserView == null) return default;

        return await GetAsync(ProfileEndpoint.GetInteraction(IdUserView), core);
    }

    public async Task<InteractionModel?> Like(Origin origin, string? IdUserView,
        RenderControlCore<InteractionModel?>? core)
    {
        if (IdUserView == null) return default;

        return await PostAsync(ProfileEndpoint.Like(origin, IdUserView), core, null);
    }

    public async Task<InteractionModel?> Dislike(Origin origin, string? IdUserView,
        RenderControlCore<InteractionModel?>? core)
    {
        if (IdUserView == null) return default;

        return await PostAsync(ProfileEndpoint.Dislike(origin, IdUserView), core, null);
    }

    public struct ProfileEndpoint
    {
        public static string GetInteraction(string id)
        {
            return $"interaction/get/{id}";
        }

        public static string Like(Origin origin, string id)
        {
            return $"interaction/like/{(int)origin}/{id}";
        }

        public static string Dislike(Origin origin, string id)
        {
            return $"interaction/dislike/{(int)origin}/{id}";
        }
    }
}