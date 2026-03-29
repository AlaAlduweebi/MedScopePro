using ProMedScope.Controls._Elements.ToggleButton.Generic;
using System.Windows;

namespace ProMedScope.Controls.SideMenu._Elements.Button;

/// <summary>
/// /// Benutzerdefinierter ToggleButton für das SideMenu.
/// </summary>
public class PmSideMenuButton : PmToggleButtonGeneric<PmSideMenuButtonEnum>
{
    #region Methoden

    /// <summary>
    /// Event-Handler für Button-Klick.
    /// Führt die entsprechende Aktion basierend auf dem <see cref="ButtonName"/> aus.
    /// </summary>
    protected override void ButtonClick(object sender, RoutedEventArgs e)
    {
        switch (ButtonName)
        {
            case PmSideMenuButtonEnum.Power:
                CloseWindow();
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    /// <summary>
    /// Schließt das Fenster.
    /// </summary>
    public void CloseWindow()
    {
        var window = Window.GetWindow(this);
        if (window == null) return;
        
        window.Close();
    }

    #endregion
}