﻿using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;
using System.Resources;

namespace MM.Shared.Core.Helper;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class CustomAttribute : Attribute
{
    public string? Group { get; set; }
    public string? Name { get; set; }
    public string? Placeholder { get; set; }
    public string? Description { get; set; }

    /// <summary>
    ///     Why is it important?
    /// </summary>
    public string? WhyImportant { get; set; }

    /// <summary>
    ///     format: Title 1|Description 1|Title 2|Description 2
    /// </summary>
    public string? Tips { get; set; }

    public Type? ResourceType { get; set; }
}

public static class CustomAttributeHelper
{
    public static CustomAttribute? GetCustomAttribute(this Enum value, bool translate = true)
    {
        var fieldInfo = value.GetType().GetField(value.ToString());

        return fieldInfo?.GetCustomAttribute(translate);
    }

    public static CustomAttribute GetCustomAttribute<T>(this Expression<Func<T>>? expression, bool translate = true)
    {
        if (expression == null) throw new UnhandledException($"{expression} expression is null");

        if (expression.Body is MemberExpression body) return body.Member.GetCustomAttribute(translate);

        var op = ((UnaryExpression)expression.Body).Operand;
        return ((MemberExpression)op).Member.GetCustomAttribute(translate);
    }

    public static CustomAttribute GetCustomAttribute(this MemberInfo mi, bool translate = true)
    {
        if (mi.GetCustomAttribute<CustomAttribute>() is not CustomAttribute attr)
            throw new ValidationException($"Attribute '{mi.Name}' is null");

        if (translate && attr.ResourceType != null) //translations
        {
            var rm = new ResourceManager(attr.ResourceType.FullName ?? "", attr.ResourceType.Assembly);

            if (!string.IsNullOrEmpty(attr.Group))
                attr.Group = rm.GetString(attr.Group) ?? attr.Group + " (incomplete translation)";
            if (!string.IsNullOrEmpty(attr.Name))
                attr.Name = rm.GetString(attr.Name) ?? attr.Name + " (incomplete translation)";
            if (!string.IsNullOrEmpty(attr.Placeholder))
                attr.Placeholder = rm.GetString(attr.Placeholder)?.Replace(@"\n", Environment.NewLine) ??
                                   attr.Placeholder.Replace(@"\n", Environment.NewLine) + " (incomplete translation)";
            if (!string.IsNullOrEmpty(attr.Description))
                attr.Description = rm.GetString(attr.Description) ?? attr.Description + " (incomplete translation)";

            if (!string.IsNullOrEmpty(attr.WhyImportant))
                attr.WhyImportant = rm.GetString(attr.WhyImportant)?.Replace(@"\n", Environment.NewLine) ??
                                    attr.WhyImportant.Replace(@"\n", Environment.NewLine) + " (incomplete translation)";
            if (!string.IsNullOrEmpty(attr.Tips))
                attr.Tips = rm.GetString(attr.Tips) ?? attr.Tips + " (incomplete translation)";
        }

        return attr;
    }

    public static string? GetName(this Enum value, bool translate = true)
    {
        return value.GetCustomAttribute(translate)?.Name;
    }

    public static string GetDescription(this Enum value, bool translate = true)
    {
        return value.GetCustomAttribute(translate)?.Description ??
               throw new UnhandledException($"{value} Description is null");
    }
}
