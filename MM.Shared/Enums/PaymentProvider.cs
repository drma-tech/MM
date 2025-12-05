namespace MM.Shared.Enums
{
    public enum PaymentProvider
    {
        [Custom(Name = "Generic")]
        Generic = 1,

        [Custom(Name = "Microsoft Store")]
        Microsoft = 2,

        [Custom(Name = "Google Play")]
        Google = 3,

        [Custom(Name = "App Store")]
        Apple = 4
    }
}
