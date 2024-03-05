using System.Text.Json.Serialization;
using NightlifeCoordinationSPA.Models;

namespace NightlifeCoordinationSPA.Dtos;

public class BusinessResponseDTO : Business
{
    public bool Success { get; set; }

    [JsonPropertyName("is_claimed")]
    public bool? IsClaimed { get; set; }
    public string[]? Photos { get; set; }
    public OpenHours[]? Hours { get; set; }

    public ErrorDetails? Error { get; set; }
}