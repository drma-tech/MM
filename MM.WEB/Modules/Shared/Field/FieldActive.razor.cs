using Microsoft.AspNetCore.Components;

namespace MM.WEB.Modules.Shared.Field;

public partial class FieldActive : FormBase<bool, FieldActive>
{
    [Parameter] public bool Value { get; set; }
    [Parameter] public EventCallback<bool> ValueChanged { get; set; }

    [Parameter] public string? CssIcon { get; set; }
    [Parameter] public bool Visible { get; set; } = true;

    [Parameter] public string? CustomButtonText { get; set; }

    private string? Description => For.GetCustomAttribute()?.Description;
}