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
        oUser = await _httpClient.GetFromJsonAsync<UserDTO>(Url);

        if (oUser == null)
            return _anonymous;


        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, oUser.Email!),
        };

        var user = new ClaimsIdentity(claims, "sessionAuthType");
        return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(user)));
    }

    // public async override Task<AuthenticationState> GetAuthenticationStateAsync()
    // {
    //     await Task.Delay(1500);
    //     var claims = new List<Claim>
    //     {
    //         new Claim(ClaimTypes.Name, "John Doe"),
    //         new Claim(ClaimTypes.Role, "Administrator")
    //     };
    //     var anonymous = new ClaimsIdentity(claims, "testAuthType");
    //     return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymous)));
    // }

    public void NotifyUserAuthentication(string email)
    {
        var authUser = new ClaimsPrincipal(
            new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, email) }, "sessionAuthType")
        );

        var authState = Task.FromResult(new AuthenticationState(authUser));
        NotifyAuthenticationStateChanged(authState);
    }

    public void NotifyUserLogout()
    {
        var authState = Task.FromResult(_anonymous);
        NotifyAuthenticationStateChanged(authState);
    }
}
