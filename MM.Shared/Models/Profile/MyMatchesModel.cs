using MM.Shared.Core.Types;

namespace MM.Shared.Models.Profile;

public class MyMatchesModel(string? id) : MainDocument(new MainIdentity(MainType.Matches, id))
{
    public ISet<PersonModel> Items { get; set; } = new HashSet<PersonModel>();

    protected override object?[] EqualityValues => [Id];
}