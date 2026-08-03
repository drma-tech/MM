namespace MM.Shared.Enums;

public enum AnnualIncome
{
    [FieldSettings("$0 - $500")]
    From0To500 = 1,

    [FieldSettings("$500 - $750")]
    From500To750 = 2,

    [FieldSettings("$750 - $1,000")]
    From750To1K = 3,

    [FieldSettings("$1,000 - $1,600")]
    From1KTo1Point6K = 4,

    [FieldSettings("$1,600 - $2,500")]
    From1Point6KTo2Point5K = 5,

    [FieldSettings("$2,500 - $3,800")]
    From2Point5KTo3Point8K = 6,

    [FieldSettings("$3,800 - $5,700")]
    From3Point8KTo5Point7K = 7,

    [FieldSettings("$5,700 - $8,500")]
    From5Point7KTo8Point5K = 8,

    [FieldSettings("$8,500 - $12,800")]
    From8Point5KTo12Point8K = 9,

    [FieldSettings("$12,800 - $19,200")]
    From12Point8KTo19Point2K = 10,

    [FieldSettings("$19,200 - $28,800")]
    From19Point2KTo28Point8K = 11,

    [FieldSettings("$28,800 - $43,200")]
    From28Point8KTo43Point2K = 12,

    [FieldSettings("$43,200 - $64,800")]
    From43Point2KTo64Point8K = 13,

    [FieldSettings("$64,800 - $97,300")]
    From64Point8KTo97Point3K = 14,

    [FieldSettings("$97,300 - $145,900")]
    From97Point3KTo145Point9K = 15,

    [FieldSettings("$145,900 - $218,900")]
    From145Point9KTo218Point9K = 16,

    [FieldSettings("$218,900+")]
    Over218Point9K = 17,
}