using System.Text.Json.Serialization;

namespace NightlifeCoordinationAPI.Models;

public class OpenTime
{
    [JsonPropertyName("is_overnight")]
    public bool? IsOvernight { get; set; }
    
    public string? Start { get; set; }
    public string? End { get; set; }
    public int? Day { get; set; }
}

public class OpenHours
{
    public OpenTime[]? Open { get; set; }

    [JsonPropertyName("hours_type")]
    public string? HoursType { get; set; }

    [JsonPropertyName("is_open_now")]
    public bool? IsOpenNow { get; set; }
}