namespace MM.Shared.Models.Blocked;

public class DataBlockedCache : CacheDocument<object>
{
    public DataBlockedCache()
    {
    }

    public DataBlockedCache(string key, TtlCache ttl) : base(key, null, ttl)
    {
    }
}