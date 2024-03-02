namespace NightlifeCoordinationAPI.Models;

public class Business
{
    public string? Alias { get; set; }
    public List<Category>? Categories { get; set; }
    public Coordinates? Coordinates { get; set; }
    public string? DisplayPhone { get; set; }
    public double? Distance { get; set; }
    public string? Id { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsClosed { get; set; }
    public Location? Location { get; set; }
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Price { get; set; }
    public double Rating { get; set; }
    public int ReviewCount { get; set; }
    public List<string>? Transactions { get; set; }
    public string? Url { get; set; }
}
