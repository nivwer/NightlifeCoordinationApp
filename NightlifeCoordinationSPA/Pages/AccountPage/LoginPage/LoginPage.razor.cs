using Microsoft.AspNetCore.Components;
using NightlifeCoordinationSPA.DTOs.AuthDTOs;
using NightlifeCoordinationSPA.Services.AuthService;

namespace NightlifeCoordinationSPA.Pages.AccountPage.LoginPage;

public partial class LoginPage
{
    public AuthLoginDTO Model = new AuthLoginDTO();

    [Inject]
    public IAuthService? AuthService { get; set; }

    [Inject]
    public NavigationManager? Navigate { get; set; }
    public bool ShowErrorMessage { get; set; }
    public string? ErrorMessage { get; set; }

    public async Task OnValidSubmit()
    {
        ShowErrorMessage = false;

        var response = await AuthService!.Login(Model);
        if (!response.Success)
        {
            ShowErrorMessage = true;

            if (response.Errors == null)
                ErrorMessage = "An unexpected error occurred.";
            else
                ErrorMessage = "Authentication failed.";
        }
        else
        {
            StateHasChanged();
            Navigate!.NavigateTo("/");
        }
    }
}
