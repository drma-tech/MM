namespace MM.Shared.Models.Dashboard
{
    public class LastRegionUsers
    {
        public List<LastRegionUsersItem> Items { get; set; } = [];
    }

    public class LastRegionUsersItem
    {
        public string? Id { get; set; }
        public string? Nickname { get; set; }
        public string? State { get; set; }
    }
}