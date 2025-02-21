namespace MM.Shared.Enums
{
    public enum MusicGenre
    {
        [Custom(Name = "PopMainstream", Description = "PopMainstream_Description", ResourceType = typeof(Resources.MusicGenre))]
        PopMainstream = 1,

        [Custom(Name = "RockAlternative", Description = "RockAlternative_Description", ResourceType = typeof(Resources.MusicGenre))]
        RockAlternative = 2,

        [Custom(Name = "RBSoul", Description = "RBSoul_Description", ResourceType = typeof(Resources.MusicGenre))]
        RBSoul = 3,

        [Custom(Name = "HipHopRap", Description = "HipHopRap_Description", ResourceType = typeof(Resources.MusicGenre))]
        HipHopRap = 4,

        [Custom(Name = "JazzBlues", Description = "JazzBlues_Description", ResourceType = typeof(Resources.MusicGenre))]
        JazzBlues = 5,

        [Custom(Name = "ClassicalOpera", Description = "ClassicalOpera_Description", ResourceType = typeof(Resources.MusicGenre))]
        ClassicalOpera = 6,

        [Custom(Name = "ElectronicDance", Description = "ElectronicDance_Description", ResourceType = typeof(Resources.MusicGenre))]
        ElectronicDance = 7,

        [Custom(Name = "FolkAcoustic", Description = "FolkAcoustic_Description", ResourceType = typeof(Resources.MusicGenre))]
        FolkAcoustic = 8,

        [Custom(Name = "Country", Description = "Country_Description", ResourceType = typeof(Resources.MusicGenre))]
        Country = 9,

        [Custom(Name = "ReggaeWorldMusic", Description = "ReggaeWorldMusic_Description", ResourceType = typeof(Resources.MusicGenre))]
        ReggaeWorldMusic = 10,

        [Custom(Name = "MetalHardRock", Description = "MetalHardRock_Description", ResourceType = typeof(Resources.MusicGenre))]
        MetalHardRock = 11,

        [Custom(Name = "GospelReligious", Description = "GospelReligious_Description", ResourceType = typeof(Resources.MusicGenre))]
        GospelReligious = 12,

        [Custom(Name = "ExperimentalAvantGarde", Description = "ExperimentalAvantGarde_Description", ResourceType = typeof(Resources.MusicGenre))]
        ExperimentalAvantGarde = 13,

        [Custom(Name = "SoundtracksScores", Description = "SoundtracksScores_Description", ResourceType = typeof(Resources.MusicGenre))]
        SoundtracksScores = 14
    }
}