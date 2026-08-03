using MM.Shared.Core.Types;

namespace MM.Shared.Models.Profile;

public class MySuggestionsModel(string? id) : MainDocument(new MainIdentity(MainType.Suggestions, id))
{
    public IList<PersonModel> Items { get; set; } = [];

    protected override object?[] EqualityValues => [Id];
}