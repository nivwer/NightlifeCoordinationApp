using NightlifeCoordinationAPI.Models;

namespace NightlifeCoordinationAPI.Dtos;

public class YelpAPIResponseDTO
{
    public List<Business>? Businesses { get; set; }
    public Region? Region { get; set; }
    public int? Total { get; set; }
}
