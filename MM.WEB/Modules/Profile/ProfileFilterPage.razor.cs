using MM.Shared.Models.Profile;
using MM.Shared.Models.Profile.Core;
using MudBlazor;
using MudBlazor.Utilities;
using static MM.Shared.Core.Helper.ProfileHelper;

namespace MM.WEB.Modules.Profile
{
    public partial class ProfileFilterPage
    {
        private ProfileModel? Profile { get; set; }
        private FilterModel? Filter { get; set; }
        public RenderControlState<FilterModel?> State { get; set; } = new(null, obj => obj == null);
        private MudDialog? MudDialog { get; set; }

        private Tabs? Tab { get; set; }

        private MudForm? _form;
        private bool IsDirty { get; set; }

        private void OnFieldChanged(FormFieldChangedEventArgs args)
        {
            IsDirty = true;
        }

        public Height[] Heights { get; set; } = [];

        protected override void OnInitialized()
        {
            Heights = EnumHelper.GetValues<Height>();
        }

        private void VisibleChanged(bool value, Tabs? tab)
        {
            if (value)
                Tab = tab;
            else if (Tab == tab)
                Tab = null;
        }

        protected override async Task LoadAuthenticatedDataAsync(CancellationToken token)
        {
            State.StartLoading?.Invoke(null);

            Profile = await ProfileApi.Get(states: [], token);
            Filter = await FilterApi.Get(states: [], token);

            if (Profile == null && AppStateStatic.IsAuthenticated)
            {
                State.ShowError?.Invoke(Translations.Module.Profile.ProfileNotFound);
            }

            if (Filter == null && AppStateStatic.IsAuthenticated)
            {
                Filter = new FilterModel(AppStateStatic.UserId);

                var confirmed = await DialogService.ShowMessageBoxAsync("Modern Matchmaker", Translations.Module.Profile.ITrustPlataform, Translations.Button.Ok, Translations.Button.Cancel) ?? false;

                if (!confirmed)
                {
                    Navigation.NavigateTo($"/{Culture}/profile");
                    return;
                }

                await PopulateFields(forceReset: false);
            }

            State?.FinishLoading?.Invoke(Filter);
        }

        private async Task SaveHandle()
        {
            if (Filter == null) throw new InvalidOperationException("profile is null");

            try
            {
                var validator = new FilterValidation();

                var result = await validator.ValidateAsync(Filter, Cts.Token);

                if (result.IsValid)
                {
                    State.StartProcessing?.Invoke(null);
                    Filter = await FilterApi.Update(Filter, Cts.Token);
                    State.FinishProcessing?.Invoke(Filter);

                    IsDirty = false; StateHasChanged();

                    Navigation.NavigateTo($"/{Culture}/profile");
                }
                else
                {
                    await ShowWarning(result.Errors[0].ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                await ProcessException(ex);
            }
        }
    }
}