using ProMedScope.Controls.SideMenu._Elements.Item;
using ProMedScope.Controls._Elements.TabControl;
using ProMedScope.ViewModels.Dashboard;
using ProMedScope.ViewModels.Settings;
using ProMedScope.ViewModels.Patient;
using ProMedScope.ViewModels.Reports;
using ProMedScope.Controls.Icon.Enums;

namespace ProMedScope.Controls.SideMenu;

/// <summary>
/// Repräsentiert das Seitenmenü der Anwendung.
/// </summary>
public class SideMenuControl : TabControl
{
    /// <summary>
    /// Initialisiert die Standard-Einträge des Seitenmenüs.
    /// </summary>
    protected override void OnInitialized(EventArgs e)
    {
        base.OnInitialized(e);

        if (Items.Count > 0)
            return;

        Items.Add(new SideMenuItemControl
        {
            MenuName = SideMenuItemEnum.Dashboard,
            Icon = IconEnum.Dashboard,
            ToolTip = "Dashboard",
            Content = new DashboardViewModel(),
        });

        Items.Add(new SideMenuItemControl
        {
            MenuName = SideMenuItemEnum.Patient,
            Icon = IconEnum.Person,
            ToolTip = "Patient",
            Content = new PatientViewModel(),
        });

        Items.Add(new SideMenuItemControl
        {
            MenuName = SideMenuItemEnum.Reports,
            Icon = IconEnum.Assignment,
            ToolTip = "Berichte",
            Content = new ReportsViewModel(),
        });

        Items.Add(new SideMenuItemControl
        {
            MenuName = SideMenuItemEnum.Settings,
            Icon = IconEnum.Settings,
            ToolTip = "Einstellungen",
            Content = new SettingsViewModel(),
        });
    }
}