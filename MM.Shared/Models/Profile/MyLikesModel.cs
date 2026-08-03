using MM.Shared.Core.Types;

namespace MM.Shared.Models.Profile;

public class MyLikesModel(string? id) : MainDocument(new MainIdentity(MainType.Likes, id))
{
    public IList<PersonModel> Items { get; set; } = [];

    protected override object?[] EqualityValues => [Id];
}