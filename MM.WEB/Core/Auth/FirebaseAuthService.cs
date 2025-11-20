using Microsoft.JSInterop;

namespace MM.WEB.Core.Auth
{
    public class FirebaseAuthService(IJSRuntime js)
    {
        public async Task<string?> SignInAsync(string provider)
        {
            ApiCore.ResetCacheVersion();
            return await js.InvokeAsync<string?>("firebaseAuth.signIn", provider);
        }

        public async Task SignOutAsync()
        {
            await js.InvokeVoidAsync("firebaseAuth.signOut");
        }
    }
}