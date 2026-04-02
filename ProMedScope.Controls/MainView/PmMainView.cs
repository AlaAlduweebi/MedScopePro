using ProMedScope.Controls._Elements.ContentControl;
using ProMedScope.Controls.SideMenu._Elements.Item;
using ProMedScope.Controls.SideMenu;
using System.Windows.Controls;
using ProMedScope.ViewModels;
using System.Windows;

namespace ProMedScope.Controls.MainView;

/// <summary>
/// Repräsentiert die Hauptansicht der Anwendung.
/// </summary>
public class PmMainView : PmContentControl
{
    #region Felder

    /// <summary>
    /// Referenz auf das SideMenu aus dem Template.
    /// </summary>
    private PmSideMenu? _sideMenu;

    #endregion

    #region Methoden

    /// <summary>
    /// Verknüpft das SideMenu aus dem Template mit der Navigation.
    /// </summary>
    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        if (_sideMenu != null)
            _sideMenu.SelectionChanged -= OnSideMenuSelectionChanged;

        _sideMenu = GetTemplateChild("SideMenu") as PmSideMenu;

        if (_sideMenu != null)
            _sideMenu.SelectionChanged += OnSideMenuSelectionChanged;
    }

    /// <summary>
    /// Aktualisiert die Navigation bei Auswahl eines Menüeintrags.
    /// </summary>
    private void OnSideMenuSelectionChanged(object? _, SelectionChangedEventArgs e)
    {
        if (_sideMenu?.SelectedItem is PmSideMenuItem item &&
            Application.Current.MainWindow?.DataContext is MainViewModel vm)
        {
            vm.NavigateTo((SideMenuItemEnum)item.MenuName);
        }
    }

    #endregion
}