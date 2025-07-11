﻿using System.Linq.Expressions;
using Blazorise;
using Microsoft.AspNetCore.Components;

namespace MM.WEB.Modules.Shared.Field;

public enum LabelSize
{
    Short,
    Normal,
    Big
}

public class FormBase<TValue, TClass> : ComponentCore<TClass> where TClass : class
{
    [Parameter] public Expression<Func<TValue>>? For { get; set; }
    [Parameter] public bool Disabled { get; set; }
    [Parameter] public LabelSize LabelSize { get; set; } = LabelSize.Normal;

    protected virtual Dictionary<string, object> GetAttributes(string? customStyle)
    {
        var dic = new Dictionary<string, object> { { "class", "form-control" } };

        if (Disabled)
        {
            dic.Add("disabled", "disabled");
            dic.Add("style", "background-color: #e9ecef; opacity: 1;" + customStyle);
        }
        else
        {
            if (!string.IsNullOrEmpty(customStyle)) dic.Add("style", customStyle);
        }

        dic.Add("placeholder", For?.GetCustomAttribute()?.Placeholder ?? "");

        return dic;
    }

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