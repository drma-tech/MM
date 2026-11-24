using MM.Common.Core.Types;

namespace MM.Common.Models.Profile;

public class MyMatchesModel(string? id) : MainDocument(new MainIdentity(MainType.Matches, id))
{
    public ISet<PersonModel> Items { get; set; } = new HashSet<PersonModel>();

    protected override object?[] EqualityValues => [Id];
}