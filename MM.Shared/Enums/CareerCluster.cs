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

    [FieldSettings("AgricultureFoodNaturalResources_Name", Group = "AgricultureFoodNaturalResources_Group", Description = "AgricultureFoodNaturalResources_Description", ResourceType = typeof(Translations.Enum.CareerCluster))]
    AgricultureFoodNaturalResources = 1,

    //COMMUNICATION & INFORMATION SYSTEMS

    [FieldSettings("CommunicationArts_Name", Group = "CommunicationArts_Group", Description = "CommunicationArts_Description",
        ResourceType = typeof(Translations.Enum.CareerCluster))]
    CommunicationArts = 2,

    [FieldSettings("InformationTechnology_Name", Group = "InformationTechnology_Group", Description = "InformationTechnology_Description",
        ResourceType = typeof(Translations.Enum.CareerCluster))]
    InformationTechnology = 3,

    //BUSINESS, MARKETING AND MANAGEMENT

    [FieldSettings("BusinessManagementAdministration_Name", Group = "BusinessManagementAdministration_Group", Description = "BusinessManagementAdministration_Description",
        ResourceType = typeof(Translations.Enum.CareerCluster))]
    BusinessManagementAdministration = 4,

    [FieldSettings("Finance_Name", Group = "Finance_Group", Description = "Finance_Description",
        ResourceType = typeof(Translations.Enum.CareerCluster))]
    Finance = 5,

    [FieldSettings("HospitalityTourism_Name", Group = "HospitalityTourism_Group", Description = "HospitalityTourism_Description",
        ResourceType = typeof(Translations.Enum.CareerCluster))]
    HospitalityTourism = 6,

    [FieldSettings("Marketing_Name", Group = "Marketing_Group", Description = "Marketing_Description",
        ResourceType = typeof(Translations.Enum.CareerCluster))]
    Marketing = 7,

    //HUMAN SCIENCES AND EDUCATION

    [FieldSettings("EducationTraining_Name", Group = "EducationTraining_Group", Description = "EducationTraining_Description",
        ResourceType = typeof(Translations.Enum.CareerCluster))]
    EducationTraining = 8,

    [FieldSettings("GovernmentPublicAdministration_Name", Group = "GovernmentPublicAdministration_Group", Description = "GovernmentPublicAdministration_Description",
        ResourceType = typeof(Translations.Enum.CareerCluster))]
    GovernmentPublicAdministration = 9,

    [FieldSettings("HumanServices_Name", Group = "HumanServices_Group", Description = "HumanServices_Description",
        ResourceType = typeof(Translations.Enum.CareerCluster))]
    HumanServices = 10,

    [FieldSettings("LawPublicSafetyCorrectionsSecurity_Name", Group = "LawPublicSafetyCorrectionsSecurity_Group", Description = "LawPublicSafetyCorrectionsSecurity_Description",
        ResourceType = typeof(Translations.Enum.CareerCluster))]
    LawPublicSafetyCorrectionsSecurity = 11,

    //HEALTH SCIENCES

    [FieldSettings("HealthScience_Name", Group = "HealthScience_Group", Description = "HealthScience_Description",
        ResourceType = typeof(Translations.Enum.CareerCluster))]
    HealthScience = 12,

    //SKILLED & TECHNICAL SCIENCES

    [FieldSettings("ArchitectureConstruction_Name", Group = "ArchitectureConstruction_Group", Description = "ArchitectureConstruction_Description",
        ResourceType = typeof(Translations.Enum.CareerCluster))]
    ArchitectureConstruction = 13,

    [FieldSettings("EnergyEngineering_Name", Group = "EnergyEngineering_Group", Description = "EnergyEngineering_Description",
        ResourceType = typeof(Translations.Enum.CareerCluster))]
    EnergyEngineering = 14,

    [FieldSettings("Manufacturing_Name", Group = "Manufacturing_Group", Description = "Manufacturing_Description",
        ResourceType = typeof(Translations.Enum.CareerCluster))]
    Manufacturing = 15,

    [FieldSettings("TransportationDistributionLogistics_Name", Group = "TransportationDistributionLogistics_Group", Description = "TransportationDistributionLogistics_Description",
        ResourceType = typeof(Translations.Enum.CareerCluster))]
    TransportationDistributionLogistics = 16
}