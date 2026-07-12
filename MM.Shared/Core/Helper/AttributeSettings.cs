namespace MM.Shared.Core.Helper;

[Flags]
public enum EnumFields
{
    Group = 1 << 0,
    Name = 1 << 1,
    Placeholder = 1 << 2,
    Description = 1 << 3,
    WhyImportant = 1 << 4,
    Tips = 1 << 5,
}

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class FieldSettingsAttribute(string name) : Attribute
{
    public string Name { get; set; } = name;
    public string? Group { get; set; }
    public string? Placeholder { get; set; }
    public string? Description { get; set; }
    public string? WhyImportant { get; set; }
    public string? Tips { get; set; }
    public Type? ResourceType { get; set; }
}