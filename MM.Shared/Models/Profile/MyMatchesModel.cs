using MM.Shared.Core.Types;

namespace MM.Shared.Models.Profile;

public class MyMatchesModel(string? id) : MainDocument(new MainIdentity(MainType.Matches, id))
{
    public IList<PersonModel> Items { get; set; } = [];

    protected override object?[] EqualityValues => [Id];
}