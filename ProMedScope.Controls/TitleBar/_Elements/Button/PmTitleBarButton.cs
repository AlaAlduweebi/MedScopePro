using ProMedScope.Controls._Elements.Button.Generic;
using System.Windows;

namespace ProMedScope.Controls.TitleBar._Elements.Button;

/// <summary>
/// /// Benutzerdefinierter Button für die TitleBar.
/// </summary>
public class PmTitleBarButton : PmButtonGeneric<PmTitleBarButtonEnum>
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
            case PmTitleBarButtonEnum.Profile:
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    #endregion
}