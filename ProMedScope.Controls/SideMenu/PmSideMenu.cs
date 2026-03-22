using ProMedScope.Controls._Elements.TabControl;
using ProMedScope.Controls.SideMenu.TabItem;
namespace ProMedScope.Controls.SideMenu;

/// <summary>
/// Repräsentiert das Seitenmenü der Anwendung.
/// </summary>
public class PmSideMenu : PmTabControl
{
    /// <summary>
    /// Initialisiert die Standard-Einträge des Seitenmenüs.
    /// </summary>
    protected override void OnInitialized(EventArgs e)
    {
        base.OnInitialized(e);

        if (Items.Count > 0)
            return;

        Items.Add(new PmSideMenuTabItem
        {
            MenuName = PmSideMenuEnum.Dashboard,
            Icon = Icon.PmIconEnum.Dashboard,
            Content = "Dashboard",
        });

        Items.Add(new PmSideMenuTabItem
        {
            MenuName = PmSideMenuEnum.Person,
            Icon = Icon.PmIconEnum.Person,
            Content = "Person",
        });

        Items.Add(new PmSideMenuTabItem
        {
            MenuName = PmSideMenuEnum.Recordings,
            Icon = Icon.PmIconEnum.AnimatedImages,
            Content = "Recordings",
        });

        Items.Add(new PmSideMenuTabItem
        {
            MenuName = PmSideMenuEnum.Findings,
            Icon = Icon.PmIconEnum.Assignment,
            Content = "Befunde",
        });

        Items.Add(new PmSideMenuTabItem
        {
            MenuName = PmSideMenuEnum.Settings,
            Icon = Icon.PmIconEnum.Settings,
            Content = "Einstellungen",
        });
    }
}