using Microsoft.AspNetCore.Components;
using NightlifeCoordinationSPA.Data;
using NightlifeCoordinationSPA.Services.Authentication;

namespace NightlifeCoordinationSPA.Pages.Account.Register;

public partial class Register
{
    private RegisterDTO _model = new RegisterDTO();

    [Inject]
    public IAuthService? _authService { get; set; }

    [Inject]
    public NavigationManager? _navigate { get; set; }
    public bool ShowErrorMessage { get; set; }
    public string? ErrorMessage { get; set; }

    public async Task OnValidSubmit()
    {
        ShowErrorMessage = false;

        var response = await _authService!.Register(_model);
        if (!response.IsSuccessfulAction)
        {
            ShowErrorMessage = true;

            if (response.Errors == null)
                ErrorMessage = "An unexpected error occurred. Please contact support.";
            else if (response.Errors.ContainsKey("DuplicateUserName"))
                ErrorMessage = "Email already taken";
            else
                ErrorMessage = "Registration failed.";
        }
        else
        {
            StateHasChanged();
            _navigate!.NavigateTo("/login");
        }
    }
}
