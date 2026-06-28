namespace MM.Shared.Models.Dashboard
{
    public class LastUsers
    {
        public List<LastUsersItem> Items { get; set; } = [];
    }

    public class LastUsersItem
    {
        public Country Country { get; set; }
        public DateTime Created { get; set; }
    }
}