namespace MM.Shared.Enums;

public enum MaritalStatus
{
    [FieldSettings(nameof(Translations.Enum.MaritalStatus.Single_Name), Description = nameof(Translations.Enum.MaritalStatus.Single_Description), ResourceType = typeof(Translations.Enum.MaritalStatus))]
    Single = 1,

    [FieldSettings(nameof(Translations.Enum.MaritalStatus.Married_Name), Description = nameof(Translations.Enum.MaritalStatus.Married_Description), ResourceType = typeof(Translations.Enum.MaritalStatus))]
    Married = 2,

    [FieldSettings(nameof(Translations.Enum.MaritalStatus.CommonLawCohabiting_Name), Description = nameof(Translations.Enum.MaritalStatus.CommonLawCohabiting_Description), ResourceType = typeof(Translations.Enum.MaritalStatus))]
    CommonLawCohabiting = 3,

    [FieldSettings(nameof(Translations.Enum.MaritalStatus.Separated_Name), Description = nameof(Translations.Enum.MaritalStatus.Separated_Description), ResourceType = typeof(Translations.Enum.MaritalStatus))]
    Separated = 4,

    [FieldSettings(nameof(Translations.Enum.MaritalStatus.Divorced_Name), Description = nameof(Translations.Enum.MaritalStatus.Divorced_Description), ResourceType = typeof(Translations.Enum.MaritalStatus))]
    Divorced = 5,

    [FieldSettings(nameof(Translations.Enum.MaritalStatus.Annulled_Name), Description = nameof(Translations.Enum.MaritalStatus.Annulled_Description), ResourceType = typeof(Translations.Enum.MaritalStatus))]
    Annulled = 6,

    [FieldSettings(nameof(Translations.Enum.MaritalStatus.MarriageConvenience_Name), Description = nameof(Translations.Enum.MaritalStatus.MarriageConvenience_Description), ResourceType = typeof(Translations.Enum.MaritalStatus))]
    MarriageConvenience = 7,
}