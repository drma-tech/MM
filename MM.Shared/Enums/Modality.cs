namespace MM.Shared.Enums
{
    public enum Modality
    {
        [Custom(Name = "Matchmaker_Name", Description = "Matchmaker_Description", ResourceType = typeof(Resources.Modality))]
        Matchmaker = 1,

        [Custom(Name = "RelationshipAnalysis_Name", Description = "RelationshipAnalysis_Description", ResourceType = typeof(Resources.Modality))]
        RelationshipAnalysis = 2
    }
}