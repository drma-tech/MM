namespace MM.Shared.Models.Dashboard;

public class LastRegionUsersCache : CacheDocument<LastRegionUsers>
{
    public LastRegionUsersCache()
    {
    }

    public LastRegionUsersCache(LastRegionUsers data, string key) : base(key, data, TtlCache.OneDay)
    {
    }
}