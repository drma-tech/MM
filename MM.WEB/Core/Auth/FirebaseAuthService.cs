using Microsoft.JSInterop;

namespace MM.WEB.Core.Auth
{
    public class FirebaseAuthService(IJSRuntime js)
    {
        public async Task SignInAsync(string provider)
        {
            ApiCore.ResetCacheVersion();
            await js.InvokeVoidAsync("firebaseAuth.signIn", provider);
        }

        public async Task SignOutAsync()
        {
            await js.InvokeVoidAsync("firebaseAuth.signOut");
        }
    }
}
