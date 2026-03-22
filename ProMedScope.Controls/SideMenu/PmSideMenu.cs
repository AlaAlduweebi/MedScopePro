using ProMedScope.Controls._Elements.TabControl;
using ProMedScope.Controls.SideMenu.Item;
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
            MenuName = PmSideMenuEnum.Dashboard,
            Icon = Icon.PmIconEnum.Dashboard,
            View = new DashboardView(),
        });

        Items.Add(new PmSideMenuItem
        {
            MenuName = PmSideMenuEnum.Patient,
            Icon = Icon.PmIconEnum.Person,
            View = new PatientView(),
        });

        Items.Add(new PmSideMenuItem
        {
            MenuName = PmSideMenuEnum.Reports,
            Icon = Icon.PmIconEnum.Assignment,
            View = new ReportsView(),
        });

        Items.Add(new PmSideMenuItem
        {
            MenuName = PmSideMenuEnum.Settings,
            Icon = Icon.PmIconEnum.Settings,
            View = new SettingsView(),
        });
    }
}