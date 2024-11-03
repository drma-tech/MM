namespace MM.Shared.Enums
{
    public enum ReadingGenre
    {
        [Custom(Name = "Fiction & Literature", Description = "Stories that explore human experiences and imagination, often through narrative prose (e.g., novels, contemporary fiction, classic literature, poetry)")]
        FictionLiterature = 1,

        [Custom(Name = "Speculative & Adventure", Description = "Books that push boundaries through fantasy, science fiction, and adventurous themes (e.g., fantasy, sci-fi, thrillers, mystery, horror, supernatural, adventure)")]
        SpeculativeAdventure = 2,

        [Custom(Name = "Romance & Relationships", Description = "Stories centered on love, connection, and human relationships (e.g., contemporary romance, historical romance, family dramas)")]
        RomanceRelationships = 3,

        [Custom(Name = "History & Biographical", Description = "Accounts of real historical events, people, and memoirs of personal experiences (e.g., historical fiction, biographies, autobiographies)")]
        HistoryBiographical = 4,

        [Custom(Name = "Self-Improvement & Mindfulness", Description = "Books that focus on self-growth, wellness, and personal insight (e.g., self-help, personal development, mindfulness, spirituality)")]
        SelfImprovementMindfulness = 5,

        [Custom(Name = "Science, Nature & Exploration", Description = "Works explaining the natural and scientific world or narrating journeys of exploration (e.g., popular science, environmental studies, travel writing)")]
        ScienceNatureExploration = 6,

        [Custom(Name = "Society & Current Affairs", Description = "Analyses and discussions on social, political, and economic issues of our time (e.g., politics, social issues, current events)")]
        SocietyCurrentAffairs = 7,

        [Custom(Name = "Education & Reference", Description = "Informative resources and educational texts for structured learning or reference (e.g., textbooks, guides, encyclopedias)")]
        EducationReference = 8,

        [Custom(Name = "Visual Storytelling", Description = "Illustrated stories and graphic works that combine art with narrative (e.g., comics, graphic novels, manga)")]
        VisualStorytelling = 9
    }
}