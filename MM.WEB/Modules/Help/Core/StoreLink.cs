namespace MM.WEB.Modules.Support.Core
{
    public class StoreLink(MM.Shared.Enums.Platform platform, string store, string url, string logo)
    {
        public MM.Shared.Enums.Platform Platform { get; set; } = platform;
        public string Store { get; set; } = store;
        public string Url { get; set; } = url;
        public string Logo { get; set; } = logo;
    }
}