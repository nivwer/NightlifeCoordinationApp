using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Authorization;
using NightlifeCoordinationSPA.DTOs.AuthDTOs;
using NightlifeCoordinationSPA.Providers.AuthStateProvider;

namespace NightlifeCoordinationSPA.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly HttpClient Http;
    private readonly AuthenticationStateProvider AuthStateProvider;

    public AuthService(HttpClient http, AuthenticationStateProvider authStateProvider)
    {
        Http = http;
        AuthStateProvider = authStateProvider;
    }

    public async Task<AuthResponseDTO> Register(AuthRegisterDTO data)
    {
        string uri = "/register";

        var response = await Http.PostAsJsonAsync<AuthRegisterDTO>(uri, data);

        if (!response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<AuthResponseDTO>()
                ?? new AuthResponseDTO();
        }

        return new AuthResponseDTO() { Success = true };
    }

    public async Task<AuthResponseDTO> Login(AuthLoginDTO data)
    {
        string uri = "/login?useCookies=true";

        var response = await Http.PostAsJsonAsync<AuthLoginDTO>(uri, data);

        if (!response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<AuthResponseDTO>()
                ?? new AuthResponseDTO();
        }

        ((AuthStateProvider)AuthStateProvider).NotifyUserAuthentication();

        return new AuthResponseDTO() { Success = true };
    }

    public async Task Logout()
    {
        string uri = "/logout";

        var response = await Http.PostAsJsonAsync(uri, new { });

        if (response.IsSuccessStatusCode)
        {
            ((AuthStateProvider)AuthStateProvider).NotifyUserLogout();
        }
    }
}
