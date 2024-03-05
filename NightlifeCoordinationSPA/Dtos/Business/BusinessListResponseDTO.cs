using NightlifeCoordinationSPA.Models;

namespace NightlifeCoordinationSPA.Dtos;

public class BusinessListResponseDTO
{
    public bool Success { get; set; }

    public List<Business>? Businesses { get; set; }
    public Region? Region { get; set; }
    public int? Total { get; set; }

    public ErrorDetails? Error { get; set; }
}
