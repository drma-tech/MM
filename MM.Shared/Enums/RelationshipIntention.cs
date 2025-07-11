﻿using MM.Shared.Enums.Resources;

namespace MM.Shared.Enums;

public enum RelationshipIntention
{
    [Custom(Name = "Serious_Name", Description = "Serious_Description", ResourceType = typeof(Intentions))]
    Serious = 1,

    [Custom(Name = "LiveTogether_Name", Description = "LiveTogether_Description", ResourceType = typeof(Intentions))]
    LiveTogether = 2,

    [Custom(Name = "Married_Name", Description = "Married_Description", ResourceType = typeof(Intentions))]
    Married = 3
}