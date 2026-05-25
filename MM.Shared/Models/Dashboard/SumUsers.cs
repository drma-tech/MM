namespace MM.Shared.Models.Dashboard;

public class SumUsers
{
    public int Countries { get; set; }
    public int Cities { get; set; }
    public int TotalUsers { get; set; }
    public int RecentlyJoined { get; set; }
    public List<SumUsersRegion> Regions { get; set; } = [];
}

public class SumUsersRegion
{
    public string? Name { get; set; }
    public List<string> Cities { get; set; } = [];
}