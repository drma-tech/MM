namespace MM.Shared.Models.Dashboard;

public class SumUsersCache(string id, SumUsers data) : CacheDocumentData<SumUsers>(new CacheIdentity(id), data, TtlCache.OneDay)
{
}

public class SumUsers
{
    public int Countries { get; set; }
    public int Cities { get; set; }
    public int TotalUsers { get; set; }
    public int RecentlyJoined { get; set; }
    public ICollection<SumUsersRegion> Regions { get; set; } = [];
}

public class SumUsersRegion
{
    public string? Name { get; set; }
    public ICollection<string> Cities { get; set; } = [];
}