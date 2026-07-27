using MM.Shared.Core.Types;

namespace MM.Shared.Models.Profile;

public class MyMatchesModel(string? id) : MainDocument(new MainIdentity(MainType.Matches, id))
{
    public HashSet<PersonModel> Items { get; set; } = [];

    public override bool Equals(object? obj)
    {
        return obj is MyMatchesModel q && q.Id == Id;
    }

    public override int GetHashCode()
    {
        return Id?.GetHashCode() ?? 0;
    }
}