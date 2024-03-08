using Microsoft.AspNetCore.Components;
using MudBlazor;
using NightlifeCoordinationSPA.DTOs.AuthDTOs;
using NightlifeCoordinationSPA.Services.AuthService;

namespace NightlifeCoordinationSPA.Pages.AccountPage.RegisterPage;

public partial class RegisterPage
{
    private AuthRegisterDTO Model = new AuthRegisterDTO();

    [Inject]
    public IAuthService? AuthService { get; set; }

    [Inject]
    public NavigationManager? Navigate { get; set; }

    [Inject]
    public ISnackbar? Snackbar { get; set; }

    public bool ShowErrorMessage { get; set; }
    public string? ErrorMessage { get; set; }

    public async Task OnValidSubmit()
    {
        ShowErrorMessage = false;

        var response = await AuthService!.Register(Model);

        if (!response.Success)
        {
            ShowErrorMessage = true;

            if (response.Errors == null)
                ErrorMessage = "An unexpected error occurred.";
            else if (response.Errors.ContainsKey("DuplicateUserName"))
                ErrorMessage = "Email already taken";
            else
                ErrorMessage = "Registration failed.";
        }
        else
        {
            StateHasChanged();

            string message = "Congratulations! Your registration was successful.";
            Snackbar!.Add(message, Severity.Success);

            Navigate!.NavigateTo("/account/login");
        }
    }
}
