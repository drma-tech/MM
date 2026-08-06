using MM.Shared.Models.Profile;

namespace MM.WEB.Modules.Profile
{
    public partial class Validations
    {
        private ValidationModel? Validation { get; set; }
        public RenderControlState<ValidationModel> Actions { get; set; } = new(obj => obj == null);

        protected override async Task LoadAuthenticatedDataAsync(CancellationToken token)
        {
            Actions?.StartLoading?.Invoke(null);

            Validation = await ValidationApi.Get(token);

            Validation ??= new ValidationModel(AppStateStatic.UserId);

            Actions?.FinishLoading?.Invoke(Validation);
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