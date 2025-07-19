namespace MM.Shared.Models.Profile;

public class InviteCache : CacheDocument<InviteModel>
{
    public InviteCache()
    {
    }

    public InviteCache(InviteModel data, string key) : base(key, data, TtlCache.OneMonth)
    {
    }
}

public class InviteModel
{
    public List<string> UserIds { get; set; } = [];
}