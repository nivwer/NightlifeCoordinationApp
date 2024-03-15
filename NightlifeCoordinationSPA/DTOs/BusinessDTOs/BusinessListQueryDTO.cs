namespace NightlifeCoordinationSPA.DTOs.BusinessDTOs;

public class BusinessListQueryDTO
{
    public string? Keyword { get; set; }
    public string? Location { get; set; }
    public IEnumerable<int>? Price { get; set; }
}