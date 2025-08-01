﻿using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;

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
    [Parameter] public string? CssIcon { get; set; }
    [Parameter] public bool Disabled { get; set; }
    [Parameter] public Expression<Func<TValue>>? For { get; set; }

    public string Label => " " + For?.GetCustomAttribute()?.Name;
}