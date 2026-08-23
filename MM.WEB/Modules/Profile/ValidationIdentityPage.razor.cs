namespace MM.WEB.Modules.Profile
{
    public partial class ValidationIdentityPage
    {
        protected override async Task LoadAuthenticatedDataAsync(CancellationToken token)
        {
            if (AppStateStatic.Principal == null)
            {
                await ShowWarning("Invalid operation");
                Navigation.NavigateTo($"/{Culture}/profile");
                return;
            }

            if (!AppStateStatic.Principal.HasSparks(1))
            {
                await ShowWarning("You need at least 1 spark to validate your identity");
                return;
            }

            var email = AppStateStatic.User?.Claims.SingleOrDefault(c => string.Equals(c.Type, "email", StringComparison.Ordinal))?.Value;
            var url = await ValidationApi.CreateVerificationSession($"{Navigation.BaseUri}{Culture}/profile", email, token);
            Navigation.NavigateTo(url!);
        }
    }
}