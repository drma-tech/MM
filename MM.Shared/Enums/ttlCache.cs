﻿namespace MM.Shared.Enums;

public enum TtlCache
{
    OneHour = 60 * 60 * 1,
    SixHours = 60 * 60 * 6,
    HalfDay = 60 * 60 * 12,
    OneDay = 60 * 60 * 24,
    OneWeek = 60 * 60 * 24 * 7,
    OneMonth = 60 * 60 * 24 * 30,
    ThreeMonths = 60 * 60 * 24 * 30 * 3,
    SixMonths = 60 * 60 * 24 * 30 * 6
}
