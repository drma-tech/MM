namespace MM.Shared.Models.Dashboard;

public class SumUsers
{
    public int Countries { get; set; }
    public int Cities { get; set; }
    public int TotalUsers { get; set; }
    public int RecentlyJoined { get; set; }
    public List<Region> Regions { get; set; } = [];
}

public class Region
{
    public string? Name { get; set; }
    public List<string> Cities { get; set; } = [];
}