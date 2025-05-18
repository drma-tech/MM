using System.Linq.Expressions;
using Blazorise;
using Microsoft.AspNetCore.Components;

namespace MM.WEB.Modules.Shared.Field;

public enum FieldType
{
    TextEdit,
    TextEditButtom,
    Date,
    MemoEdit,
    Select,
    SelectMultiple
}

public class BaseCustomField<TValue, TClass> : ComponentCore<TClass> where TClass : class
{
    [Parameter] public FieldType Type { get; set; }
    [Parameter] public object? CssIcon { get; set; }
    [Parameter] public bool Disabled { get; set; }
    [Parameter] public Expression<Func<TValue>>? For { get; set; }
    [Parameter] public LabelSize LabelSize { get; set; } = LabelSize.Normal;

    public string Label => " " + For?.GetCustomAttribute()?.Name;

    public IFluentColumn GetLabelSize()
    {
        return LabelSize switch
        {
            LabelSize.Short => ColumnSize.IsFull.OnWidescreen.Is3.OnFullHD,
            LabelSize.Normal => ColumnSize.IsFull.OnWidescreen.Is4.OnFullHD,
            LabelSize.Big => ColumnSize.IsFull.OnWidescreen.Is5.OnFullHD,
            _ => ColumnSize.IsFull.OnWidescreen.Is4.OnFullHD
        };
    }

    public IFluentColumn GetBodySize()
    {
        return LabelSize switch
        {
            LabelSize.Short => ColumnSize.IsFull.OnWidescreen.Is9.OnFullHD,
            LabelSize.Normal => ColumnSize.IsFull.OnWidescreen.Is8.OnFullHD,
            LabelSize.Big => ColumnSize.IsFull.OnWidescreen.Is7.OnFullHD,
            _ => ColumnSize.IsFull.OnWidescreen.Is8.OnFullHD
        };
    }
}