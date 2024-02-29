using NightlifeCoordinationSPA.Data;

namespace NightlifeCoordinationSPA.Services.Authentication;

public interface IAuthService
{
    Task<ResponseDTO> Register(RegisterDTO data);
    Task<ResponseDTO> Login(LoginDTO data);
    Task Logout();
}
