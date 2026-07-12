using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;
using System.Resources;

namespace MM.Shared.Core.Helper
{
    public class ClassFieldObject(string name)
    {
        public string Name { get; set; } = name;
        public string? Group { get; set; }
        public string? Placeholder { get; set; }
        public string? Description { get; set; }
        public string? WhyImportant { get; set; }
        public string? Tips { get; set; }
    }

    public class EnumFieldObject<T>(string name, T value) : ClassFieldObject(name) where T : Enum
    {
        public T Value { get; set; } = value;
    }

    public static class AttributeHelper
    {
        private static readonly ConcurrentDictionary<(Type, object), FieldSettingsAttribute> AttributesEnum = new();
        private static readonly ConcurrentDictionary<(Type, string), FieldSettingsAttribute> AttributesClass = new();
        private static readonly ConcurrentDictionary<Type, ResourceManager> ResourceManagers = new();

        private const string IncompleteTranslation = " (incomplete translation)";

        public static EnumFieldObject<T> GetFieldSettings<T>(this T value, EnumFields fields, bool accessResources = true) where T : Enum
        {
            var fieldInfo = value.GetType().GetField(value.ToString()) ?? throw new UnhandledException($"{value} field info is null");

            return fieldInfo.GetFieldSettings(value, fields, accessResources);
        }

        public static ClassFieldObject GetFieldSettings<T>(this Expression<Func<T>>? expression, EnumFields fields, bool accessResources = true)
        {
            if (expression == null) throw new UnhandledException($"{expression} expression is null");

            if (expression.Body is MemberExpression body) return body.Member.GetFieldSettings(fields, accessResources);

            var op = ((UnaryExpression)expression.Body).Operand;
            return ((MemberExpression)op).Member.GetFieldSettings(fields, accessResources);
        }

        private static EnumFieldObject<T> GetFieldSettings<T>(this MemberInfo mi, T value, EnumFields fields, bool accessResources = true) where T : Enum
        {
            var key = (typeof(T), value);
            var attr = AttributesEnum.GetOrAdd(key, _ => mi.GetCustomAttribute<FieldSettingsAttribute>() ?? throw new ValidationException($"Field Settings '{mi.Name}' is null"));

            var obj = new EnumFieldObject<T>(attr.Name, value)
            {
                Group = attr.Group,
                Placeholder = attr.Placeholder,
                Description = attr.Description,
                WhyImportant = attr.WhyImportant,
                Tips = attr.Tips
            };

            ApplyTranslations(obj, attr, fields, accessResources);

            return obj;
        }

        private static ClassFieldObject GetFieldSettings(this MemberInfo mi, EnumFields fields, bool accessResources = true)
        {
            var key = (mi.DeclaringType ?? throw new ValidationException($"DeclaringType '{mi.Name}' is null"), mi.Name);
            var attr = AttributesClass.GetOrAdd(key, _ => mi.GetCustomAttribute<FieldSettingsAttribute>() ?? throw new ValidationException($"Field Settings '{mi.Name}' is null"));

            var obj = new ClassFieldObject(attr.Name)
            {
                Group = attr.Group,
                Placeholder = attr.Placeholder,
                Description = attr.Description,
                WhyImportant = attr.WhyImportant,
                Tips = attr.Tips
            };

            ApplyTranslations(obj, attr, fields, accessResources);

            return obj;
        }

        private static void ApplyTranslations(ClassFieldObject obj, FieldSettingsAttribute attr, EnumFields fields, bool accessResources)
        {
            if (fields != 0 && attr.ResourceType != null && accessResources)
            {
                var rm = ResourceManagers.GetOrAdd(attr.ResourceType, t => new ResourceManager(t.FullName!, t.Assembly));

                if ((fields & EnumFields.Name) != 0) obj.Name = rm.GetResourceString(attr.Name) ?? throw new InvalidOperationException($"Resource not found for key: {attr.Name}");
                if ((fields & EnumFields.Group) != 0) obj.Group = rm.GetResourceString(attr.Group);
                if ((fields & EnumFields.Placeholder) != 0) obj.Placeholder = rm.GetResourceString(attr.Placeholder)?.Replace(@"\n", Environment.NewLine) ?? attr.Placeholder?.Replace(@"\n", Environment.NewLine);
                if ((fields & EnumFields.Description) != 0) obj.Description = rm.GetResourceString(attr.Description);
                if ((fields & EnumFields.WhyImportant) != 0) obj.WhyImportant = rm.GetResourceString(attr.WhyImportant)?.Replace(@"\n", Environment.NewLine) ?? attr.WhyImportant?.Replace(@"\n", Environment.NewLine);
                if ((fields & EnumFields.Tips) != 0) obj.Tips = rm.GetResourceString(attr.Tips);
            }
        }

        private static string? GetResourceString(this ResourceManager rm, string? resourceKey)
        {
            if (resourceKey.Empty()) return null;
            return rm.GetString(resourceKey) ?? resourceKey + IncompleteTranslation;
        }
    }
}