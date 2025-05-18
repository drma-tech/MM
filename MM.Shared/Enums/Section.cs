namespace MM.Shared.Enums;

public enum Section
{
    [Custom(Name = "Basic", ResourceType = typeof(Resources.Section))]
    Basic,

    [Custom(Name = "Bio", ResourceType = typeof(Resources.Section))]
    Bio,

    [Custom(Name = "Lifestyle", ResourceType = typeof(Resources.Section))]
    Lifestyle,

    [Custom(Name = "Personality", ResourceType = typeof(Resources.Section))]
    Personality,

    [Custom(Name = "Interest", ResourceType = typeof(Resources.Section))]
    Interest,

    [Custom(Name = "Relationship", ResourceType = typeof(Resources.Section))]
    Relationship,

    [Custom(Name = "Goals", ResourceType = typeof(Resources.Section))]
    Goals
}