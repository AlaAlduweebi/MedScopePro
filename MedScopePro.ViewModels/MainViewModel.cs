using MedScopePro.Controls.SideMenu._Elements.Item;
using CommunityToolkit.Mvvm.ComponentModel;
using MedScopePro.ViewModels.Dashboard;
using MedScopePro.ViewModels.Settings;
using MedScopePro.ViewModels.Patient;
using MedScopePro.ViewModels.Reports;

namespace MedScopePro.ViewModels;

/// <summary>
/// Zentrales ViewModel zur Steuerung der Navigation zwischen den Ansichten.
/// </summary>
public class MainViewModel : ObservableObject
{
    #region Felder

    private object? _currentView;
    private SideMenuItemControl? _selectedMenuItem;

    #endregion

    #region Eigenschaften

    /// <summary>
    /// Aktuell angezeigte View.
    /// </summary>
    public object? CurrentView
    {
        get => _currentView;
        set => SetProperty(ref _currentView, value);
    }

    /// <summary>
    /// Ausgewählter Menüeintrag.
    /// </summary>
    public SideMenuItemControl? SelectedMenuItem
    {
        get => _selectedMenuItem;
        set
        {
            if (SetProperty(ref _selectedMenuItem, value) && value != null)
            {
                NavigateTo(value.MenuName);
            }
        }
    }

    #endregion

    #region Konstruktor

    /// <summary>
    /// Initialisiert die Standardansicht.
    /// </summary>
    public MainViewModel()
    {
        CurrentView = new PatientViewModel();
    }

    #endregion

    #region Methoden

    /// <summary>
    /// Wechselt die aktuelle Ansicht basierend auf dem Menüeintrag.
    /// </summary>
    public void NavigateTo(SideMenuItemEnum menuItem)
    {
        CurrentView = menuItem switch
        {
            SideMenuItemEnum.Dashboard => new DashboardViewModel(),
            SideMenuItemEnum.Patient => new PatientViewModel(),
            SideMenuItemEnum.Reports => new ReportsViewModel(),
            SideMenuItemEnum.Settings => new SettingsViewModel(),
            _ => null
        };
    }

    #endregion
}