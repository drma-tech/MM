namespace MM.Shared.Enums;

public enum SharedFinances
{
    [FieldSettings("JointAccounts", Description = "JointAccounts_Description", ResourceType = typeof(Translations.Enum.SharedFinances))]
    JointAccounts = 1,

    [FieldSettings("SeparateAccounts", Description = "SeparateAccounts_Description", ResourceType = typeof(Translations.Enum.SharedFinances))]
    SeparateAccounts = 2,

    [FieldSettings("HybridApproach", Description = "HybridApproach_Description", ResourceType = typeof(Translations.Enum.SharedFinances))]
    HybridApproach = 3
}