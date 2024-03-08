using Microsoft.AspNetCore.Components;
using NightlifeCoordinationSPA.Services.AuthService;

namespace NightlifeCoordinationSPA.Pages.AccountPage.LogoutPage;

public partial class LogoutPage
{
    [Inject]
    public IAuthService? AuthService { get; set; }

    [Inject]
    public NavigationManager? Navigate { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await AuthService!.Logout();
        Navigate!.NavigateTo("/account/login");
    }
}
