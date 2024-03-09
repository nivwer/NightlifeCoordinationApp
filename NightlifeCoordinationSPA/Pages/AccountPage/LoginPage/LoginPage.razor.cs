using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using NightlifeCoordinationSPA.DTOs.AuthDTOs;
using NightlifeCoordinationSPA.Helpers.InputPasswordManager;
using NightlifeCoordinationSPA.Services.AuthService;

namespace NightlifeCoordinationSPA.Pages.AccountPage.LoginPage;

public partial class LoginPage
{
    public AuthLoginDTO Model = new AuthLoginDTO();

    [Inject]
    public IAuthService? AuthService { get; set; }

    [Inject]
    public NavigationManager? Navigate { get; set; }

    [CascadingParameter]
    private Task<AuthenticationState>? AuthenticationStateTask { get; set; }

    public bool ShowErrorMessage { get; set; }
    public string? ErrorMessage { get; set; }

    public InputPasswordManager Password = new InputPasswordManager();

    public async Task OnValidSubmit()
    {
        ShowErrorMessage = false;

        var response = await AuthService!.Login(Model);

        if (!response.Success)
        {
            ShowErrorMessage = true;

            if (response.Status == 401)
                ErrorMessage = "Authentication failed.";
            else
                ErrorMessage = "An unexpected error occurred.";
        }
        else
        {
            StateHasChanged();
            Navigate!.NavigateTo("/");
        }
    }

    protected override async Task OnInitializedAsync()
    {
        if (AuthenticationStateTask != null)
        {
            var authState = await AuthenticationStateTask;
            if (authState.User.Identity!.IsAuthenticated)
            {
                Navigate!.NavigateTo("/");
            }
        }
    }

    public void HandleCloseError()
    {
        ShowErrorMessage = false;
    }
}
