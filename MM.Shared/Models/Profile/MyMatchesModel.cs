namespace MM.Shared.Models.Profile;

public class MyMatchesModel : PrivateMainDocument
{
    public MyMatchesModel() : base(DocumentType.Matches)
    {
    }

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