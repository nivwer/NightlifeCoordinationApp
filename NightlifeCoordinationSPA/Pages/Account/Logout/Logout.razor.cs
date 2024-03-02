using Microsoft.AspNetCore.Components;
using NightlifeCoordinationSPA.Services.Authentication;

namespace NightlifeCoordinationSPA.Pages.Account.Logout;

public partial class Logout
{
    [Inject]
    public IAuthService? _authService { get; set; }

    [Inject]
    public NavigationManager? _navigate { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await _authService!.Logout();
        _navigate!.NavigateTo("/");
    }
}
