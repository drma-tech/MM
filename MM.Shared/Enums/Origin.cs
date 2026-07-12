namespace MM.Shared.Enums;

public enum Origin
{
    [FieldSettings("Suggestion")] Suggestion = 1,

    [FieldSettings("Like")] Like = 2,

    [FieldSettings("Match")] Match = 4,

    [FieldSettings("Highlight")] Highlight = 5
}