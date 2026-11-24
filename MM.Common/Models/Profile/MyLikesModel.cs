using MM.Common.Core.Types;

namespace MM.Common.Models.Profile;

public class MyLikesModel(string? id) : MainDocument(new MainIdentity(MainType.Likes, id))
{
    public ISet<PersonModel> Items { get; set; } = new HashSet<PersonModel>();

    protected override object?[] EqualityValues => [Id];
}