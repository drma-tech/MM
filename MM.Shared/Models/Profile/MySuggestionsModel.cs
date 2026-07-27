using MM.Shared.Core.Types;

namespace MM.Shared.Models.Profile;

public class MySuggestionsModel(string? id) : MainDocument(new MainIdentity(MainType.Suggestions, id))
{
    public HashSet<PersonModel> Items { get; set; } = [];

    public override bool Equals(object? obj)
    {
        return obj is MySuggestionsModel q && q.Id == Id;
    }

    public override int GetHashCode()
    {
        return Id?.GetHashCode() ?? 0;
    }
}