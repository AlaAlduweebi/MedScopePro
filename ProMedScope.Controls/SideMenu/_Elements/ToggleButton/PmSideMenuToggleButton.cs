using ProMedScope.Controls._Elements.ToggleButton.Generic;
using System.Windows;

namespace ProMedScope.Controls.SideMenu._Elements.ToggleButton;

/// <summary>
/// /// Benutzerdefinierter ToggleButton für das SideMenu.
/// </summary>
public class PmSideMenuToggleButton : PmToggleButtonGeneric<PmSideMenuToggleButtonEnum>
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
            case PmSideMenuToggleButtonEnum.Power:
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    #endregion
}