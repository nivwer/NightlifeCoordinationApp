using System.Net.Http.Json;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using NightlifeCoordinationSPA.Data;

namespace NightlifeCoordinationSPA.Providers;

public class AuthStateProvider : AuthenticationStateProvider
{
    private readonly HttpClient _httpClient;
    private readonly AuthenticationState _anonymous;

    public AuthStateProvider(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        string Url = "/api/user";

        // Get user if authenticated
        UserDTO? oUser = new UserDTO();

        try
        {
            oUser = await _httpClient.GetFromJsonAsync<UserDTO>(Url);
        }
        catch
        {
            oUser = null;
        }

        if (oUser == null)
            return await Task.FromResult(_anonymous);

        var claims = new List<Claim> { new Claim(ClaimTypes.Email, oUser.Email!), };

        var user = new ClaimsIdentity(claims, "sessionAuthType");
        return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(user)));
    }

    public void NotifyUserAuthentication()
    {
        var authState = GetAuthenticationStateAsync();
        NotifyAuthenticationStateChanged(authState);
    }

    public void NotifyUserLogout()
    {
        var authState = Task.FromResult(_anonymous);
        NotifyAuthenticationStateChanged(authState);
    }
}
