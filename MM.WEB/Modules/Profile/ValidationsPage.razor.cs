using MM.Shared.Models.Profile;

namespace MM.WEB.Modules.Profile
{
    public partial class ValidationsPage
    {
        private ValidationModel? Validation { get; set; }
        public RenderControlState<ValidationModel?> State { get; set; } = new(null, obj => obj == null);

        protected override async Task LoadAuthenticatedDataAsync(CancellationToken token)
        {
            State?.StartLoading?.Invoke(null);

            Validation = await ValidationApi.Get([], token);

            Validation ??= new ValidationModel(AppStateStatic.UserId);

            State?.FinishLoading?.Invoke(Validation);
        }

        private async Task GalleryClick()
        {
            Navigation.NavigateTo($"/{Culture}/profile/validation/gallery");
        }

        private async Task IdentityClick()
        {
            if (!AppStateStatic.Principal!.HasSparks(1))
            {
                await ShowWarning("You need at least 1 spark to validate your identity");
                return;
            }

            Navigation.NavigateTo($"/{Culture}/profile/validation/identity");
        }
    }
}