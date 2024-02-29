namespace NightlifeCoordinationSPA.Data;

public class ResponseDTO
{
    public bool IsSuccessfulAction { get; set; }
    public string? Type { get; set; }
    public string? Title { get; set; }
    public int? Status { get; set; }
    public Dictionary<string, string[]>? Errors { get; set; }
}
