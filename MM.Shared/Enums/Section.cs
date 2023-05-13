namespace MM.Shared.Enums
{
    public enum Section
    {
        /// <summary>
        /// This includes basic information such as age, gender, location, etc.
        /// </summary>
        [Custom(Name = "Basic", ResourceType = typeof(Resources.Section))]
        Basic,

        /// <summary>
        /// This includes details about education, career, background, etc.
        /// </summary>
        [Custom(Name = "Bio", ResourceType = typeof(Resources.Section))]
        Bio,

        /// <summary>
        /// This includes habits, values, routines, etc.
        /// </summary>
        [Custom(Name = "Lifestyle", ResourceType = typeof(Resources.Section))]
        Lifestyle,

        /// <summary>
        /// This includes traits, values, goals, etc.
        /// </summary>
        [Custom(Name = "Personality", ResourceType = typeof(Resources.Section))]
        Personality,

        /// <summary>
        /// This includes hobbies, passions, favorite activities, etc.
        /// </summary>
        [Custom(Name = "Interest", ResourceType = typeof(Resources.Section))]
        Interest
    }
}