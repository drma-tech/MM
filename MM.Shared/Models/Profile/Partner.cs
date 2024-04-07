using System.ComponentModel.DataAnnotations;

namespace MM.Shared.Models.Profile
{
    public class Partner
    {
        [Required]
        [EmailAddress]
        [Custom(Name = "Email_Name", Prompt = "Email_Prompt", Description = "Email_Description", ResourceType = typeof(Resources.ProfileMyRelationship))]
        public string? Email { get; set; }

        public string? Id { get; set; }
    }
}