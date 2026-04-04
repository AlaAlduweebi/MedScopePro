using ProMedScope.Controls._Elements.Button.Generic;
using System.Windows;

namespace ProMedScope.Controls.Workspace._Elements.Item._Elements.Button;

/// <summary>
/// /// Benutzerdefinierter Button für das WorkspaceItem.
/// </summary>
public class WorkspaceItemButtonControl : ButtonControlGeneric<WorkspaceItemButtonEnum>
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
            case WorkspaceItemButtonEnum.Close:
                CloseWorkspaceItem();
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    /// <summary>
    /// Schließt das WorkspaceItem.
    /// </summary>
    public void CloseWorkspaceItem()
    {
    }

    #endregion
}