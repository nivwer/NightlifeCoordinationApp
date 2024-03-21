using System.Text.Json.Serialization;

namespace NightlifeCoordinationSPA.Models;

public class OpenTime
{
    [JsonPropertyName("is_overnight")]
    public bool? IsOvernight { get; set; }
    
    public string? Start { get; set; }
    public string? End { get; set; }
    public int? Day { get; set; }
}