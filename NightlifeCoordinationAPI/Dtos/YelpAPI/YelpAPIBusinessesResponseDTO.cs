using NightlifeCoordinationAPI.Models;

namespace NightlifeCoordinationAPI.Dtos;

public class YelpAPIBusinessesResponseDTO
{
    public List<Business>? Businesses { get; set; }
    public Region? Region { get; set; }
    public int? Total { get; set; }
}
