namespace MM.Shared.Models.Dashboard;

public class LastRegionUsersCache(string id, LastRegionUsers data) : CacheDocumentData<LastRegionUsers>(new CacheIdentity(id), data, TtlCache.OneWeek)
{
}

public class LastRegionUsers
{
    public ICollection<LastRegionUsersItem> Items { get; set; } = [];
}

public class LastRegionUsersItem
{
    public string? Id { get; set; }
    public string? Nickname { get; set; }
    public string? State { get; set; }
}