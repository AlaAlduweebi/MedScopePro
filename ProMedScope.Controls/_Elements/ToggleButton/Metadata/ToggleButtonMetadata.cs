using ProMedScope.Controls._Elements.ToggleButton.Generic;
using ProMedScope.Controls.TitleBar._Elements;
using ProMedScope.Controls.Icon;

namespace ProMedScope.Controls._Elements.ToggleButton.Metadata;

/// <summary>
/// Stellt zentrale Metadaten (Icon, Tooltip, Label) für ToggleButtons bereit und wendet sie automatisch an.
/// </summary>
public static class ToggleButtonMetadata
{
    /// <summary>
    /// Enthält Metadaten wie Icon, Tooltip und Beschriftung für einen ToggleButton.
    /// </summary>
    public record ToggleButtonMeta(
        PmIconEnum Icon = PmIconEnum.None,
        string? Label = null,
        string? Tooltip = null
    );

    /// <summary>
    /// Enthält alle zugewiesenen Metadaten pro ToggleButton-Enum.
    /// </summary>
    private static readonly Dictionary<Enum, ToggleButtonMeta> Metadata = new()
    {
        // TitleBar
        [PmTitleBarToggleButtonEnum.Design] = new ToggleButtonMeta(
            Icon: PmIconEnum.Routine,
            Tooltip: "Design"),
        [PmTitleBarToggleButtonEnum.Language] = new ToggleButtonMeta(
            Tooltip: "Sprache"),
        [PmTitleBarToggleButtonEnum.Profile] = new ToggleButtonMeta(
            Label: "Dr. Ala Alduweebi",
            Tooltip: "Profil"),
    };

    /// <summary>
    /// Gibt die Metadaten für den angegebenen ToggleButton-Namen zurück (falls vorhanden).
    /// </summary>
    public static ToggleButtonMeta? GetMeta(Enum ToggleButtonName)
        => Metadata.GetValueOrDefault(ToggleButtonName);

    /// <summary>
    /// Wendet Tooltip und Icon automatisch auf generische ToggleButton-Instanzen an.
    /// </summary>
    public static void ApplyMetadata<TEnum>(PmToggleButtonGeneric<TEnum> ToggleButton) where TEnum : Enum
    {
        var meta = GetMeta(ToggleButton.ButtonName);
        if (meta == null) return;

        ToggleButton.Icon = meta.Icon;
        ToggleButton.Content ??= meta.Label;
        ToggleButton.ToolTip = meta.Tooltip;
    }
}