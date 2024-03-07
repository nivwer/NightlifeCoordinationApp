namespace NightlifeCoordinationSPA.DTOs.AuthDTOs;

public class AuthResponseDTO
{
    public bool Success { get; set; }

    // -- Failed response -------------------------------------------

    public string? Type { get; set; }
    public string? Title { get; set; }
    public int? Status { get; set; }
    public string? Detail { get; set; }
    public Dictionary<string, string[]>? Errors { get; set; }
}