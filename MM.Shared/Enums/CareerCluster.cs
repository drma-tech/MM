namespace MM.Shared.Enums;

/// <summary>
///     https://www.education.ne.gov/nce/careerdevelopment/nce-career-fields-career-clusters/
///     https://www.education.ne.gov/wp-content/uploads/2019/08/CTEModel17X22-RGB-2.pdf
///     https://careerwise.minnstate.edu/careers/clusters.html
///     https://careertech.org/career-clusters
///     https://www.asvabprogram.com/career-cluster
/// </summary>
public enum CareerCluster
{
    [FieldSettings("NoCareer_Name", Description = "NoCareer_Description", ResourceType = typeof(Translations.Enum.CareerCluster))]
    NoCareer = -1,

    //AGRICULTURE, FOOD & NATURAL RESOURCES

    [FieldSettings(nameof(Translations.Enum.CareerCluster.AgricultureFoodNaturalResources_Name), Group = nameof(Translations.Enum.CareerCluster.AgricultureFoodNaturalResources_Group), Description = nameof(Translations.Enum.CareerCluster.AgricultureFoodNaturalResources_Description), 
        ResourceType = typeof(Translations.Enum.CareerCluster))]
    AgricultureFoodNaturalResources = 1,

    //COMMUNICATION & INFORMATION SYSTEMS

    [FieldSettings(nameof(Translations.Enum.CareerCluster.CommunicationArts_Name), Group = nameof(Translations.Enum.CareerCluster.CommunicationArts_Group), Description = nameof(Translations.Enum.CareerCluster.CommunicationArts_Description),
        ResourceType = typeof(Translations.Enum.CareerCluster))]
    CommunicationArts = 2,

    [FieldSettings(nameof(Translations.Enum.CareerCluster.InformationTechnology_Name), Group = nameof(Translations.Enum.CareerCluster.InformationTechnology_Group), Description = nameof(Translations.Enum.CareerCluster.InformationTechnology_Description),
        ResourceType = typeof(Translations.Enum.CareerCluster))]
    InformationTechnology = 3,

    //BUSINESS, MARKETING AND MANAGEMENT

    [FieldSettings(nameof(Translations.Enum.CareerCluster.BusinessManagementAdministration_Name), Group = nameof(Translations.Enum.CareerCluster.BusinessManagementAdministration_Group), Description = nameof(Translations.Enum.CareerCluster.BusinessManagementAdministration_Description),
        ResourceType = typeof(Translations.Enum.CareerCluster))]
    BusinessManagementAdministration = 4,

    [FieldSettings(nameof(Translations.Enum.CareerCluster.Finance_Name), Group = nameof(Translations.Enum.CareerCluster.Finance_Group), Description = nameof(Translations.Enum.CareerCluster.Finance_Description),
        ResourceType = typeof(Translations.Enum.CareerCluster))]
    Finance = 5,

    [FieldSettings(nameof(Translations.Enum.CareerCluster.HospitalityTourism_Name), Group = nameof(Translations.Enum.CareerCluster.HospitalityTourism_Group), Description = nameof(Translations.Enum.CareerCluster.HospitalityTourism_Description),
        ResourceType = typeof(Translations.Enum.CareerCluster))]
    HospitalityTourism = 6,

    [FieldSettings(nameof(Translations.Enum.CareerCluster.Marketing_Name), Group = nameof(Translations.Enum.CareerCluster.Marketing_Group), Description = nameof(Translations.Enum.CareerCluster.Marketing_Description),
        ResourceType = typeof(Translations.Enum.CareerCluster))]
    Marketing = 7,

    //HUMAN SCIENCES AND EDUCATION

    [FieldSettings(nameof(Translations.Enum.CareerCluster.EducationTraining_Name), Group = nameof(Translations.Enum.CareerCluster.EducationTraining_Group), Description = nameof(Translations.Enum.CareerCluster.EducationTraining_Description),
        ResourceType = typeof(Translations.Enum.CareerCluster))]
    EducationTraining = 8,

    [FieldSettings(nameof(Translations.Enum.CareerCluster.GovernmentPublicAdministration_Name), Group = nameof(Translations.Enum.CareerCluster.GovernmentPublicAdministration_Group), Description = nameof(Translations.Enum.CareerCluster.GovernmentPublicAdministration_Description),
        ResourceType = typeof(Translations.Enum.CareerCluster))]
    GovernmentPublicAdministration = 9,

    [FieldSettings(nameof(Translations.Enum.CareerCluster.HumanServices_Name), Group = nameof(Translations.Enum.CareerCluster.HumanServices_Group), Description = nameof(Translations.Enum.CareerCluster.HumanServices_Description),
        ResourceType = typeof(Translations.Enum.CareerCluster))]
    HumanServices = 10,

    [FieldSettings(nameof(Translations.Enum.CareerCluster.LawPublicSafetyCorrectionsSecurity_Name), Group = nameof(Translations.Enum.CareerCluster.LawPublicSafetyCorrectionsSecurity_Group), Description = nameof(Translations.Enum.CareerCluster.LawPublicSafetyCorrectionsSecurity_Description),
        ResourceType = typeof(Translations.Enum.CareerCluster))]
    LawPublicSafetyCorrectionsSecurity = 11,

    //HEALTH SCIENCES

    [FieldSettings(nameof(Translations.Enum.CareerCluster.HealthScience_Name), Group = nameof(Translations.Enum.CareerCluster.HealthScience_Group), Description = nameof(Translations.Enum.CareerCluster.HealthScience_Description),
        ResourceType = typeof(Translations.Enum.CareerCluster))]
    HealthScience = 12,

    //SKILLED & TECHNICAL SCIENCES

    [FieldSettings(nameof(Translations.Enum.CareerCluster.ArchitectureConstruction_Name), Group = nameof(Translations.Enum.CareerCluster.ArchitectureConstruction_Group), Description = nameof(Translations.Enum.CareerCluster.ArchitectureConstruction_Description),
        ResourceType = typeof(Translations.Enum.CareerCluster))]
    ArchitectureConstruction = 13,

    [FieldSettings(nameof(Translations.Enum.CareerCluster.EnergyEngineering_Name), Group = nameof(Translations.Enum.CareerCluster.EnergyEngineering_Group), Description = nameof(Translations.Enum.CareerCluster.EnergyEngineering_Description),
        ResourceType = typeof(Translations.Enum.CareerCluster))]
    EnergyEngineering = 14,

    [FieldSettings(nameof(Translations.Enum.CareerCluster.Manufacturing_Name), Group = nameof(Translations.Enum.CareerCluster.Manufacturing_Group), Description = nameof(Translations.Enum.CareerCluster.Manufacturing_Description),
        ResourceType = typeof(Translations.Enum.CareerCluster))]
    Manufacturing = 15,

    [FieldSettings(nameof(Translations.Enum.CareerCluster.TransportationDistributionLogistics_Name), Group = nameof(Translations.Enum.CareerCluster.TransportationDistributionLogistics_Group), Description = nameof(Translations.Enum.CareerCluster.TransportationDistributionLogistics_Description),
        ResourceType = typeof(Translations.Enum.CareerCluster))]
    TransportationDistributionLogistics = 16
}