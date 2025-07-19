namespace MM.Shared.Models.Dashboard;

public class SumUsersCache : CacheDocument<SumUsers>
{
    public SumUsersCache()
    {
    }

    public SumUsersCache(SumUsers data, string key) : base(key, data, TtlCache.OneDay)
    {
    }
}