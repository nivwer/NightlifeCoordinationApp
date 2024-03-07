using NightlifeCoordinationSPA.DTOs.AuthDTOs;

namespace NightlifeCoordinationSPA.Services.AuthService;

public interface IAuthService
{
    Task<AuthResponseDTO> Register(AuthRegisterDTO data);
    Task<AuthResponseDTO> Login(AuthLoginDTO data);
    Task Logout();
}
