namespace MM.Shared.Enums;

public enum NetWorth
{
    [FieldSettings("$0 - $10,000")]
    From0To10K = 1,

    [FieldSettings("$10,000 - $15,000")]
    From10KTo15K = 2,

    [FieldSettings("$15,000 - $22,000")]
    From15KTo22K = 3,

    [FieldSettings("$22,000 - $33,000")]
    From22KTo33K = 4,

    [FieldSettings("$33,000 - $50,000")]
    From33KTo50K = 5,

    [FieldSettings("$50,000 - $75,000")]
    From50KTo75K = 6,

    [FieldSettings("$75,000 - $113,000")]
    From75KTo113K = 7,

    [FieldSettings("$113,000 - $170,000")]
    From113KTo170K = 8,

    [FieldSettings("$170,000 - $256,000")]
    From170KTo256K = 9,

    [FieldSettings("$256,000 - $384,000")]
    From256KTo384K = 10,

    [FieldSettings("$384,000 - $576,000")]
    From384KTo576K = 11,

    [FieldSettings("$576,000 - $864,000")]
    From576KTo864K = 12,

    [FieldSettings("$864,000 - $1,300,000")]
    From864KTo1Point3M = 13,

    [FieldSettings("$1,300,000+")]
    Over1Point3M = 14,
}