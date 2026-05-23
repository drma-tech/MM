using MM.WEB.Modules.Support.Core;

namespace MM.WEB.Core
{
    public static class AppInfo
    {
        public static string CompanyName { get; set; } = "DRMA Tech";
        public static string CompanyWebSite { get; set; } = $"https://www.drma-tech.com";

        public static string Title { get; set; } = "Modern Matchmaker";
        public static string Domain { get; set; } = "modern-matchmaker";
        public static string WebSite { get; set; } = $"https://www.{Domain}.com";
        public static int Year { get; set; } = 2025;

        public static readonly string? _windowsId = "9n8h01jxft99";
        public static readonly string? _googleId = "com.modern_matchmaker.www.twa";
        public static readonly string? _appleId = "id6756202435";
        public static readonly string? _huaweiId = "C115460887";
        public static readonly string? _xiaomiId = "com.modern_matchmaker.www.twa";
        public static readonly string? _amazonId = null;

        public static readonly StoreLink[] Stores =
        [
            new(Platform.windows, "Microsoft Store", $"https://apps.microsoft.com/detail/{_windowsId}", "/logo/microsoft-store.png" ),
            new(Platform.play, "Google Play", $"https://play.google.com/store/apps/details?id={_googleId}", "/logo/google-play.png" ),
            new(Platform.ios, "App Store", $"https://apps.apple.com/us/app/{_appleId}", "/logo/app-store.png" ),
            new(Platform.huawei, "Huawei AppGallery", $"https://appgallery.huawei.com/app/{_huaweiId}", "/logo/huawei.png" ),
            new(Platform.xiaomi, "Xiaomi GetApps", $"https://global.app.mi.com/details?id={_xiaomiId}", "/logo/xiaomi.png" ),
            //new(Platform.amazon, "Amazon Appstore", $"https://www.amazon.com/gp/product/{_amazonId}", "/logo/amazon.png" )
        ];

        public static readonly ProductLink[] Products =
        [
            new("Streaming Discovery", "Discover Movies and Series on Streaming Platforms", "https://www.streamingdiscovery.com", "/logo/streamingdiscovery.png", true ),
            //new("Modern Matchmaker", "Find a compatible partner through Smart Matchmaking", "https://www.modern-matchmaker.com", "/logo/modern-matchmaker.png", true ),
            new("My Next Spot", "Find the Best Cities and Countries to Live or Travel", "https://www.my-next-spot.com", "/logo/next-spot.png", false ),
            new("WebStandards", "Web Standards Generator for Websites and PWAs", "https://www.web-standards.com", "/logo/webstandards.png", false ),
       ];
    }
}
