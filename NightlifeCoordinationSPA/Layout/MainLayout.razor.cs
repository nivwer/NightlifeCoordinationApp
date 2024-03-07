namespace NightlifeCoordinationSPA.Layout;

public partial class MainLayout
{
    public bool DrawerOpen { get; set; } = true;

    public void DrawerToggle()
    {
        DrawerOpen = !DrawerOpen;
    }
}