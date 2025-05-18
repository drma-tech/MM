namespace MM.Shared.Models.Profile;

public class MyLikesModel : PrivateMainDocument
{
    public MyLikesModel() : base(DocumentType.Likes)
    {
    }

    public HashSet<PersonModel> Items { get; set; } = [];

    public override bool HasValidData()
    {
        return Items.Count != 0;
    }

    public override bool Equals(object? obj)
    {
        return obj is MyLikesModel q && q.Id == Id;
    }

    public override int GetHashCode()
    {
        return Id?.GetHashCode() ?? 0;
    }
}