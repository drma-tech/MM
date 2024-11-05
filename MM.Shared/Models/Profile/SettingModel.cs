namespace MM.Shared.Models.Profile
{
    public class SettingModel : PrivateMainDocument
    {
        public SettingModel() : base(DocumentType.Setting)
        {
        }

        [Custom(Name = "Blind Date", Description = "Hide all photos, creating an air of mystery until the meeting.")]
        public bool BlindDate { get; set; }

        public override bool HasValidData()
        {
            throw new NotImplementedException();
        }
    }
}