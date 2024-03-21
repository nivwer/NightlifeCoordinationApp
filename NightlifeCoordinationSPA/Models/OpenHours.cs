using System.Text.Json.Serialization;

namespace NightlifeCoordinationSPA.Models;

public class OpenHours
{
    public OpenTime[]? Open { get; set; }

    [JsonPropertyName("hours_type")]
    public string? HoursType { get; set; }

    [JsonPropertyName("is_open_now")]
    public bool? IsOpenNow { get; set; }
}
