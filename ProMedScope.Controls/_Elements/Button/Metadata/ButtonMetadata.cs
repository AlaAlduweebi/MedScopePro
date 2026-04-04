using ProMedScope.Controls.Workspace._Elements.Item._Elements.Button;
using ProMedScope.Controls._Elements.Button.Generic;
using ProMedScope.Controls.Icon;

namespace ProMedScope.Controls._Elements.Button.Metadata;

/// <summary>
/// Stellt zentrale Metadaten (Icon, Tooltip, Label) für Buttons bereit und wendet sie automatisch an.
/// </summary>
public static class ButtonMetadata
{
    /// <summary>
    /// Enthält Metadaten wie Icon, Tooltip und Beschriftung für einen Button.
    /// </summary>
    public record ButtonMeta(
        PmIconEnum icon = PmIconEnum.None,
        string? label = null,
        string? tooltip = null
    );

    /// <summary>
    /// Enthält alle zugewiesenen Metadaten pro Button-Enum.
    /// </summary>
    private static readonly Dictionary<Enum, ButtonMeta> Metadata = new()
    {
        // Workspace
        [PmWorkspaceItemButtonEnum.Close] = new ButtonMeta(
                icon: PmIconEnum.Cancel,
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
    public static void ApplyMetadata<TEnum>(PmButtonGeneric<TEnum> button) where TEnum : Enum
    {
        var meta = GetMeta(button.ButtonName);
        if (meta == null) return;

        button.Icon = meta.icon;
        button.Content ??= meta.label;
        button.ToolTip = meta.tooltip;
    }
}