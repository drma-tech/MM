namespace MM.Shared.Enums
{
    public enum FamilyApproval
    {
        [Custom(Name = "No", Description = "The family does not influence or participate in partner decisions.")]
        No = 1,

        [Custom(Name = "Yes (Partially)", Description = "The family has some influence or provides input, but the final decision is shared.")]
        YesModerate = 3,

        [Custom(Name = "Yes (Fully)", Description = "The family has significant influence or makes the final decision regarding the partner.")]
        YesHeavy = 4
    }
}