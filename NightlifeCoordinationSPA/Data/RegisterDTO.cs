using System.ComponentModel.DataAnnotations;

namespace NightlifeCoordinationSPA.Data;

public class RegisterDTO
{
    [Required(ErrorMessage = "Email is required!")]
    [EmailAddress(ErrorMessage = "The email address is invalid")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Password is required!")]
    [MinLength(8, ErrorMessage = "Password must be at least of length 8")]
    [MaxLength(30, ErrorMessage = "Password must be at most of length 30")]
    [RegularExpression(
        @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$",
        ErrorMessage = "Password must contain at least one lowercase letter, one capital letter, and one digit"
    )]
    public string? Password { get; set; }

    [Required(ErrorMessage = "Confirm your password!")]
    [Compare(nameof(Password), ErrorMessage = "Passwords don't match")]
    public string? Password2 { get; set; }
}
