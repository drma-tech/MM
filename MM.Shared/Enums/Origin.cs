namespace MM.Shared.Enums;

public enum Origin
{
    [Custom(Name = "Suggestion")] Suggestion = 1,

    [Custom(Name = "Like")] Like = 2,

    [Custom(Name = "Match")] Match = 4,

    [Custom(Name = "Highlight")] Highlight = 5
}