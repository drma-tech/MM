namespace MM.Shared.Models.Profile;

public class SettingModel : PrivateMainDocument
{
    public SettingModel() : base(DocumentType.Setting)
    {
    }

    [Custom(Name = "BlindDate", Description = "BlindDateDesc", ResourceType = typeof(Profile.Resources.ProfileSetting))]
    public bool BlindDate { get; set; }
}