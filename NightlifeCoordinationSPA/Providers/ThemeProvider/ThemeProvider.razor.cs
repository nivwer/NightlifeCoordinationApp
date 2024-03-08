using MudBlazor;
using NightlifeCoordinationSPA.Themes.DefaultTheme;

namespace NightlifeCoordinationSPA.Providers.ThemeProvider;

public partial class ThemeProvider
{
    private bool IsDarkMode;
    private MudThemeProvider? MudThemeProvider;
    private MudTheme Theme = new DefaultTheme().Theme;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender && MudThemeProvider != null)
        {
            IsDarkMode = await MudThemeProvider.GetSystemPreference();
            StateHasChanged();
        };
    }
}