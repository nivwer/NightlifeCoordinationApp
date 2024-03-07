using System.ComponentModel.DataAnnotations;

namespace NightlifeCoordinationSPA.DTOs.AuthDTOs;

public class AuthLoginDTO
{
    [Required(ErrorMessage = "Email is required!")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Password is required!")]
    public string? Password { get; set; }
}
