namespace MM.Shared.Models.Profile;

public class SettingModel : PrivateMainDocument
{
    public SettingModel() : base(DocumentType.Setting)
    {
    }

    public bool BlindDate { get; set; }
}