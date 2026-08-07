namespace MM.Shared.Models.Blocked;

public class LogCache(string id, LogModel data) : CacheDocumentData<LogModel>(new CacheIdentity(id), data, TtlCache.OneWeek)
{
}

public class LogModel
{
    public List<string> Logs { get; set; } = [];
}