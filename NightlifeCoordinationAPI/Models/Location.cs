using System.Text.Json.Serialization;

namespace NightlifeCoordinationAPI.Models;

public class Location
{
    public string? Address1 { get; set; }
    public string? Address2 { get; set; }
    public string? Address3 { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }

    [JsonPropertyName("display_address")]
    public List<string>? DisplayAddress { get; set; }

    public string? State { get; set; }

    [JsonPropertyName("zip_code")]
    public string? ZipCode { get; set; }

    [JsonPropertyName("cross_streets")]
    public string? CrossStreets { get; set; }
}
