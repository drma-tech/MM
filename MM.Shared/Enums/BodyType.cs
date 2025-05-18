namespace MM.Shared.Enums;

public enum BodyType
{
    [Custom(Name = "Slim", ResourceType = typeof(Resources.BodyType))]
    Slim = 1,

    [Custom(Name = "Average", ResourceType = typeof(Resources.BodyType))]
    Average = 2,

    [Custom(Name = "Athletic", ResourceType = typeof(Resources.BodyType))]
    Athletic = 3,

    [Custom(Name = "Curvy", ResourceType = typeof(Resources.BodyType))]
    Curvy = 4,

    [Custom(Name = "Heavyset", ResourceType = typeof(Resources.BodyType))]
    Heavyset = 5
}