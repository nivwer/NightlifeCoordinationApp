namespace NightlifeCoordinationSPA.DTOs.BusinessDTOs;

public class BusinessListQueryDTO
{
    public string Keyword { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public IEnumerable<int>? Price { get; set; }
    public IEnumerable<string>? Categories { get; set; } = [];
    public bool? OpenNow { get; set; }
    public IEnumerable<string>? Attributes { get; set; } = [];
}