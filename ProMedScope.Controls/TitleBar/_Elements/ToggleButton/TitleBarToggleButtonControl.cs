using ProMedScope.Controls._Elements.ToggleButton.Generic;
using System.Windows;

namespace ProMedScope.Controls.TitleBar._Elements.ToggleButton;

/// <summary>
/// /// Benutzerdefinierter ToggleButton für die TitleBar.
/// </summary>
public class TitleBarToggleButtonControl : ToggleButtonControlGeneric<TitleBarToggleButtonEnum>
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
            case TitleBarToggleButtonEnum.Design:
                break;

            case TitleBarToggleButtonEnum.Language:
                break;

            case TitleBarToggleButtonEnum.Profile:
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    #endregion
}