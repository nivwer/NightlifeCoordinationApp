using MudBlazor;
using NightlifeCoordinationSPA.Theme.ColorsTheme;

namespace NightlifeCoordinationSPA.Themes.DefaultTheme;

public class DefaultTheme
{
    public readonly MudTheme Theme = new MudTheme()
    {
        Palette = new PaletteLight()
        {

        },

        PaletteDark = new PaletteDark()
        {
            Background = ColorsTheme.Slate.Default,
            AppbarBackground = ColorsTheme.Slate.Dark,
            DrawerBackground = ColorsTheme.Slate.Dark,
            Surface = ColorsTheme.Slate.Dark            
        },

        LayoutProperties = new LayoutProperties()
        {
            // DrawerWidthLeft = "260px",
            // DrawerWidthRight = "300px"
        }
    };
}