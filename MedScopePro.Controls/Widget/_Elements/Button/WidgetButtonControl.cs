using MedScopePro.Controls._Elements.Button.Generic;
using System.Windows;

namespace MedScopePro.Controls.Widget._Elements.Button;

/// <summary>
/// Benutzerdefinierter Button für das Widget.
/// </summary>
public class WidgetButtonControl : ButtonControlGeneric<WidgetButtonEnum>
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
            case WidgetButtonEnum.Maximize:
                ExecuteMaximize();
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    /// <summary>
    /// Führt die Maximierungsaktion für das Widget aus.
    /// </summary>
    private void ExecuteMaximize()
    {

    }

    #endregion
}