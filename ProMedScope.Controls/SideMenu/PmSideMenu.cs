using ProMedScope.Controls.SideMenu._Elements.Item;
using ProMedScope.Controls._Elements.TabControl;
using ProMedScope.Views.Dashboard;
using ProMedScope.Views.Settings;
using ProMedScope.Views.Patient;
using ProMedScope.Views.Reports;

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

        Items.Add(new PmSideMenuItem
        {
            MenuName = PmSideMenuItemEnum.Dashboard,
            Icon = Icon.PmIconEnum.Dashboard,
            ToolTip = "Dashboard",
            View = new DashboardView(),
        });

        Items.Add(new PmSideMenuItem
        {
            MenuName = PmSideMenuItemEnum.Patient,
            Icon = Icon.PmIconEnum.Person,
            ToolTip = "Patient",
            View = new PatientView(),
        });

        Items.Add(new PmSideMenuItem
        {
            MenuName = PmSideMenuItemEnum.Reports,
            Icon = Icon.PmIconEnum.Assignment,
            ToolTip = "Berichte",
            View = new ReportsView(),
        });

        Items.Add(new PmSideMenuItem
        {
            MenuName = PmSideMenuItemEnum.Settings,
            Icon = Icon.PmIconEnum.Settings,
            ToolTip = "Einstellungen",
            View = new SettingsView(),
        });
    }
}