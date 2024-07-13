﻿namespace MM.Shared.Core.Helper
{
    public static class EnumHelper
    {
        public static TEnum[] GetArray<TEnum>() where TEnum : struct, Enum
        {
            return Enum.GetValues<TEnum>();
        }

        public static EnumObject[] GetObjArray<TEnum>(bool translate = true) where TEnum : struct, Enum
        {
            return GetList<TEnum>(translate).ToArray();
        }

        public static IEnumerable<EnumObject> GetList<TEnum>(bool translate = true) where TEnum : struct, Enum
        {
            foreach (var val in GetArray<TEnum>())
            {
                var attr = val.GetCustomAttribute(translate);

                yield return new EnumObject(val, attr?.Name, attr?.Description, attr?.Group, attr?.Prompt, attr?.FieldInfo, attr?.Tips);
            }
        }
    }

    public class EnumObject(Enum value, string? name, string? description, string? group, string? prompt, string? fieldInfo, string? tips)
    {
        public Enum Value { get; set; } = value;
        public string? Name { get; set; } = name;
        public string? Description { get; set; } = description;
        public string? Group { get; set; } = group;
        public string? Prompt { get; set; } = prompt;
        public string? FieldInfo { get; set; } = fieldInfo;
        public string? Tips { get; set; } = tips;
    }
}