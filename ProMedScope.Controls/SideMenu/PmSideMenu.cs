using ProMedScope.Controls._Elements.TabControl;
using ProMedScope.Controls.SideMenu.TabItem;
using ProMedScope.Views.Recordings;
using ProMedScope.Views.Dashboard;
using ProMedScope.Views.Findings;
using ProMedScope.Views.Settings;
using ProMedScope.Views.Person;

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
            View = new DashboardView(),
        });

        Items.Add(new PmSideMenuTabItem
        {
            MenuName = PmSideMenuEnum.Person,
            Icon = Icon.PmIconEnum.Person,
            View = new PersonView(),
        });

        Items.Add(new PmSideMenuTabItem
        {
            MenuName = PmSideMenuEnum.Recordings,
            Icon = Icon.PmIconEnum.AnimatedImages,
            View = new RecordingsView(),
        });

        Items.Add(new PmSideMenuTabItem
        {
            MenuName = PmSideMenuEnum.Findings,
            Icon = Icon.PmIconEnum.Assignment,
            View = new FindingsView(),
        });

        Items.Add(new PmSideMenuTabItem
        {
            MenuName = PmSideMenuEnum.Settings,
            Icon = Icon.PmIconEnum.Settings,
            View = new SettingsView(),
        });
    }
}