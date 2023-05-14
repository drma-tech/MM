using Microsoft.AspNetCore.Components;
using MM.WEB.Shared.Field;

namespace MM.WEB.Modules.Profile.Component.Field
{
    public partial class FieldText : FormBase<string, FieldText>
    {
        [Parameter] public string? Value { get; set; }
        [Parameter] public EventCallback<string> ValueChanged { get; set; }
        [Parameter] public int Rows { get; set; } = 0;

        [Parameter] public string? CssIcon { get; set; }
        [Parameter] public bool Required { get; set; }
        [Parameter] public bool Visible { get; set; } = true;

        [Parameter] public EventCallback ButtomClicked { get; set; }
        [Parameter] public object? ButtomCssIcon { get; set; }
        [Parameter] public string? ButtomTitle { get; set; }

        private string? Description => For.GetCustomAttribute()?.Description;

        protected override Dictionary<string, object> GetAttributes(string? customStyle)
        {
            var result = base.GetAttributes(customStyle);

            if (Rows > 0)
            {
                result.Add("rows", Rows);
            }

            return result;
        }
    }
}