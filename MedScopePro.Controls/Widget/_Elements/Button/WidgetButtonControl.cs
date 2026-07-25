using MedScopePro.Controls._Elements.Button.Generic;
using MedScopePro.Controls._Core.Helpers;
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

            case WidgetButtonEnum.Restore:
                ExecuteRestore();
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
        var widget = ElementFinder.FindAncestor<WidgetControl>(this);
        widget?.RaiseMaximize();
    }

    /// <summary>
    /// Führt die Wiederherstellungsaktion für das Widget aus.
    /// </summary>
    private void ExecuteRestore()
    {
    }

    #endregion
}