using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using NightlifeCoordinationSPA.DTOs.AuthDTOs;
using NightlifeCoordinationSPA.Helpers.InputPasswordManager;
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

    [CascadingParameter]
    private Task<AuthenticationState>? AuthenticationStateTask { get; set; }

    public bool ShowErrorMessage { get; set; }
    public string? ErrorMessage { get; set; }

    public InputPasswordManager Password = new InputPasswordManager();
    public InputPasswordManager Password2 = new InputPasswordManager();

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