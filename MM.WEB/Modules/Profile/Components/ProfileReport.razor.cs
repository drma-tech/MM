using MudBlazor;

namespace MM.WEB.Modules.Profile.Components
{
    public partial class ProfileReport
    {
        private MudDialog? modal;
        private int checkedValue = 1;

        public async Task ShowModal()
        {
            await modal?.ShowAsync("Report Profile");
        }

        private void OnCheckedValueChanged(int value)
        {
            checkedValue = value;
        }

        private async Task Confirmar()
        {
            //report

            //delete match

            await modal!.CloseAsync();
        }
    }
}