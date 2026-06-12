using MM.Shared.Models.Profile;

namespace MM.WEB.Modules.Profile.Core;

public class InteractionApi(IHttpClientFactory http) : ApiCosmos<InteractionModel>(http, ApiType.Authenticated, "interaction", ApiContext.Default.InteractionModel)
{
    public async Task<InteractionModel?> GetInteraction(string? IdUserView, CancellationToken cancellationToken)
    {
        if (IdUserView == null) return default;

        return await GetAsync(ProfileEndpoint.GetInteraction(IdUserView), false, null, cancellationToken);
    }

    public async Task<InteractionModel?> Like(Origin origin, string? IdUserView, CancellationToken cancellationToken)
    {
        if (IdUserView == null) return default;

        return await PostAsync(ProfileEndpoint.Like(origin, IdUserView), null, cancellationToken);
    }

    public async Task<InteractionModel?> Dislike(Origin origin, string? IdUserView, CancellationToken cancellationToken)
    {
        if (IdUserView == null) return default;

        return await PostAsync(ProfileEndpoint.Dislike(origin, IdUserView), null, cancellationToken);
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