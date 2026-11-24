using Microsoft.AspNetCore.Components;

namespace MM.WEB.Modules.Common;

public partial class FieldSwitch : FormBase
{
    [Parameter] public bool Value { get; set; }
    [Parameter] public EventCallback<bool> ValueChanged { get; set; }
}