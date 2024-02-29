using Microsoft.AspNetCore.Components;
using NightlifeCoordinationSPA.Data;
using NightlifeCoordinationSPA.Services.Authentication;

namespace NightlifeCoordinationSPA.Pages.Account.Login;

public partial class Login
{
    public LoginDTO _model = new LoginDTO();

    [Inject]
    public IAuthService? _authService { get; set; }

    [Inject]
    public NavigationManager? _navigate { get; set; }
    public bool ShowErrorMessage { get; set; }
    public string? ErrorMessage { get; set; }

    public async Task OnValidSubmit()
    {
        ShowErrorMessage = false;

        var response = await _authService!.Login(_model);
        if (!response.IsSuccessfulAction)
        {
            ShowErrorMessage = true;

            if (response.Errors == null)
                ErrorMessage = "An unexpected error occurred. Please contact support.";
            else
                ErrorMessage = "Authentication failed.";
        }
        else
        {
            StateHasChanged();
            _navigate!.NavigateTo("/");
        }
    }
}
