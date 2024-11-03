namespace MM.Shared.Enums
{
    public enum Sports
    {
        [Custom(Name = "Team Sports", Description = "Group-based sports focused on cooperation (e.g., soccer, basketball, volleyball, baseball)")]
        TeamSports = 1,

        [Custom(Name = "Water Sports", Description = "Sports in or on water (e.g., swimming, surfing, kayaking, water polo)")]
        WaterSports = 2,

        [Custom(Name = "Adventure & Extreme Sports", Description = "High-adrenaline and thrill-seeking activities (e.g., rock climbing, skydiving, bungee jumping, snowboarding)")]
        AdventureExtremeSports = 3,

        [Custom(Name = "Combat Sports", Description = "Physical, one-on-one competitions (e.g., boxing, martial arts, wrestling, fencing)")]
        CombatSports = 4,

        [Custom(Name = "Racquet Sports", Description = "Sports involving rackets and coordination (e.g., tennis, badminton, squash, table tennis)")]
        RacquetSports = 5,

        [Custom(Name = "Winter Sports", Description = "Sports practiced on snow or ice (e.g., skiing, snowboarding, ice hockey, ice skating)")]
        WinterSports = 6,

        [Custom(Name = "Motorsports", Description = "Sports involving vehicles and racing (e.g., car racing, motocross, Formula 1, kart racing)")]
        Motorsports = 7,

        [Custom(Name = "Fitness & Conditioning", Description = "Physical activities focused on health and fitness (e.g., weightlifting, aerobics, pilates, yoga)")]
        FitnessConditioning = 8,

        [Custom(Name = "Outdoor Recreation", Description = "Non-competitive outdoor activities (e.g., hiking, trail running, camping, mountain biking)")]
        OutdoorRecreation = 9,

        [Custom(Name = "Gymnastics & Aesthetics", Description = "Sports focusing on precision, form, and balance (e.g., gymnastics, ballet, cheerleading, rhythmic gymnastics)")]
        GymnasticsAesthetics = 10,

        [Custom(Name = "Mind Sports", Description = "Strategy and concentration-based activities (e.g., chess, esports, poker, bridge)")]
        MindSports = 11,

        [Custom(Name = "Shooting Sports", Description = "Accuracy-focused sports using projectiles (e.g., archery, shooting, paintball)")]
        ShootingSports = 12,

        [Custom(Name = "Equestrian Sports", Description = "Activities involving horseback riding (e.g., show jumping, dressage, polo, rodeo)")]
        EquestrianSports = 13,

        [Custom(Name = "Athletics", Description = "Track and field events (e.g., sprinting, long jump, high jump, shot put)")]
        Athletics = 14,

        [Custom(Name = "Aquatic Sports", Description = "Competitive and recreational swimming-based sports (e.g., synchronized swimming, diving, open-water swimming)")]
        AquaticSports = 15,

        [Custom(Name = "Cycling Sports", Description = "Sports involving bicycles (e.g., road cycling, mountain biking, BMX, track cycling)")]
        CyclingSports = 16,
    }
}