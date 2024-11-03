namespace MM.Shared.Enums
{
    public enum MusicGenre
    {
        [Custom(Name = "Pop & Mainstream", Description = "Accessible and widely popular music across charts and cultures (e.g., pop, dance-pop, synth-pop)")]
        PopMainstream = 1,

        [Custom(Name = "Rock & Alternative", Description = "Guitar-driven sounds and subgenres with a rebellious edge (e.g., classic rock, punk, indie, grunge)")]
        RockAlternative = 2,

        [Custom(Name = "R&B & Soul", Description = "Emotional and rhythm-focused music rooted in African-American traditions (e.g., R&B, soul, funk)")]
        RBSoul = 3,

        [Custom(Name = "Hip-Hop & Rap", Description = "Beat-driven music with lyrical flow, storytelling, and social commentary (e.g., rap, trap, old-school hip-hop)")]
        HipHopRap = 4,

        [Custom(Name = "Jazz & Blues", Description = "Rich, improvisational genres with roots in African-American history (e.g., jazz, blues, bebop)")]
        JazzBlues = 5,

        [Custom(Name = "Classical & Opera", Description = "Structured compositions and orchestral music from various historical periods (e.g., baroque, symphonic, opera)")]
        ClassicalOpera = 6,

        [Custom(Name = "Electronic & Dance", Description = "Synthesized sounds and beat-heavy tracks for club and festival scenes (e.g., house, techno, trance)")]
        ElectronicDance = 7,

        [Custom(Name = "Folk & Acoustic", Description = "Music rooted in traditional sounds, often featuring acoustic instruments (e.g., folk, Americana, singer-songwriter)")]
        FolkAcoustic = 8,

        [Custom(Name = "Country", Description = "Storytelling-driven genre with roots in American folk traditions (e.g., classic country, contemporary country)")]
        Country = 9,

        [Custom(Name = "Reggae & World Music", Description = "Music from diverse cultural origins, often with distinctive rhythms (e.g., reggae, Afrobeat, Latin)")]
        ReggaeWorldMusic = 10,

        [Custom(Name = "Metal & Hard Rock", Description = "Intense, amplified sounds often with aggressive tones (e.g., heavy metal, thrash, hard rock)")]
        MetalHardRock = 11,

        [Custom(Name = "Gospel & Religious", Description = "Music with religious or spiritual themes, often community-oriented (e.g., gospel, hymns, devotional music)")]
        GospelReligious = 12,

        [Custom(Name = "Experimental & Avant-Garde", Description = "Nontraditional music pushing the boundaries of structure and sound (e.g., noise, ambient, minimalist)")]
        ExperimentalAvantGarde = 13,

        [Custom(Name = "Soundtracks & Scores", Description = "Music composed for visual media, including movies and games (e.g., film scores, video game soundtracks)")]
        SoundtracksScores = 14
    }
}