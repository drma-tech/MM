namespace MM.Shared.Models.Dashboard;

public class LastUsersCache : CacheDocument<LastUsers>
{
    public LastUsersCache()
    {
    }

    public LastUsersCache(LastUsers data, string key) : base(key, data, TtlCache.OneDay)
    {
    }
}