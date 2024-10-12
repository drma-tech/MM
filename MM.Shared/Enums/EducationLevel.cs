namespace MM.Shared.Enums
{
    public enum EducationLevel
    {
        [Custom(Name = "High School or Less", Description = "Includes individuals with little or no formal education, those who completed or did not complete primary or secondary education. Typically, this group values practical skills over academic training.")]
        Basic = 1,

        [Custom(Name = "Some College or Vocational Training", Description = "Covers individuals who have attended technical schools, vocational training, or started college/university but did not complete a degree. This group often focuses on skill-based education or partial academic experience.")]
        Intermediary = 2,

        [Custom(Name = "Bachelor’s Degree or Higher", Description = "Includes individuals with a completed bachelor's degree, master’s degree, or higher academic achievements. People in this group generally have a longer academic background and are more likely to have professional or intellectual interests.")]
        Advanced = 3
    }
}