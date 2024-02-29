using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Authorization;
using NightlifeCoordinationSPA.Data;

namespace NightlifeCoordinationSPA.Services.Authentication;

public class AuthService : IAuthService
{
    private readonly HttpClient _http;
    private readonly AuthenticationStateProvider _authStateProvider;

    public AuthService(HttpClient http, AuthenticationStateProvider authStateProvider)
    {
        _http = http;
        _authStateProvider = authStateProvider;
    }

    public async Task<ResponseDTO> Register(RegisterDTO data)
    {
        string Url = "/register";

        var response = await _http.PostAsJsonAsync<RegisterDTO>(Url, data);

        if (!response.IsSuccessStatusCode)
        {
            var oError = await response.Content.ReadFromJsonAsync<ResponseDTO>();
            return oError ?? new ResponseDTO();
        }

        return new ResponseDTO() { IsSuccessfulAction = true };
    }

    public async Task<ResponseDTO> Login(LoginDTO data)
    {
        string Url = "/login?useCookies=true";

        var response = await _http.PostAsJsonAsync<LoginDTO>(Url, data);

        if (!response.IsSuccessStatusCode)
        {
            var oError = await response.Content.ReadFromJsonAsync<ResponseDTO>();
            return oError ?? new ResponseDTO();
        }

        return new ResponseDTO() { IsSuccessfulAction = true };
    }

    public Task Logout()
    {
        throw new NotImplementedException();
    }
}
