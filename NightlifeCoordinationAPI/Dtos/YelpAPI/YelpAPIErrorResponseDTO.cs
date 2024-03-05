namespace NightlifeCoordinationAPI.Dtos;

public class ErrorDetails
{
    public string? Code { get; set; }
    public string? Description { get; set; }
}

public class YelpAPIErrorResponseDTO
{
    public ErrorDetails? Error { get; set; }
}
