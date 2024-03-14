using System.Text.Json.Serialization;
using NightlifeCoordinationAPI.Models;

namespace NightlifeCoordinationAPI.DTOs.YelpAPIDTOs;

public class YelpAPIBusinessResponseDTO : Business
{
    [JsonPropertyName("is_claimed")]
    public bool? IsClaimed { get; set; }
    public string[]? Photos { get; set; }
    public OpenHours[]? Hours { get; set; }
}
