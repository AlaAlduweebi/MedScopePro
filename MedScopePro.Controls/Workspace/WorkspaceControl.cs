using MedScopePro.Controls.Workspace._Elements.Item;
using MedScopePro.Controls._Elements.TabControl;
using System.Windows;

namespace MedScopePro.Controls.Workspace;

/// <summary>
/// Repräsentiert den Workspace-Bereich mit Tabs für geöffnete Inhalte.
/// </summary>
public class WorkspaceControl : TabControl
{
    /// <summary>
    /// Erstellt einen neuen Container für ein Workspace-Element.
    /// </summary>
    protected override DependencyObject GetContainerForItemOverride()
    {
        return new WorkspaceItemControl();
    }
}