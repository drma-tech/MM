using MM.Shared.Models.Profile.Resources;
using Newtonsoft.Json;
using static MM.Shared.Core.Helper.ImageHelper;

namespace MM.Shared.Models.Profile;

public class ProfileModel : CosmosDocument
{
    public enum LocationType
    {
        Full,
        Country,
        State,
        City
    }

    private readonly string BlobPath = "https://drmammstorage.blob.core.windows.net";

    public bool Validated { get; set; }

    public ProfileGalleryModel? Gallery { get; set; }

    public void UpdateData(ProfileModel profile)
    {
        //BASIC
        NickName = profile.NickName;
        Description = profile.Description;
        Country = profile.Country;
        State = profile.State;
        City = profile.City;
        Languages = profile.Languages;
        MaritalStatus = profile.MaritalStatus;
        RelationshipIntentions = profile.RelationshipIntentions;
        BiologicalSex = profile.BiologicalSex;
        GenderIdentities = profile.GenderIdentities;
        SexualOrientations = profile.SexualOrientations;

        //BIO
        BirthDate = profile.BirthDate;
        Height = profile.Height;
        Ethnicity = profile.Ethnicity;
        BodyType = profile.BodyType;

        //LIFESTYLE
        Drink = profile.Drink;
        Smoke = profile.Smoke;
        Diet = profile.Diet;
        HaveChildren = profile.HaveChildren;
        WantChildren = profile.WantChildren;
        EducationLevel = profile.EducationLevel;
        CareerCluster = profile.CareerCluster;
        Religion = profile.Religion;
        TravelFrequency = profile.TravelFrequency;

        //PERSONALITY
        MoneyPersonality = profile.MoneyPersonality;
        SharedSpendingStyle = profile.SharedSpendingStyle;
        RelationshipPersonality = profile.RelationshipPersonality;
        MBTI = profile.MBTI;
        LoveLanguage = profile.LoveLanguage;
        SexPersonality = profile.SexPersonality;

        //INTEREST
        Food = profile.Food;
        Vacation = profile.Vacation;
        Sports = profile.Sports;
        LeisureActivities = profile.LeisureActivities;
        MusicGenre = profile.MusicGenre;
        MovieGenre = profile.MovieGenre;
        TVGenre = profile.TVGenre;
        ReadingGenre = profile.ReadingGenre;

        //OTHERS
        Neurodiversity = profile.Neurodiversity;
        Disabilities = profile.Disabilities;
    }

    public void UpdatePhoto(ProfileGalleryModel obj)
    {
        Gallery = obj;
    }

    public string GetPhoto(PhotoType type, bool fake = false)
    {
        if (Gallery == null) return GetNoUserPhoto;
        if (Gallery.Type == GalleryType.BlindDate) return GetBlindDate;

        var id = Gallery.GetPictureId(type);
        if (id == null) return GetNoUserPhoto;

        if (fake)
            return id;
        return $"{BlobPath}/{GetPhotoContainer(type)}/{id}";
    }

    public string? GetLocation(LocationType type)
    {
        if (string.IsNullOrEmpty(Location)) return null;

        var parts = Location.Split(" - ");

        switch (type)
        {
            case LocationType.Full:
                return Location;

            case LocationType.Country:
                return parts[0];

            case LocationType.State:
                return parts[1];

            case LocationType.City:
                if (parts.Length == 4)
                    return parts[2] + " - " + parts[3]; //county - city
                return parts[2];

            default:
                return null;
        }
    }

    public void SanitizeOpenTextFields()
    {
        NickName = NickName?.RemoveUnsafeControlChars()?.NormalizeToNfc()?.Trim();
        Description = Description?.RemoveUnsafeControlChars()?.NormalizeToNfc()?.Trim();
    }

    #region BASIC

    [Custom(Name = "NickName_Name", Placeholder = "NickName_Placeholder", ResourceType = typeof(ProfileBasicModel))]
    public string? NickName { get; set; }

    [Custom(Name = "Description_Name", Placeholder = "Description_Placeholder", ResourceType = typeof(ProfileBasicModel))]
    public string? Description { get; set; }

    [Custom(Name = "Nationality_Name", ResourceType = typeof(ProfileBasicModel))]
    public Country? Nationality { get; set; }

    [JsonIgnore]
    [Custom(Name = "Location_Name", Placeholder = "Location_Placeholder", Description = "Location_Description",
        WhyImportant = "Location impacts time zones, language, culture, daily habits, and the feasibility of in-person interaction. In global matchups, even a compatible connection can face strain if physical distance and cultural contexts aren’t addressed early.",
        Tips = "Long-distance match?|Clarify intentions. Are both open to remote connection, travel, or eventual relocation?|Same country, different regions?|Discuss regional habits, values, or cost of living differences—they might affect lifestyle choices.|Same city or close by?|Leverage proximity for easier in-person bonding—but don’t rush just because it’s convenient.|Cultural context matters?|Even in the same country, local customs can vary—be curious about your partner’s environment.|Different time zones?|Coordinate intentionally. Regular communication requires effort and planning.|One is open to moving, the other not?|Align expectations early. Location flexibility can determine long-term viability.|Safety or mobility constraints?|Be transparent. Not everyone can relocate or travel freely—respect those limitations.",
        ResourceType = typeof(ProfileBasicModel))]
    public string? Location => Country.NotEmpty() ? $"{Country} - {State} - {City}" : null;

    public string? Country { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }

    [Custom(Name = "Languages_Name", Description = "Languages_Description",
        WhyImportant = "Sharing a common language—or understanding each other’s fluency levels—helps build emotional connection, avoid miscommunication, and navigate conflict. Even in multicultural or long-distance relationships, knowing how each person communicates can make or break emotional intimacy.",
        Tips = "Speak the same language fluently?|Use that to deepen connection through meaningful conversations and shared humor. Don't assume understanding—always clarify emotional meaning.|Your partner is less fluent than you?|Speak slowly and clearly, avoid idioms, and be patient. Encourage their effort and celebrate small progress.|You’re less fluent than your partner?|Be honest about your limits. Let them know when you don’t understand and ask them to speak more simply when needed.|Neither of you is fluent in the other's language?|Use translation tools and gestures early on, but gradually build shared words or phrases to form emotional closeness.|Partner speaks more languages than you?|Ask them to teach you basic phrases in their other languages. It shows care and curiosity about their background.|Language gaps cause frustration?|Take breaks if communication feels tiring. Focus on nonverbal cues—touch, tone, and eye contact can say a lot.|Different native languages, same second language?|Use the shared second language as neutral ground. It can reduce power imbalances and create new shared meaning.",
        ResourceType = typeof(ProfileBasicModel))]
    public HashSet<Language> Languages { get; set; } = [];

    [Custom(Name = "MaritalStatus_Name",
        WhyImportant = "Understanding marital status helps set expectations about relationship availability, emotional readiness, and legal considerations. Different statuses can imply varying levels of commitment history, baggage, or openness to new relationships, which affects compatibility and communication.",
        Tips = "Both single?|You’re likely both open to new relationships without prior commitments—focus on building trust and connection.|One married or cohabiting?|Discuss boundaries and expectations clearly to avoid misunderstandings and emotional conflicts.|Separated or divorced?|Respect the healing process; be patient as your partner navigates past relationship closure.|Annulled or marriage of convenience?|Clarify what this means to your partner and their current relationship goals to avoid surprises.|Different statuses but open?|Communicate honestly about what each status means and how it impacts your expectations.|Marital status impacts legal matters?|If moving towards serious commitment, understand how previous marital status affects finances, children, or legal rights.|Be mindful of cultural differences|Marital status meanings and implications vary globally; always consider cultural context.",
        ResourceType = typeof(ProfileBasicModel))]
    public MaritalStatus? MaritalStatus { get; set; }

    [Custom(Name = "BiologicalSex_Name",
        WhyImportant = "Biological sex influences physical compatibility, health considerations, and sometimes social or cultural dynamics in relationships. Knowing this helps partners understand potential biological factors relevant to intimacy, reproduction, and personal identity.",
        Tips = "Both partners share same biological sex?|Discuss any specific health or intimacy considerations openly to support each other’s needs.|Partners have different biological sexes?|Celebrate differences and openly communicate about physical and emotional expectations.|One or both identify as intersex?|Respect their unique experience and ask how they want to be supported regarding intimacy and health.|Avoid assumptions|Biological sex does not define gender identity or sexual orientation—always communicate respectfully.|Consider cultural sensitivities|Different cultures view biological sex and its implications in relationships differently—be mindful and open.",
        ResourceType = typeof(ProfileBasicModel))]
    public BiologicalSex? BiologicalSex { get; set; }

    [Custom(Name = "GenderIdentity_Name", Description = "GenderIdentity_Description",
        WhyImportant = "Gender identity shapes how a person understands themselves and wants to be seen in the relationship. Knowing your partner's identity helps you connect more authentically and avoid invalidating their experience—especially in relationships where gender diversity is present.",
        Tips = "Your partner is transgender, nonbinary, or genderqueer?|Ask which pronouns they use and use them consistently. Small gestures of respect go a long way in building trust and emotional safety.|Your partner is genderfluid or bigender?|Understand that how they present or express themselves may vary. Be open and avoid assuming their mood or identity based on appearance.|Your partner is questioning?|Give them emotional space to explore who they are. Avoid pressuring for clarity—support is more important than certainty.|You identify differently?|Talk openly about how your gender identities influence your roles, dynamics, and comfort levels in the relationship.|Gender identity differs from yours?|Stay curious and compassionate. Ask questions respectfully and recognize that their experience may be very different from yours.|Not familiar with your partner's identity label?|Look it up, ask politely, or invite them to explain what feels meaningful—learning shows care.|Cultural context matters?|Some identities (like Two-Spirit) are culture-specific. Acknowledge and respect their cultural meaning beyond gender alone.",
        ResourceType = typeof(ProfileBasicModel))]
    public HashSet<GenderIdentity> GenderIdentities { get; set; } = [];

    [Custom(Name = "SexualOrientation_Name", Description = "SexualOrientation_Description",
        WhyImportant = "Sexual orientation reflects who a person is romantically and sexually attracted to, which is fundamental for relationship compatibility. Knowing and respecting each other’s orientation helps set clear expectations around attraction, intimacy, and relationship structure—especially in diverse or nontraditional dynamics.",
        Tips = "Partner is heterosexual?|If you're of a different sex, this likely aligns well. But don’t assume compatibility based only on orientation—emotional and physical needs still vary.|Partner is homosexual or same-sex attracted?|Only pursue the relationship if your gender identity aligns with their attraction. Avoid putting emotional pressure on someone who isn’t attracted to your gender.|Partner is bisexual, pansexual, or polysexual?|Understand that attraction to multiple genders doesn’t mean they’re less loyal. Trust and communication matter more than labels.|Partner is demisexual or graysexual?|They may only feel sexual attraction after deep emotional bonds. Be patient and build trust slowly—don’t rush intimacy.|Partner is asexual or autosexual?|They may not seek sexual contact or may prefer self-directed experiences. Talk openly about boundaries and what intimacy means to both of you.|Partner is sapiosexual?|They’re likely drawn to intellect first—nurture mental connection and meaningful conversation.|Not familiar with your partner’s orientation?|Ask respectfully or do your own research—avoiding judgment and assumptions builds trust.|Orientation feels complex or fluid?|Some people resist strict labels (e.g., pomosexual). What matters most is how they feel about you—communicate directly.",
        ResourceType = typeof(ProfileBasicModel))]
    public HashSet<SexualOrientation> SexualOrientations { get; set; } = [];

    #endregion BASIC

    #region BIO

    [Custom(Name = "Ethnicity_Name",
        //FieldInfo = "É muito gratificante amar alguém que é diferente de você em termos de raça, cultura, identidade, religião e muito mais. Quando estamos abertos uns com os outros, podemos ampliar as perspectivas uns dos outros, abordar o mundo de maneiras diferentes e até descobrir que há uma conexão em nossas diferenças. Infelizmente, os casais inter-raciais ainda podem enfrentar dificuldades às vezes em virtude do fato de que o racismo existe em nossa sociedade em um nível profundo. Idealmente, o amor não deve ter limites a esse respeito. No entanto, na realidade, outras pessoas podem abrigar negatividade ou julgamento sobre um casal interracial. Os parceiros em um casamento inter-racial devem enfrentar essas questões juntos, mantendo empatia e apoio às experiências um do outro.",
        WhyImportant = "Ethnicity can influence values, traditions, communication styles, family expectations, and life experiences. While it doesn’t determine compatibility, awareness of each other’s cultural background fosters mutual respect and helps navigate potential cultural differences in relationships.",
        Tips = "You share the same ethnic background?|You may have shared cultural values, traditions, or family expectations—use that as a foundation for bonding, but don’t assume full alignment.|You come from different backgrounds?|Be open to learning about your partner’s heritage. Ask questions, try their foods, and participate in their cultural traditions when invited.|Partner's ethnicity is new to you?|Approach with curiosity, not stereotypes. Learn from them, not just online—ask what parts of their culture are important to them.|Ethnic identity is important to your partner?|Acknowledge and respect that—even if it doesn’t matter as much to you. Cultural pride is often tied to family and identity.|You or your partner are multiracial/mixed?|Explore how this shaped your/their worldview. Identity may be complex—avoid forcing simple definitions.|Family has strong views about ethnicity?|Talk about it early. Cultural or generational biases can create pressure—knowing where each person stands avoids future conflict.|Ethnicity plays a role in dating history?|Some people have experienced fetishization or discrimination—approach with empathy, not defensiveness.",
        ResourceType = typeof(ProfileBioModel))]
    public Ethnicity? Ethnicity { get; set; }

    [Custom(Name = "BodyType_Name",
        WhyImportant = "Body type can influence physical attraction, lifestyle compatibility, and even how someone feels about themselves in a relationship. While it's just one part of a person, feeling accepted and desired in your body is key to emotional and physical intimacy.",
        Tips = "You and your partner prefer similar body types?|This can increase initial attraction, but remember long-term connection depends on emotional compatibility too.|Your partner’s body type is different from your usual “type”?|Focus on how they make you feel, not just physical traits—unexpected attraction can grow with emotional intimacy.|Your partner is athletic or very active?|If you’re less active, respect their lifestyle and be open to joining in—but also talk about personal boundaries.|Your partner is curvy or heavyset?|Avoid making body a sensitive topic unless they bring it up. Affirm their attractiveness genuinely and avoid “fixing” language.|Your partner is slim or small-framed?|Be mindful not to project insecurities or stereotypes about size. Let them define their comfort zone around physical affection.|Body image is a sensitive topic?|Ask how your partner feels about their body, and listen without judgment. Feeling safe and seen is more powerful than compliments.|Different body types affect sex and affection?|Open communication helps. Talk about what feels good, what doesn’t, and what builds confidence for both of you.",
        ResourceType = typeof(ProfileBioModel))]
    public BodyType? BodyType { get; set; }

    [Custom(Name = "BirthDate_Name",

        ResourceType = typeof(ProfileBioModel))]
    public DateTime? BirthDate { get; set; }

    [JsonIgnore]
    [Custom(Name = "Age",
        WhyImportant = "Age can influence life stage, maturity, energy levels, and long-term goals such as marriage, children, or retirement. While numbers alone don’t determine compatibility, being aligned on timing, values, and expectations helps avoid future disconnects.",
        Tips = "You're close in age?|You may relate more easily to shared generational experiences, cultural references, and life pacing—use that to build connection.|There's a noticeable age gap?|Talk early about life goals, timelines, and expectations—especially around commitment, children, or lifestyle.|You're the older partner?|Be mindful of power dynamics. Encourage independence and mutual decision-making to maintain balance.|You're the younger partner?|Assert your voice in the relationship and speak up about your needs. Don’t let age define maturity or capability.|One of you is at a different life stage?|Whether it’s career, parenting, or retirement, be honest about what you can and can’t align on right now.|Cultural views on age difference affect you?|Some families or societies have strong opinions—decide together how much that matters to your relationship.|Worried about perception or judgment?|Focus on what works between you. A healthy age-gap relationship thrives on respect, trust, and shared vision—not approval from others."
        )]
    public int Age { get; set; }

    [Custom(Name = "Height_Name",
        WhyImportant = "Height often plays a role in physical attraction and social perception, but its importance varies widely by individual and culture. For some, it's a preference; for others, it holds symbolic meaning (e.g., feeling protected or feminine/masculine). Understanding how much it matters to your partner helps avoid unnecessary tension or insecurity.",
        Tips = "You or your partner care a lot about height?|Talk openly about it. Attraction is valid, but don’t let one trait overshadow deeper compatibility.|There’s a significant height difference?|Lean into it with confidence. Many couples embrace this contrast—it can even be playful or endearing.|You’re taller than your partner and not used to it?|Focus on how they make you feel emotionally and physically—not just how you look together.|Your partner is shorter and insecure about it?|Affirm them sincerely. Avoid height jokes or comparisons, especially in public.|Height comes up a lot in your dynamic?|Ask whether it’s about physical preference or tied to deeper needs (e.g., dominance, protection, confidence).|You have no height preference?|Be clear about that—some people assume it matters more than it actually does.|Cultural views affect how you see height?|Acknowledge that, but define your own standards. What matters is how you treat and support each other.",
        ResourceType = typeof(ProfileBioModel))]
    public Height? Height { get; set; }

    //https://www.gottman.com/blog/two-different-brains-in-love-conflict-resolution-in-neurodiverse-relationships/
    [Custom(
        Name = "Neurodiversity_Name",
        WhyImportant = "Neurodiversity acknowledges that people experience and process the world differently—through variations such as ADHD, autism, dyslexia, and more. Understanding if someone is neurodivergent helps partners build empathy, adjust expectations, and communicate in ways that respect each other’s cognitive styles and needs.",
        Tips = "Your partner is neurodivergent?|Ask how their brain works best—whether it’s in communication, routines, or emotional regulation. Respect their boundaries and support their strengths.|You’re neurodivergent and they’re not?|Help them understand your needs clearly, especially around sensory preferences, energy limits, or social situations.|You’re both neurodivergent?|Celebrate your shared differences while discussing where your needs might clash. Routine, flexibility, or communication pacing may differ.|Your partner has ADHD?|They may forget things, get distracted, or hyperfocus. Don’t take it personally—structure and patience go a long way.|Your partner is on the autism spectrum?|They might value direct communication, routine, and quiet environments. Be mindful of sensory overload and social fatigue.|You don’t fully understand neurodivergence?|Ask respectfully and do your own research—it shows commitment and care.|Different processing speeds or emotional expression?|Give each other space and time. What looks like disinterest may actually be overwhelm or focus.",
        ResourceType = typeof(ProfileBioModel))]
    public Neurodiversity? Neurodiversity { get; set; }

    //https://medium.com/@emily_rj/10-things-to-know-before-dating-someone-with-a-disability-6bf6eb8ae196
    [Custom(Name = "Disabilities_Name",
        WhyImportant = "Disabilities can affect how someone moves, communicates, processes information, or navigates daily life—but they don’t define a person or their ability to love and be loved. Being aware of a partner’s disability fosters empathy, accessibility, and emotional safety in the relationship.",
        Tips = "Your partner has a physical disability?|Ask what kind of help (if any) they appreciate, and don’t assume they need assistance. Focus on access and comfort, not limitations.|Your partner has a visual or hearing disability?|Learn how they prefer to communicate. This could include text, sign language, or specific tools—and patience is key.|Your partner has a mental health condition?|Check in gently and consistently. Support can look like routine, calm conversation, or simply not pressuring them to “fix” anything.|Your partner has a learning or intellectual disability?|Be clear, patient, and avoid condescension. Celebrate their strengths and adapt communication when needed.|You’re not familiar with their condition?|Educate yourself independently to avoid putting all the emotional labor on them.|Disability impacts intimacy or daily life?|Have honest conversations about comfort, access, and boundaries. Intimacy can look different but be just as meaningful.|Disability is invisible or fluctuating?|Don’t assume someone is “fine” just because it isn’t visible. Trust what they say about their limits and needs.",
        ResourceType = typeof(ProfileBioModel))]
    public HashSet<Disability> Disabilities { get; set; } = [];

    #endregion BIO

    #region LIFESTYLE

    [Custom(Name = "Drink_Name",
        WhyImportant = "Drinking habits can influence lifestyle, social settings, health, and values. Misalignment—like one partner drinking heavily and the other being sober—can create friction over priorities, routines, and boundaries. Understanding each other’s drinking habits helps avoid future conflicts and supports respectful compromise.",
        Tips = "One partner doesn't drink at all?|Respect their choice without pressure or teasing. Opt for alcohol-free activities and drinks when together.|One drinks lightly/moderately and the other heavily?|Talk openly about how drinking affects your time together. Set boundaries if it impacts communication or mood.|Both drink socially?|Celebrate the alignment, but also agree on limits and safe behavior in public or when hosting.|Your partner drinks to cope?|Support them without judgment, but encourage healthy coping mechanisms and talk about how it affects the relationship.|Different cultural or religious views on alcohol?|Be open about expectations and avoid environments that make either partner uncomfortable.|Discomfort with alcohol in the relationship?|Be honest early on. It’s okay to set non-negotiables around alcohol use.|Special occasions or travel involve drinking?|Plan ahead—agree on what feels balanced and respectful for both.",
        ResourceType = typeof(ProfileLifestyleModel))]
    public Drink? Drink { get; set; }

    [Custom(Name = "Smoke_Name",
        WhyImportant = "Smoking habits affect lifestyle, health, physical closeness, and even shared spaces. Whether due to personal preference, health reasons, or cultural norms, smoking compatibility can influence everyday comfort and long-term satisfaction.",
        Tips = "One partner doesn't smoke?|Be mindful of their preferences—avoid smoking near them, and don’t assume occasional smoking is “no big deal.”|Both smoke occasionally?|Set boundaries together (e.g., where and when it’s okay), and talk about possible changes in habit over time.|One smokes often?|Check in about how it affects your connection—especially around shared living space, finances, or children.|Dislike the smell or health effects?|Be upfront. Suggest compromises like outdoor-only smoking or designated clothes.|Trying to quit?|Support them without nagging. Celebrate progress, and ask how you can help.|Smoking is cultural or social for one partner?|Understand its context before judging. Ask what it means to them.|Concerned about long-term compatibility?|Have an honest conversation early—don’t wait for frustration to build.",
        ResourceType = typeof(ProfileLifestyleModel))]
    public Smoke? Smoke { get; set; }

    [Custom(Name = "Diet_Name", Description = "Diet_Description",
        WhyImportant = "Dietary choices often reflect personal values, health needs, culture, or lifestyle. They affect daily routines, cooking, eating out, and even long-term compatibility if raising children is part of the plan. Aligning—or respectfully navigating differences—helps avoid friction and supports mutual care.",
        Tips = "You have different diets?|Be flexible in shared meals—find dishes that meet both needs without turning meals into conflict.|Partner is vegan/vegetarian and you're not?|Respect their reasons. Avoid teasing, and be open to trying their food preferences occasionally.|One has health-based or restrictive diet (e.g., gluten-free, detox)?|Take it seriously. Understand it's not just a \"trend\"—it may be vital for their wellbeing.|Both value organic/local eating?|Celebrate that alignment—plan trips to markets, cook together, and explore healthy food culture.|Food is cultural or emotional for one of you?|Talk about what food means to each other, especially during holidays or family events.|Planning to live together?|Discuss grocery shopping, meal prep, and kitchen habits early.|One partner is very strict, the other flexible?|Be honest about how that dynamic feels, and find ways to compromise (e.g., shared meals vs. individual prep).",
        ResourceType = typeof(ProfileLifestyleModel))]
    public Diet? Diet { get; set; }

    [Custom(Name = "Religion_Name",
        WhyImportant = "Religious beliefs can deeply influence values, lifestyle, traditions, family expectations, and long-term decisions like marriage or raising children. Understanding each other’s spiritual views (or lack thereof) helps avoid hidden tensions and fosters mutual respect.",
        Tips = "You share the same religion?|Explore shared practices together—attending services, celebrating holidays, or praying as a couple can strengthen your bond.|Partner is religious and you're not?|Respect their beliefs without pretending. Be curious, not dismissive.|Different religions?|Have open talks early—discuss boundaries, important holidays, and whether faith will play a role in family life.|Religion is very important to one of you?|Understand how it shapes their values and daily life. Ask how you can support them even if you don’t share the same beliefs.|You’re both non-religious?|Discuss your values around ethics, traditions, and life purpose to ensure you're still aligned.|Religion impacts family involvement?|Be honest about how you’ll handle pressure from families if your beliefs differ.|Avoid future conflict?|Clarify early if religion must play a role in weddings, raising kids, or moral decisions.",
        ResourceType = typeof(ProfileLifestyleModel))]
    public Religion? Religion { get; set; }

    [Custom(Name = "FamilyInvolvement_Name", Description = "FamilyInvolvement_Description",
        WhyImportant = "The level of family involvement can shape daily routines, boundaries, holidays, decision-making, and conflict resolution. Compatibility here helps prevent stress caused by differing expectations around privacy, loyalty, or independence.",
        Tips = "One of you is heavily involved with family?|Discuss boundaries early. What’s loving for one may feel intrusive to the other.|You have different levels of involvement?|Talk about expectations—how often will you visit or communicate with families, and how much influence will they have?|Both are not very involved?|That may simplify logistics but talk about how you’ll build your own support system or traditions.|One partner values independence?|Respect their space. Don’t force family interactions they aren’t comfortable with.|Family is part of decision-making for one of you?|Be clear about limits—partners need to feel like their voice comes first.|Planning holidays or big life events?|Discuss how families will be included to avoid future resentment.",
        ResourceType = typeof(ProfileLifestyleModel))]
    public FamilyInvolvement? FamilyInvolvement { get; set; }

    [Custom(Name = "HaveChildren_Name",
        WhyImportant = "Having children—whether they live with the parent or not—affects time, priorities, emotional energy, and long-term planning. It also impacts how a new partner may fit into the family dynamic and future life decisions.",
        Tips = "One of you has children?|Talk openly about what role, if any, the new partner would play. Be patient and respectful of parenting responsibilities.|Children don’t live with the parent?|Understand that even if not present daily, parenting still affects availability, emotional focus, and long-term planning.|You both don’t have children?|Discuss future intentions—if one of you plans to have kids and the other doesn’t, that’s essential to clarify early.|Different views about parenting involvement?|One may want a more hands-on role than the other is ready for—set boundaries and go at a comfortable pace.|Already a parent and dating someone without kids?|Help them understand that parenting comes with responsibilities, unpredictability, and a need for flexibility.|Introducing a new partner to children?|Take it slow. Make sure trust is built before involving the kids emotionally.|One of you is unsure about having a role with stepchildren?|Honest discussions prevent confusion later—there’s no one-size-fits-all for blended families.",
        ResourceType = typeof(ProfileLifestyleModel))]
    public HaveChildren? HaveChildren { get; set; }

    [Custom(Name = "HavePets_Name",
        WhyImportant = "Pets influence lifestyle, daily routines, finances, travel flexibility, and even living arrangements. They can be a strong emotional bond—or a source of conflict if one partner isn't aligned with the other's preferences or values toward animals.",
        Tips = "One of you has pets and the other doesn't?|Clarify comfort levels—does the partner mind living with or caring for animals? Allergies or lifestyle clashes can arise.|One loves pets, the other doesn't want them?|Be honest about long-term compatibility. A strong pet preference can signal deeper lifestyle differences.|Different types of pets involved?|Discuss logistics—dogs may require walks and time, while cats or small pets might not. Exotic pets may come with unique care needs.|Both have pets?|Great, but still talk about introductions—how will the animals get along, and who will be responsible for what?|Neither has pets but one wants them?|Talk future plans early. Some people see pets as family, others prefer a pet-free home.|Strong attachment to a pet?|Respect it. They may see the pet as a companion or emotional support—don't minimize that bond.|Travel or sleep habits impacted by pets?|Discuss flexibility—who’ll stay home with pets, and whether pets sleep in the bed or not.",
        ResourceType = typeof(ProfileLifestyleModel))]
    public HavePets? HavePets { get; set; }

    [Custom(Name = "EducationLevel_Name",
        WhyImportant = "Education level can reflect someone's values, communication style, life experiences, and career trajectory. While it doesn’t define intelligence or character, differing educational backgrounds may influence lifestyle expectations, conversation dynamics, or shared goals.",
        Tips = "One has a higher level of education?|Avoid assumptions—education doesn't guarantee emotional maturity or compatibility. Respect each other's knowledge and strengths.|Different academic backgrounds?|Stay curious. Learn from each other's perspectives rather than viewing differences as gaps.|Similar education levels?|This can support smoother communication and aligned life plans—but don't mistake similarity for compatibility in other areas.|Education vs. ambition?|One might not have a degree but is still driven and capable—don’t equate lack of formal education with lack of potential.|Feeling insecure about your education?|Focus on your lived experience and emotional intelligence. Relationships thrive on mutual respect, not diplomas.|Discussing complex topics?|Gauge comfort levels. Use open dialogue to ensure both feel included without condescension or pressure.|Cultural or systemic barriers to education?|Be compassionate. Not everyone had equal access—understand the journey, not just the outcome.",
        ResourceType = typeof(ProfileLifestyleModel))]
    public EducationLevel? EducationLevel { get; set; }

    [Custom(Name = "CareerCluster_Name",
        WhyImportant = "Having different careers doesn’t necessarily cause conflicts in a relationship. However, when partners work in similar fields or industries, they often better understand each other’s challenges, such as irregular work hours, pressure to perform, public exposure, frequent travel, or the need to relocate. This shared understanding can reduce potential friction and create opportunities for mutual support.",
        Tips = "Careers in related fields?|Use your shared experiences to empathize and support each other through work-related stress and opportunities.|Careers in different fields?|Be curious and open to learning about your partner’s professional world to build respect.|One has a stable routine, the other irregular hours?|Set clear expectations for quality time and communication.|Frequent travel or possible relocation?|Discuss long-term plans and how to stay connected despite distance.|Significant income or status differences?|Focus on mutual respect and support, not comparison.|One partner is currently unemployed or in transition?|Offer patience and encouragement without pressure.|Careers with public exposure or high stress?|Check in regularly to support mental health and work-life balance.",
        ResourceType = typeof(ProfileLifestyleModel))]
    public CareerCluster? CareerCluster { get; set; }

    [Custom(Name = "LivingSituation_Name",
        WhyImportant = "Living arrangements affect daily routines, privacy, social interactions, and boundaries. Compatibility here helps partners understand each other’s comfort levels, expectations for personal space, and how they balance independence with companionship.",
        Tips = "Living alone?|Appreciate their need for privacy and independence. Respect their space while building connection.|Living with family?|Be aware of family dynamics and possible influences on your relationship. Support their need to balance both.|Living with friends?|Social environment may be lively—discuss how much time you’ll spend together versus with roommates.|Living with an ex-partner?|This can be complex; talk openly about boundaries, trust, and emotional safety.|Living with roommates?|Set clear expectations about shared spaces, guests, and communication.|Other living situations?|Clarify what works for them and how you can adapt to create a comfortable home environment.|Different living situations?|Respect each other’s lifestyle and negotiate how to spend quality time without discomfort.",
        ResourceType = typeof(ProfileLifestyleModel))]
    public LivingSituation? LivingSituation { get; set; }

    [Custom(Name = "TravelFrequency_Name",
        WhyImportant = "Travel habits affect how much time partners spend together, lifestyle compatibility, and openness to change or adventure. Differences in travel frequency can impact communication, planning, and relationship stability, especially in long-term commitments.",
        Tips = "Both travel rarely or never?|Enjoy predictable routines and easy planning. Use your shared stability to build a grounded relationship.|One travels frequently, the other rarely?|Discuss expectations for time apart and how to maintain connection during travel.|Both travel often?|Plan quality time intentionally to stay connected despite busy schedules.|One is a frequent nomad?|Clarify long-term goals—can the relationship support a highly mobile lifestyle?|Travel is work-related for one or both?|Support their career needs while balancing personal time.|Travel preferences differ?|Be flexible and compromise on trips and time spent together.|Worry about distance during travel?|Establish communication habits and reassure each other of commitment.",
        ResourceType = typeof(ProfileLifestyleModel))]
    public TravelFrequency? TravelFrequency { get; set; }

    [Custom(Name = "NetWorth_Name", Description = "NetWorth_Description",
        WhyImportant = "Financial harmony plays a crucial role in relationship stability and satisfaction. When partners have similar net worth levels, it often means their lifestyle expectations, spending habits, and financial goals are aligned or easier to negotiate. Large discrepancies in net worth can lead to imbalances in power, decision-making, or feelings of insecurity, which may cause tension or misunderstandings. Being compatible in this area helps couples build trust, share plans for the future, and avoid conflicts related to money—one of the leading causes of relationship stress globally.",
        Tips = "Discuss financial values early|Being open about what money means to each of you can prevent misunderstandings and build trust.|Respect differences in wealth|Avoid assumptions or judgments based on net worth alone—focus on how you manage money and make decisions.|Align on lifestyle expectations|Talk about daily spending habits and what kind of lifestyle you both want to maintain.|Plan for the future together|Share your financial goals and how you envision reaching them as a team.|Address financial stress openly|Money worries can affect emotional health; support each other and seek advice if needed.|Avoid power imbalances|Ensure financial differences don’t translate into control or resentment.|Celebrate what you have|Focus on shared goals and mutual support rather than comparing net worth.",
        ResourceType = typeof(ProfileLifestyleModel))]
    public NetWorth? NetWorth { get; set; }

    [Custom(Name = "AnnualIncome_Name", Description = "AnnualIncome_Description",
        WhyImportant = "Annual income influences daily lifestyle, short-term choices, and how easily partners can contribute to shared goals like travel, housing, or starting a family. While income alone doesn't define compatibility, major differences—if not discussed—can create friction around spending, fairness, and expectations. Financial strain or imbalance can also affect how responsibilities are divided, especially when one partner feels overburdened or undervalued. Compatibility in income makes it easier to make joint decisions, avoid resentment, and build a relationship on transparency and mutual respect.",
        Tips = "Talk about lifestyle expectations|Even with love, different income levels can lead to mismatched spending habits or priorities—discuss openly.|Balance contributions fairly|If incomes differ, focus on proportional contribution rather than splitting everything 50/50.|Avoid assumptions about money roles|Don’t assume the higher earner will always pay, or the lower earner should feel indebted—define your own rules.|Be honest about financial pressure|If one partner feels financial strain, talk about it early—silence can build resentment.|Value non-monetary contributions|Earning more doesn’t mean giving more emotionally—respect each other’s overall contributions.|Plan financial goals together|Agree on how you’ll save, spend, and invest—especially if income levels shift over time.|Respect ambition and comfort zones|Some prioritize career growth, others value work-life balance—recognize and support both perspectives.",
        ResourceType = typeof(ProfileLifestyleModel))]
    public AnnualIncome? AnnualIncome { get; set; }

    #endregion LIFESTYLE

    #region PERSONALITY

    //https://www.pnc.com/insights/personal-finance/spend/money-differences-in-relationships.html
    [Custom(Name = "MoneyPersonality_Name",
        Description = "MoneyPersonality_Description",
        WhyImportant = "Money is one of the top contributors to relationship conflict and divorce worldwide—not just because of how much someone earns, but because of how they relate to money. A person’s money personality influences how they save, spend, invest, and approach risk. When two people have very different attitudes toward money and don’t understand or respect those differences, it often leads to tension, mistrust, or recurring arguments. Being aware of each other’s financial mindset allows couples to communicate more clearly, reduce power struggles, and make joint decisions that feel fair and balanced.",
        Tips = "Understand your partner’s mindset|Each personality (e.g., visionary, nurturer) brings strengths—learn how your partner views money decisions.|Bridge different styles|If one saves and the other spends, set shared goals that respect both tendencies.|Avoid judging behavior|Calling someone “cheap” or “reckless” shuts down dialogue—focus on the “why” behind their habits.|Create a joint financial system|Even with different personalities, you can co-create rules for saving, budgeting, and big purchases.|Communicate before financial stress hits|Talk about values, priorities, and fears regularly—not just during conflicts.|Celebrate complementary strengths|One partner may plan long-term, the other may manage daily expenses—use both to your advantage.|Don’t avoid the topic|Silence around money often causes more harm than disagreements—normalize regular check-ins.",
        ResourceType = typeof(ProfileLifestyleModel))]
    public MoneyPersonality? MoneyPersonality { get; set; }

    //https://www.wikihow.com/Split-Expenses-As-a-Couple
    [Custom(Name = "SharedSpendingStyle_Name",
        WhyImportant = "This field reflects how each partner expects financial responsibilities to be divided—ranging from being a full provider to being fully supported. These expectations affect day-to-day spending, long-term planning, and emotional dynamics in a relationship. Imbalances in financial contribution aren’t necessarily problematic, but misaligned expectations about who pays for what often lead to tension, resentment, or power struggles. Many divorces and breakups are rooted not in income itself, but in how financial responsibility is shared and perceived. Understanding and aligning on this dynamic helps couples build clarity, trust, and mutual respect.",
        Tips = "Clarify expectations early|Misunderstandings often arise when one assumes shared costs will be split equally, while the other expects full support.|Avoid shame or judgment|There’s no “wrong” role—what matters is that both partners are comfortable and in agreement.|Balance power dynamics|If one provides financially, the other can still contribute emotionally or logistically—both roles deserve respect.|Discuss what fairness looks like|Whether it’s 50/50, proportional, or one-sided—decide together what feels right and sustainable.|Revisit the arrangement over time|Situations change—be open to renegotiating roles due to career shifts, health, or life goals.|Recognize hidden labor|Supporters or dependents often contribute in non-financial ways (e.g., caregiving, emotional support)—don’t overlook this.|Provider stress is real|If you’re the main financial provider, express your limits and emotional needs too.",
        ResourceType = typeof(ProfileLifestyleModel))]
    public SharedSpendingStyle? SharedSpendingStyle { get; set; }

    //https://www.oprah.com/relationships/finding-your-soul-mate-helen-fishers-formula-for-romance/all
    [Custom(Name = "RelationshipPersonality_Name",
        Description = "RelationshipPersonality_Description",
        WhyImportant = "Helen Fisher’s personality model helps explain how people behave in romantic relationships based on biological systems linked to brain chemistry. Each type—Explorer (driven by dopamine), Builder (serotonin), Director (testosterone), and Negotiator (estrogen)—has distinct patterns of communication, attraction, decision-making, and emotional needs. Misunderstandings often come not from lack of love, but from misreading or undervaluing a partner’s core personality. Knowing your partner’s type gives insight into their behavior and allows for better teamwork, empathy, and emotional safety in the relationship.",
        Tips = "If your partner is an Explorer|They’re spontaneous, curious, thrill-seeking, and energetic. They bring fun and adventure to the relationship but may struggle with long-term consistency or routine. Offer stability without limiting their freedom.|If your partner is a Builder|They’re loyal, responsible, traditional, and value structure and long-term planning. They’re excellent partners for those who seek commitment, but can be resistant to change or overly cautious. Respect their routines and offer small changes gradually.|If your partner is a Director|They’re analytical, confident, competitive, and direct. They value logic and competence. They may appear emotionally distant or impatient in emotional discussions. Focus on clear communication and don’t take bluntness personally.|If your partner is a Negotiator|They’re empathetic, intuitive, idealistic, and emotionally expressive. They often value harmony and deep emotional bonds. They may avoid conflict or overanalyze feelings. Offer reassurance and give space to process emotions.|Look for complementary traits|Builders and Explorers can balance security and excitement. Directors and Negotiators may align through intellect and emotional depth. Opposites can be strengths if appreciated.|Talk about differences openly|If you clash in pace or emotional needs, make space to talk about what energizes or stresses each of you. Mutual understanding prevents resentment.|Don’t box each other in|Everyone contains elements of multiple types. Use these insights as guides—not strict definitions—and allow space for growth over time.",
        ResourceType = typeof(ProfileLifestyleModel))]
    public RelationshipPersonality? RelationshipPersonality { get; set; }

    //https://www.psychologyjunkie.com/2017/09/05/myers-briggs-type-needs-relationship/
    [Custom(Name = "MBTI_Name",
        Description = "MBTI_Description",
        WhyImportant = "The MBTI (Myers-Briggs Type Indicator) is one of the most widely used personality models in the world, based on how people perceive the world and make decisions. The 16 types reflect differences in how individuals process information, manage energy, solve problems, express emotions, and navigate relationships. While no combination is inherently \"incompatible,\" certain pairings may require more intentional communication, compromise, or space for individuality. Understanding your partner’s MBTI can help you avoid misinterpretations and support each other in more constructive, tailored ways. People often assume compatibility comes from similarity—but in many cases, complementary traits (like a thinker with a feeler, or a planner with a spontaneous type) can create balance, as long as there’s mutual respect. Knowing each other’s type can also highlight recurring tensions, like one partner needing alone time (I) while the other seeks constant engagement (E), or one needing clarity (J) while the other thrives in flexibility (P).",
        Tips = "If your partner is an ISTJ|They’re practical, responsible, and structured. They value traditions and stability. Give them time to open up emotionally and respect their need for planning and routines.|If your partner is an ISFJ|They’re loyal, caring, and detail-oriented. They often put others first. Show appreciation often, and don’t take their quietness as disinterest.|If your partner is an INFJ|They’re deep thinkers, empathetic, and future-focused. They need meaningful conversation and purpose. Be authentic and give them space to recharge.|If your partner is an INTJ|They’re strategic, independent, and often private. They value intelligence and efficiency. Avoid emotional drama; instead, use logic and directness when discussing concerns.|If your partner is an ISTP|They’re independent, spontaneous, and analytical. They dislike being micromanaged. Give them freedom and trust their problem-solving approach.|If your partner is an ISFP|They’re artistic, peaceful, and sensitive. They live in the moment and value emotional safety. Avoid harsh criticism and offer gentle support.|If your partner is an INFP|They’re idealistic, imaginative, and deeply emotional. They care about values and meaning. Be honest and open—don’t dismiss their emotions as irrational.|If your partner is an INTP|They’re curious, inventive, and logic-driven. They love exploring ideas, not emotions. Be patient with emotional conversations and don’t demand constant affirmation.|If your partner is an ESTP|They’re energetic, action-oriented, and bold. They thrive in the present and dislike overplanning. Match their energy or give them space to express it.|If your partner is an ESFP|They’re lively, fun, and people-focused. They seek excitement and connection. Be supportive without being too rigid or serious all the time.|If your partner is an ENFP|They’re enthusiastic, creative, and expressive. They value authenticity. Encourage their ideas and don’t hold them back with too many rules.|If your partner is an ENTP|They’re witty, bold, and intellectually curious. They enjoy debates and new experiences. Keep things fresh and don’t take their challenges personally.|If your partner is an ESTJ|They’re organized, decisive, and goal-driven. They like structure and responsibility. Respect their leadership style and communicate clearly.|If your partner is an ESFJ|They’re nurturing, sociable, and dependable. They care about group harmony. Appreciate their efforts and include them in your plans.|If your partner is an ENFJ|They’re charismatic, empathetic, and idealistic. They’re natural caregivers. Be honest, meet them emotionally, and show appreciation.|If your partner is an ENTJ|They’re assertive, strategic, and ambitious. They often take charge. Communicate with confidence, and don’t take intensity as lack of care.|Learn your dynamic over time|Even “incompatible” types can thrive if they understand each other’s mental wiring and emotional needs.|Use MBTI as a tool, not a label|People grow and adapt. Personality is fluid in real life. Keep conversations open, not fixed in stereotypes.|Balance similarities and differences|Some types click due to shared styles, others complement through contrast. What matters most is mutual effort and respect.",
        ResourceType = typeof(ProfileLifestyleModel))]
    public MyersBriggsTypeIndicator? MBTI { get; set; }

    //https://thehoneycombers.com/singapore/5-love-languages/
    [Custom(Name = "LoveLanguage_Name",
        Description = "LoveLanguage_Description",
        WhyImportant = "Understanding how your partner gives and receives love can deeply affect how connected and valued they feel in the relationship. People often express love in the way they wish to receive it—so if your love languages don't match, you might both be showing love but missing each other emotionally. Misunderstandings often arise not from a lack of affection, but from a mismatch in how it’s communicated. Learning and adapting to your partner’s love language is a practical way to strengthen intimacy, build trust, and reduce conflict. It also helps prevent the feeling of “I'm giving so much, but it’s not enough,” by making sure the effort aligns with what actually matters to your partner.",
        Tips = "If your partner values Words of Affirmation|Express appreciation, encouragement, or affection regularly. Even small compliments or thoughtful texts can go a long way. Silence or harsh words may hurt more than you expect.|If your partner values Acts of Service|Actions speak louder than words. Help with their workload, do small things without being asked, and follow through on promises. Inconsistency can feel like neglect.|If your partner values Receiving Gifts|It’s not about price—it’s about thoughtfulness. Small, meaningful tokens or surprises show that you were thinking of them. Forgetting special occasions may feel very personal.|If your partner values Quality Time|Being fully present is key. Put away distractions, engage in shared activities, and prioritize intentional time together. Canceling plans can feel like rejection.|If your partner values Physical Touch|Touch is their emotional connector. Hugs, kisses, holding hands, or sitting close make them feel loved. Physical distance during conflict may be deeply upsetting.|Your love language isn't theirs|Don't assume what works for you works for them. Learn to speak their language—not just your own.|Mismatch in styles?|Be intentional. It might feel unnatural at first, but consistent effort creates new habits and emotional closeness.|Use love languages to de-escalate conflict|Sometimes frustration comes from unmet emotional needs. Reconnecting in their preferred way can calm tension.|They may have more than one|Most people have a primary and secondary love language. Observe patterns and ask questions to better meet their needs.|Love languages can change over time|Life stages or stress can shift what someone needs most. Keep checking in as the relationship evolves.",
        ResourceType = typeof(ProfileLifestyleModel))]
    public LoveLanguage? LoveLanguage { get; set; }

    //https://www.bustle.com/articles/59610-17-sex-tips-for-couples-in-long-term-relationships-because-keeping-it-fresh-takes-more-than-a
    [Custom(Name = "SexPersonality_Name",
        Description = "SexPersonality_Description",
        WhyImportant = "Sexual compatibility isn't only about preferences or frequency—it's about the emotional, psychological, and behavioral patterns each person brings into intimacy. People have different motivations, priorities, and communication styles when it comes to sex. Some use it for connection, others for exploration, stress relief, emotional affirmation, or spiritual bonding. If these needs are misaligned or misunderstood, it can create frustration, shame, or disconnection. Understanding each other’s sex personality helps foster empathy, improves communication, reduces pressure, and opens the door for a more satisfying and respectful intimate life—something strongly linked to long-term relationship success.",
        Tips = "Decompresser|They use sex to relax and unwind. Avoid making them feel pressured to perform or overly romantic every time. A calm, judgment-free space builds connection.|Explorer|Curious and open to trying new things. Keep an open mind, encourage experimentation, but establish clear boundaries together.|Fair Trader|Seeks balance—if they give, they expect to receive. Ensure open, fair communication about needs, or they may feel taken for granted.|Giver|Gets fulfillment from their partner’s pleasure. Appreciate their generosity, but also check in to make sure they feel valued—not just useful.|Guardian|Cautious and protective. They need time, trust, and emotional safety. Avoid rushing intimacy or misreading slowness as disinterest.|Passion Pursuer|Craves intensity and closeness. Match their energy when possible, but also help balance passion with emotional regulation.|Pleasure Seeker|Focuses on enjoyment and stimulation. Keep things fun and engaging, but discuss limits if their focus on sensation overrides emotional intimacy.|Prioritizer|Sex is central to their identity and well-being. Treat their needs seriously and don’t minimize the role intimacy plays in their life.|Romantic|Connects sex to love and emotional bonding. If you're more casual or spontaneous, show affection in ways that still support emotional closeness.|Spiritualist|Views sex as transcendent or sacred. Respect their mindset, even if you don’t share it, and create space for meaningful connection.|Thrill Seeker|Excited by novelty and risk. Balance their desire for adventure with mutual safety and clear consent—variety is important, but so is trust.|You have different priorities|Use curiosity—not criticism—to explore your differences. Focus on shared experiences and mutual satisfaction.|Misunderstandings may happen|Talk openly about motivations behind intimacy. Often, the issue isn’t sex itself but how it’s interpreted.|Personalities can evolve|What someone needs sexually can shift with age, stress, or life events. Keep checking in and be flexible together.|No one type is “better”|Avoid ranking or judging styles. Compatibility is about mutual respect, openness, and willingness to adapt.",
        ResourceType = typeof(ProfileLifestyleModel))]
    public SexPersonality? SexPersonality { get; set; }

    [Custom(Name = "SexPersonalityPreferences_Name", Description = "SexPersonalityPreferences_Description",
        ResourceType = typeof(ProfileLifestyleModel))]
    public HashSet<SexPersonality> SexPersonalityPreference { get; set; } = [];

    #endregion PERSONALITY

    #region INTEREST

    [Custom(Name = "Food", ResourceType = typeof(ProfileInterestModel))]
    public HashSet<Food> Food { get; set; } = [];

    [Custom(Name = "Vacation", ResourceType = typeof(ProfileInterestModel))]
    public HashSet<Vacation> Vacation { get; set; } = [];

    [Custom(Name = "Sports", ResourceType = typeof(ProfileInterestModel))]
    public HashSet<Sports> Sports { get; set; } = [];

    [Custom(Name = "LeisureActivities", ResourceType = typeof(ProfileInterestModel))]
    public HashSet<LeisureActivities> LeisureActivities { get; set; } = [];

    [Custom(Name = "MusicGenre", ResourceType = typeof(ProfileInterestModel))]
    public HashSet<MusicGenre> MusicGenre { get; set; } = [];

    [Custom(Name = "MovieGenre", ResourceType = typeof(ProfileInterestModel))]
    public HashSet<MovieGenre> MovieGenre { get; set; } = [];

    [Custom(Name = "TVGenre", ResourceType = typeof(ProfileInterestModel))]
    public HashSet<TVGenre> TVGenre { get; set; } = [];

    [Custom(Name = "ReadingGenre", ResourceType = typeof(ProfileInterestModel))]
    public HashSet<ReadingGenre> ReadingGenre { get; set; } = [];

    #endregion INTEREST

    #region RELATIONSHIP

    [Custom(Name = "SharedFinances",
        WhyImportant = "How a couple handles shared finances can significantly affect daily decision-making, autonomy, and long-term stability. It's not just about who pays what, but about how each partner views money, control, trust, and fairness. Some people prefer full transparency, while others need financial independence to feel secure. If not aligned, these differences can cause stress, resentment, or power imbalance. Clarity around money management styles helps set expectations, prevent conflict, and foster mutual respect. It's also crucial for planning shared goals like saving, investing, or raising a family.",
        Tips = "Joint Accounts|This setup promotes transparency and unity, but it requires high trust and aligned spending habits—regular check-ins help avoid surprises.|Separate Accounts|Maintains personal autonomy, useful if you both value independence—but can lead to a sense of separation if emotional investment in shared expenses is low.|Hybrid Approach|Allows balance: shared expenses are managed jointly, while personal purchases remain separate—helps prevent conflict over differing habits.|Talk early, talk often|Even if things feel smooth, check in regularly about expectations, goals, and feelings around money.|Align goals|Whether saving for a home or planning a trip, align on financial priorities so both partners feel involved.|Avoid power imbalances|If one partner earns more, discuss how expenses are split fairly, not just equally.|Respect boundaries|Some prefer control over their own money due to past experiences—honor that without assuming it’s distrust.|Adapt over time|Financial arrangements may need to shift due to career changes, children, or unexpected events—be open to renegotiation.|Use tools together|Budgeting apps or shared spreadsheets can help keep things transparent and reduce misunderstandings.",
        ResourceType = typeof(ProfileRelationshipModel))]
    public SharedFinances? SharedFinances { get; set; }

    [Custom(Name = "ConflictResolutionStyle",
        WhyImportant = "How each person handles conflict can either strengthen or erode a relationship over time. Some prefer to address issues head-on, others need space to process, and some avoid conflict altogether. These differences can cause major misunderstandings—what feels like “handling it” to one may feel like “attacking” or “withdrawing” to the other. Recognizing and respecting each other’s conflict style helps prevent escalation, improves emotional safety, and builds trust. Even incompatible styles can work together when both partners understand the underlying needs behind their approaches.",
        Tips = "Direct Resolution|If you or your partner prefer direct communication, make sure timing and tone are respectful—being clear doesn’t mean being harsh.|Reflective Approach|These partners need time to process before responding. Give them space—but don’t confuse this with avoidance.|Avoidance/Denial|Avoiders often want peace, not disconnection. Help them feel safe discussing uncomfortable topics without pressure or blame.|Respect pacing|If one wants to solve the issue now and the other needs time, agree on a pause-and-return plan to balance urgency with processing.|Create safe space|Set rules for fair conflict (no yelling, no blame, etc.) so both feel heard, regardless of their style.|Don’t force sameness|Your partner may never fight like you do—focus on compromise, not conversion.|Use shared tools|Try structured tools like “I feel / I need” statements or scheduled check-ins to depersonalize difficult topics.|Balance emotional and logical needs|Direct types may focus on facts; reflective ones on emotions. Acknowledge both to move forward together.|Avoid “silent treatment” cycles|Silence can feel like punishment—communicate if you need space and when you'll revisit the topic.",
        ResourceType = typeof(ProfileRelationshipModel))]
    public ConflictResolutionStyle? ConflictResolutionStyle { get; set; }

    [Custom(Name = "HouseholdManagement",
        WhyImportant = "How household tasks are managed reflects each partner’s expectations about roles, time, and fairness. Misalignment in this area—like one person feeling overburdened or another feeling left out—can lead to long-term resentment and imbalance. Whether a couple shares chores equally, one takes on more, or they hire outside help, what matters most is clarity and agreement. Aligning expectations here contributes to daily harmony and avoids unnecessary friction.",
        Tips = "Shared Responsibilities|If both partners contribute equally, revisit task distribution periodically to keep things fair and balanced as circumstances change.|Primary Responsibilities|When one person manages most tasks, express appreciation and regularly check if they're feeling overwhelmed or need support.|External Support|If you rely on hired help (e.g., cleaners, nannies), make sure both agree on costs, roles, and boundaries.|Avoid silent resentment|Don’t assume your partner “should just notice” what needs doing—talk openly about roles and expectations.|Divide based on strengths, not stereotypes|Just because one partner cooks well doesn’t mean they must—discuss what works best for both.|Use visible systems|Shared calendars, task lists, or chore apps can reduce confusion and help track responsibilities.|Be flexible with change|Workloads shift—what worked last year might not work now. Reevaluate when jobs, kids, or health change.|Appreciate the unseen tasks|Mental load (e.g., remembering appointments or restocking supplies) matters too—acknowledge and share that load.|Don’t shame different standards|One person might tolerate mess more—agree on a baseline both can live with.",
        ResourceType = typeof(ProfileRelationshipModel))]
    public HouseholdManagement? HouseholdManagement { get; set; }

    [Custom(Name = "TimeTogetherPreference",
        WhyImportant = "How much time each person wants to spend with their partner can deeply affect the emotional connection and rhythm of the relationship. While some people thrive on near-constant companionship, others need regular time alone to recharge. If mismatched, one partner may feel neglected while the other feels smothered. Discussing these needs early on helps prevent misunderstandings and allows each person to feel secure, respected, and emotionally fulfilled.",
        Tips = "Alone Time|If your partner values alone time, it doesn't mean they love you less—they may just recharge better in solitude. Respecting that space avoids pressure and allows them to show up more fully when you're together.|Balanced Time|This preference often requires active communication. Regularly check in to maintain a healthy rhythm between togetherness and independence, especially during life changes.|Quality Together|If your partner thrives on shared time, be intentional when you're together—put away distractions and engage fully. Even small daily rituals (like shared meals or evening walks) can go a long way.|Don’t assume your style is “normal”|Everyone has different needs—express yours, and invite your partner to do the same without judgment.|Use time creatively|Busy schedules don’t mean disconnection. Even a 15-minute focused check-in can strengthen emotional bonds.|Reassure without overcommitting|If you need space, clarify it’s about you—not about pulling away from the relationship.|Adjust based on life stage|Needs shift with stress, work, or health. Stay flexible and open to renegotiating how much time you spend together.",
        ResourceType = typeof(ProfileRelationshipModel))]
    public TimeTogetherPreference? TimeTogetherPreference { get; set; }

    [Custom(Name = "OppositeSexFriendships", Description = "OppositeSexFriendships_Description",
        WhyImportant = "People have different comfort levels when it comes to their partner having close friendships with members of the opposite sex. These boundaries are shaped by past experiences, cultural values, personality, and trust levels. If unspoken, mismatched expectations can lead to jealousy, insecurity, or even accusations. Being upfront about what each person is comfortable with builds trust and helps prevent misunderstandings or emotional tension later on.",
        Tips = "Comfortable|If you're both comfortable, maintain transparency. Introduce close friends to your partner and include them in your social circle when appropriate to reinforce trust.|Boundaries Needed|Clarify what boundaries look like—Is it frequency of contact? Private time alone? Type of conversations? Agreeing on mutual respect keeps things balanced.|Uncomfortable|If one of you feels uneasy, don’t dismiss it as jealousy. Explore the root of the discomfort and see if there’s a compromise that respects both partners’ feelings.|Communicate proactively|Talk about expectations before a situation arises. It’s easier to set respectful limits in calm moments than in reactive ones.|Avoid secrecy|Keeping opposite-sex friendships hidden—even with innocent intentions—can quickly erode trust.|Include, don’t exclude|Inviting your partner to meet and engage with your friends can help reduce suspicion or discomfort.|Understand cultural context|In some cultures, opposite-sex friendships are more sensitive. Consider your partner’s background when discussing this topic.|Reassure without guilt|If your partner needs reassurance, offer it—but don’t tolerate control. Healthy boundaries go both ways.",
        ResourceType = typeof(ProfileRelationshipModel))]
    public OppositeSexFriendships? OppositeSexFriendships { get; set; }

    #endregion RELATIONSHIP

    #region GOAL

    [Custom(Name = "RelationshipIntentions",
        WhyImportant = "Relationship alignment starts with shared intentions. Whether someone is seeking a long-term commitment, cohabitation, or marriage, clarity here prevents emotional mismatches and wasted time. Mismatched intentions—like one partner wanting to live together while the other envisions marriage—can lead to frustration, miscommunication, or heartbreak. Knowing your partner’s vision for the future helps both sides decide if they're investing in the same type of relationship journey.",
        Tips = "Align goals early|Talk openly about your long-term goals early in the relationship—don't assume you're on the same page.|Respect different timelines|Even if your intentions match, your pace might differ. Be patient and find a rhythm that works for both.|Avoid pressure|If one person wants marriage and the other isn't ready, discuss openly rather than pushing for immediate decisions.|“Live Together” ≠ “Marriage prep”|Some people see cohabitation as a step toward marriage; others see it as an end goal. Clarify what it means for you both.|Intentions can evolve|Be open to change—but don’t stay in a mismatched relationship hoping the other person will “come around.”|Be honest with yourself|Don’t downplay your true desires to fit someone else’s plan—it usually backfires long-term.|Revisit the conversation|Even if aligned at the start, revisit intentions regularly. People’s needs and priorities can shift over time.",
        ResourceType = typeof(ProfileGoalModel))]
    public HashSet<RelationshipIntention> RelationshipIntentions { get; set; } = [];

    [Custom(Name = "WantChildren",
        WhyImportant = "Desire for children is one of the most foundational topics in long-term relationships. It influences lifestyle, values, priorities, finances, and even where and how a couple chooses to live. A mismatch in this area—such as one partner being certain they want kids while the other is firmly opposed—often leads to heartbreak, even if everything else aligns. Understanding each other’s stance early helps avoid building emotional investment on incompatible goals. Even if someone is undecided, that uncertainty itself should be taken seriously.",
        Tips = "Both want kids?|You can start discussing timelines, parenting values, and what kind of family life you both envision.|One wants, one doesn’t?|This is a core mismatch. Avoid assuming either of you will \"change your mind\"—talk openly and honestly.|One is unsure?|Explore what's behind the uncertainty: life stage, past experiences, fears, or practical concerns.|Similar goals, different timing?|Make sure you're aligned on when you’d like to have kids—years apart can create pressure later.|Already have children?|If only one of you is a parent, clarify whether the other is open to parenting stepchildren or adding more.|Don't want kids?|Make sure you're both on the same page about living a child-free lifestyle and what that means long-term.|Cultural or family pressure?|Share how external expectations may be influencing your decision—and respect each other's boundaries.",
        ResourceType = typeof(ProfileGoalModel))]
    public WantChildren? WantChildren { get; set; }

    [Custom(Name = "Relocation",
        WhyImportant = "Relocation preferences significantly impact the long-term feasibility of a relationship, especially in global or long-distance matches. Even for local matches, knowing whether someone is open—or resistant—to moving helps clarify if shared life plans are possible. One partner may dream of living abroad or in a different city, while the other feels deeply rooted where they are. These preferences affect career decisions, family planning, and lifestyle choices. Discussing relocation early reduces the risk of future conflict over where and how you’ll build a life together.",
        Tips = "Local now, future global?|Even if you're in the same location today, talk about whether one of you plans to move in the future.|Different views on moving?|Be honest. If one is rooted and the other is restless, find middle ground or reconsider long-term fit.|Willing to move for love?|Make sure you're not ignoring your own goals or values just to match someone else's life plan.|Long-distance match?|Clarify early if either of you is truly open to relocating, or if it’s a casual preference.|City vs. country?|Some people are okay with changing cities but not countries. Clarify what \"relocation\" really means to you both.|Family and career ties?|Consider how children, jobs, or family responsibilities might affect your ability—or willingness—to move.|Test the waters together|If relocation is a possibility, plan short trips or temporary stays together before making major moves.",
        ResourceType = typeof(ProfileGoalModel))]
    public Relocation? Relocation { get; set; }

    [Custom(Name = "IdealPlaceToLive",
        WhyImportant = "Where you want to live shapes your daily lifestyle, social opportunities, and long-term satisfaction. Differences in preferences—whether urban bustle, quiet suburbs, or rural calm—can affect everything from commute times to social life to access to amenities. If partners have conflicting ideas about their ideal environment, it can lead to compromises that leave one or both unhappy. Understanding this helps set expectations and avoid frustration, especially when planning for the future.",
        Tips = "Urban|If your partner loves city life, support their need for access to culture, nightlife, and convenience, even if it means more noise or crowds.|Suburban|If they prefer suburbs, respect their desire for space, safety, and community feel. Balance this with social activities outside the neighborhood.|Rural|For rural lovers, acknowledge the need for nature, quiet, and simplicity. Discuss how to manage distance from services or social opportunities.|Flexible|If one or both are flexible, leverage this as a strength to explore compromises and adapt to life changes together.|Discuss expectations|Talk about how often you want to visit friends, family, or cultural venues to find a place that suits both.|Consider future needs|Think about work, children, health, and aging—what suits you now might change over time.|Try before deciding|If possible, spend time in different settings together before committing to one lifestyle.",
        ResourceType = typeof(ProfileGoalModel))]
    public IdealPlaceToLive? IdealPlaceToLive { get; set; }

    #endregion GOAL
}