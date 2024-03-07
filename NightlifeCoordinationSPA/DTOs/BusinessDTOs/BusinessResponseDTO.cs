using System.Text.Json.Serialization;
using NightlifeCoordinationSPA.Models;

namespace NightlifeCoordinationSPA.DTOs.BusinessDTOs;

public class BusinessResponseDTO : Business
{
    public bool Success { get; set; }

    // -- Successful response ---------------------------------------

    [JsonPropertyName("is_claimed")]
    public bool? IsClaimed { get; set; }

    public string[]? Photos { get; set; }
    public OpenHours[]? Hours { get; set; }


    // -- Failed response -------------------------------------------

    public ErrorDetails? Error { get; set; }
}