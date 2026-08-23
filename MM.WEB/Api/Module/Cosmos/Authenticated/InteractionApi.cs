using MM.Shared.Models.Profile;
using MM.WEB.Api.Core;

namespace MM.WEB.Api.Module.Cosmos.Authenticated;

public class InteractionApi(IHttpClientFactory http) : ApiCosmos<InteractionModel>(http, ApiType.Authenticated, "interaction", [], ApiContext.Default.InteractionModel)
{
    public async Task<InteractionModel?> GetInteraction(string? IdUserView, CancellationToken cancellationToken)
    {
        if (IdUserView == null) return default;

        return await GetAsync($"interaction/get/{IdUserView}", setNewVersion: false, states: [], cancellationToken);
    }

    public async Task<InteractionModel?> Like(Origin origin, string? IdUserView, CancellationToken cancellationToken)
    {
        if (IdUserView == null) return default;

        return await PostAsync($"interaction/like/{(int)origin}/{IdUserView}", null, states: [], cancellationToken);
    }

    public async Task<InteractionModel?> Dislike(Origin origin, string? IdUserView, CancellationToken cancellationToken)
    {
        if (IdUserView == null) return default;

        return await PostAsync($"interaction/dislike/{(int)origin}/{IdUserView}", null, states: [], cancellationToken);
    }
}