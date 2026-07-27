using MM.Shared.Core.Types;

namespace MM.Shared.Models.Profile;

public class SettingModel(string? id) : MainDocument(new MainIdentity(MainType.Setting, id))
{
    public bool BlindDate { get; set; }
}