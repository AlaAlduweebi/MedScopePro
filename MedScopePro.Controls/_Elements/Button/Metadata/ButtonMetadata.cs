using MedScopePro.Controls.Workspace._Elements.Item._Elements.Button;
using MedScopePro.Controls._Elements.Button.Generic;
using MedScopePro.Controls.Widget._Elements.Button;
using MedScopePro.Controls.Icon.Enums;

namespace MedScopePro.Controls._Elements.Button.Metadata;

/// <summary>
/// Stellt zentrale Metadaten (Icon, Tooltip, Label) für Buttons bereit und wendet sie automatisch an.
/// </summary>
public static class ButtonMetadata
{
    /// <summary>
    /// Enthält Metadaten wie Icon, Tooltip und Beschriftung für einen Button.
    /// </summary>
    public record ButtonMeta(
        IconEnum icon = IconEnum.None,
        string? label = null,
        string? tooltip = null
    );

    /// <summary>
    /// Enthält alle zugewiesenen Metadaten pro Button-Enum.
    /// </summary>
    private static readonly Dictionary<Enum, ButtonMeta> Metadata = new()
    {
        // Widget
        [WidgetButtonEnum.Maximize] = new ButtonMeta(
                icon: IconEnum.Fullscreen,
                tooltip: "Groß anzeigen"
            ),

        // Workspace
        [WorkspaceItemButtonEnum.Close] = new ButtonMeta(
                icon: IconEnum.Cancel,
                tooltip: "Schließen"
            ),
    };

    /// <summary>
    /// Gibt die Metadaten für den angegebenen Button-Namen zurück (falls vorhanden).
    /// </summary>
    public static ButtonMeta? GetMeta(Enum buttonName)
        => Metadata.GetValueOrDefault(buttonName);

    /// <summary>
    /// Wendet Tooltip und Icon automatisch auf generische Button-Instanzen an.
    /// </summary>
    public static void ApplyMetadata<TEnum>(ButtonControlGeneric<TEnum> button) where TEnum : Enum
    {
        var meta = GetMeta(button.ButtonName);
        if (meta == null) return;

        button.Icon = meta.icon;
        button.Content ??= meta.label;
        button.ToolTip = meta.tooltip;
    }
}