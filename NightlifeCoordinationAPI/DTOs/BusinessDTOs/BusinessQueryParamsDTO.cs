using System.ComponentModel.DataAnnotations;

namespace NightlifeCoordinationAPI.DTOs.BusinessDTOs;

public class BusinessQueryParamsDTO
{
    [RegularExpression("^[a-z]{2,3}_[A-Z]{2}$",
        ErrorMessage = "Locale should match the pattern: ^[a-z]{2,3}_[A-Z]{2}$")]
    public string? Locale { get; set; }

    [RegularExpression("^(android|ios|mobile-generic)$",
        ErrorMessage = "Invalid value for DevicePlatform.")]
    public string? DevicePlatform { get; set; }
}