using ProMedScope.Controls.Workspace._Elements.Item;
using ProMedScope.Controls._Elements.TabControl;
using System.Windows;

namespace ProMedScope.Controls.Workspace;

/// <summary>
/// Repräsentiert den Workspace-Bereich mit Tabs für geöffnete Inhalte.
/// </summary>
public class PmWorkspace : PmTabControl
{
    /// <summary>
    /// Erstellt einen neuen Container für ein Workspace-Element.
    /// </summary>
    protected override DependencyObject GetContainerForItemOverride()
    {
        return new PmWorkspaceItem();
    }
}