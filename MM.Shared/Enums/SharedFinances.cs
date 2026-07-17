namespace MM.Shared.Enums;

public enum SharedFinances
{
    [FieldSettings(nameof(Translations.Enum.SharedFinances.JointAccounts), Description = nameof(Translations.Enum.SharedFinances.JointAccounts_Description), ResourceType = typeof(Translations.Enum.SharedFinances))]
    JointAccounts = 1,

    [FieldSettings(nameof(Translations.Enum.SharedFinances.SeparateAccounts), Description = nameof(Translations.Enum.SharedFinances.SeparateAccounts_Description), ResourceType = typeof(Translations.Enum.SharedFinances))]
    SeparateAccounts = 2,

    [FieldSettings(nameof(Translations.Enum.SharedFinances.HybridApproach), Description = nameof(Translations.Enum.SharedFinances.HybridApproach_Description), ResourceType = typeof(Translations.Enum.SharedFinances))]
    HybridApproach = 3
}