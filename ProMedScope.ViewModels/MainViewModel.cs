using CommunityToolkit.Mvvm.ComponentModel;
using ProMedScope.ViewModels.Dashboard;
using ProMedScope.ViewModels.Settings;
using ProMedScope.ViewModels.Patient;
using ProMedScope.ViewModels.Reports;

namespace ProMedScope.ViewModels;

/// <summary>
/// Zentrales ViewModel zur Steuerung der Navigation zwischen den Ansichten.
/// </summary>
public class MainViewModel : ObservableObject
{
    #region Felder

    private object? _currentView;

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