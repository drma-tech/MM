using MM.Shared.Translations.Model;

namespace MM.Shared.Models.Profile;

public class SettingModel : PrivateMainDocument
{
    public SettingModel() : base(DocumentType.Setting)
    {
    }

    [FieldSettings("BlindDate", Description = "BlindDateDesc", ResourceType = typeof(ProfileSetting))]
    public bool BlindDate { get; set; }
}