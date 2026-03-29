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
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    #endregion
}