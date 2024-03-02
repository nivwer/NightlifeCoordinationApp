namespace NightlifeCoordinationAPI.Models;

public class Location
{
    public string? Address1 { get; set; }
    public string? Address2 { get; set; }
    public string? Address3 { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public List<string>? DisplayAddress { get; set; }
    public string? State { get; set; }
    public string? ZipCode { get; set; }
}
