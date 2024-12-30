namespace MM.Shared.Models.Profile
{
    public class InviteCache : CacheDocument<InviteModel>
    {
        public InviteCache()
        { }

        public InviteCache(InviteModel data, string key) : base(key, data, ttlCache.one_month)
        { }
    }

    public class InviteModel
    {
        public List<string> UserIds { get; set; } = [];
    }
}