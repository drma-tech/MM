namespace MM.Shared.Models.Profile;

public class SettingModel : PrivateMainDocument
{
    public SettingModel() : base(DocumentType.Setting)
    {
    }

    [Custom(Name = "Blind Date", Description = "Hide all photos (yours and theirs), creating an air of mystery until the meeting.")]
    public bool BlindDate { get; set; }
}