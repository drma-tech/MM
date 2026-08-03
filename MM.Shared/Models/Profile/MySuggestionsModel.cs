using MM.Shared.Core.Types;

namespace MM.Shared.Models.Profile;

public class MySuggestionsModel(string? id) : MainDocument(new MainIdentity(MainType.Suggestions, id))
{
    public ISet<PersonModel> Items { get; set; } = new HashSet<PersonModel>();

    protected override object?[] EqualityValues => [Id];
}