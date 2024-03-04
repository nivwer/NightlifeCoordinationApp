using System.ComponentModel.DataAnnotations;

namespace NightlifeCoordinationAPI.Dtos;

public class BusinessListQueryParamsDTO
{
    [MinLength(1, ErrorMessage = "Location should not be empty.")]
    [MaxLength(250, ErrorMessage = "Location should not exceed 250 characters.")]
    public string? Location { get; set; }

    [Range(-90, 90, ErrorMessage = "Latitude should be between -90 and 90.")]
    public decimal? Latitude { get; set; }

    [Range(-180, 180, ErrorMessage = "Longitude should be between -180 and 180.")]
    public decimal? Longitude { get; set; }

    public string? Term { get; set; }

    [Range(0, 40000, ErrorMessage = "Radius should be between 0 and 40000.")]
    public int? Radius { get; set; }

    public string[]? Categories { get; set; }

    [RegularExpression("^[a-z]{2,3}_[A-Z]{2}$",
        ErrorMessage = "Locale should match the pattern: ^[a-z]{2,3}_[A-Z]{2}$")]
    public string? Locale { get; set; }

    public int[]? Price { get; set; }

    public bool? OpenNow { get; set; }

    public int? OpenAt { get; set; }

    public string[]? Attributes { get; set; }

    [RegularExpression("^(best_matche|rating|review_count|distance)$",
        ErrorMessage = "Invalid value for SortBy.")]
    public string? SortBy { get; set; }

    [RegularExpression("^(android|ios|mobile-generic)$",
        ErrorMessage = "Invalid value for DevicePlatform.")]
    public string? DevicePlatform { get; set; }

    [RegularExpression(@"^\d{4}-\d{2}-\d{2}$",
        ErrorMessage = "Invalid date format. Use YYYY-mm-dd.")]
    public string? ReservationDate { get; set; }

    [RegularExpression(@"^(0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$",
        ErrorMessage = "Invalid time format. Use HH:MM.")]
    public string? ReservationTime { get; set; }

    [Range(1, 10, ErrorMessage = "ReservationCovers should be between 1 and 10.")]
    public int? ReservationCovers { get; set; }

    public bool? MatchesPartySizeParam { get; set; }

    [Range(0, 50, ErrorMessage = "Limit should be between 0 and 50.")]
    public int Limit { get; set; } = 20;

    [Range(0, 1000, ErrorMessage = "Offset should be between 0 and 1000.")]
    public int? Offset { get; set; }
}
