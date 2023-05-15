using Microsoft.AspNetCore.Components.Authorization;

namespace MM.WEB.Core
{
    public class AppState
    {
        #region USER SESSION

        protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        public AppState(AuthenticationStateProvider authenticationStateProvider)
        {
            AuthenticationStateProvider = authenticationStateProvider;
        }

        public async Task<bool> IsUserAuthenticated(AuthenticationState? authState = null)
        {
            authState ??= await AuthenticationStateProvider.GetAuthenticationStateAsync();

            return authState.User.Identity != null && authState.User.Identity.IsAuthenticated;
        }

        public async Task<string?> GetIdUser(AuthenticationState? authState = null)
        {
            authState ??= await AuthenticationStateProvider.GetAuthenticationStateAsync();

            return authState.User.FindFirst(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        }

        #endregion USER SESSION
    }
}