using MM.Shared.Core.Types;

namespace MM.Shared.Models.Profile;

public class MyLikesModel(string? id) : MainDocument(new MainIdentity(MainType.Likes, id))
{
    public HashSet<PersonModel> Items { get; set; } = [];

    public override bool Equals(object? obj)
    {
        return obj is MyLikesModel q && q.Id == Id;
    }

    public override int GetHashCode()
    {
        return Id?.GetHashCode() ?? 0;
    }
}