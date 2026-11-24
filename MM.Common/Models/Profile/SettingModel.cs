using MM.Common.Core.Types;

namespace MM.Common.Models.Profile;

public class SettingModel(string? id) : MainDocument(new MainIdentity(MainType.Setting, id))
{
    public bool BlindDate { get; set; }

    protected override object?[] EqualityValues => [Id];
}