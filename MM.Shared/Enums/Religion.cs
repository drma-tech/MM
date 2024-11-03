namespace MM.Shared.Enums
{
    public enum Religion
    {
        [Custom(Name = "Christianity", Description = "A monotheistic religion based on the life and teachings of Jesus Christ. It emphasizes faith in one God and the importance of love, forgiveness, and salvation through Jesus.")]
        Christianity = 1,

        [Custom(Name = "Islam", Description = "A monotheistic faith revealed through Muhammad as the Prophet of Allah. Followers, known as Muslims, practice the Five Pillars of Islam and believe in the Quran as their holy book.")]
        Islam = 2,

        [Custom(Name = "Hinduism", Description = "One of the oldest religions, characterized by a variety of beliefs and practices, including concepts of karma, dharma, and the cycle of rebirth. It encompasses a wide range of philosophies and rituals.")]
        Hinduism = 3,

        [Custom(Name = "Non-Religious / Atheist", Description = "Individuals who do not identify with any religion or believe in a deity. This category includes atheists, agnostics, and those who hold secular views.")]
        NonReligious = 4,

        [Custom(Name = "Buddhism", Description = "A spiritual tradition focusing on personal spiritual development and the attainment of enlightenment through practices such as meditation and ethical living. It teaches the Four Noble Truths and the Eightfold Path.")]
        Buddhism = 5,

        [Custom(Name = "Sikhism", Description = "A faith that emphasizes equality, service, and devotion to one God, founded in the 15th century in the Punjab region. Sikhs follow the teachings of the ten Gurus and regard the Guru Granth Sahib as their holy scripture.")]
        Sikhism = 6,

        [Custom(Name = "Judaism", Description = "The monotheistic religion of the Jewish people, based on the Hebrew Bible (Tanakh). It emphasizes the covenant between God and the Jewish people, along with ethical conduct and community responsibility.")]
        Judaism = 7,

        [Custom(Name = "Other", Description = "Any other belief system or religious affiliation not listed here, which may include indigenous beliefs, new religious movements, and other spiritual practices.")]
        Other = 8
    }
}