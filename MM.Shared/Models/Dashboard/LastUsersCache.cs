namespace MM.Shared.Models.Dashboard;

public class LastUsersCache(string id, LastUsers data) : CacheDocumentData<LastUsers>(new CacheIdentity(id), data, TtlCache.OneDay)
{
}

public class LastUsers
{
    public List<LastUsersItem> Items { get; set; } = [];
}

public class LastUsersItem
{
    public Country? Country { get; set; }
    public EnumFieldObject<Country>? CountryObj { get; set; }
    public DateTime Created { get; set; }
}