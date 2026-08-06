using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace MM.WEB.Modules.Shared.Field
{
    public partial class Birthdate
    {
        [Parameter] public DateTime? Value { get; set; }
        [Parameter] public EventCallback<DateTime?> ValueChanged { get; set; }

        private int year = DateTime.Now.Year;
        private int month = DateTime.Now.Month;
        private int day = DateTime.Now.Day;

        private static IEnumerable<int> years => Enumerable.Range(DateTime.Now.AddYears(-100).Year, 100).OrderDescending();
        private static IEnumerable<int> months => Enumerable.Range(1, 12);
        private IEnumerable<int> days => Enumerable.Range(1, DateTime.DaysInMonth(year, month));

        protected override void OnInitialized()
        {
            Value ??= DateTime.Today;

            year = Value.Value.Year;
            month = Value.Value.Month;
            day = Value.Value.Day;
        }

        private async Task SetYear(int value)
        {
            year = value;
            await SetValue();
        }

        private async Task SetMonth(int value)
        {
            month = value;
            await SetValue();
        }

        private async Task SetDay(int value)
        {
            day = value;
            await SetValue();
        }

        private async Task SetValue()
        {
            try
            {
                var date = DateTime.Today;

                if (year != default && month != default && day != default)
                {
                    date = new DateTime(year, month, day, 0, 0, 0, DateTimeKind.Local);
                }

                Value = date;
                await ValueChanged.InvokeAsync(Value);
            }
            catch (Exception)
            {
                await ShowError("An error occurred while processing the date");
            }
        }

        protected async Task ShowError(string message)
        {
            if (!message.CanShowSnackbar()) return;

            Snackbar.Add(message, Severity.Error);

            await JsRuntime.Utils().PlayBeep(220, 400, "square", CancellationToken.None);
            await JsRuntime.Utils().Vibrate([200, 100, 200], CancellationToken.None);
        }
    }
}
