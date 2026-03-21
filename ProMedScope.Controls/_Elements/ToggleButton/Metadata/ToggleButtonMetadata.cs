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
        PmIconEnum? icon = null,
        string? label = null,
        string? tooltip = null,
        IsCheckedMeta? isChecked = null
    );

    /// <summary>
    /// Metadaten für den aktivierten Zustand.
    /// </summary>
    public record IsCheckedMeta(
        PmIconEnum? icon = null,
        string? label = null,
        string? tooltip = null
    );

    /// <summary>
    /// Enthält alle zugewiesenen Metadaten pro ToggleButton-Enum.
    /// </summary>
    private static readonly Dictionary<Enum, ToggleButtonMeta> Metadata = new()
    {
        // TitleBar
        [PmTitleBarToggleButtonEnum.Design] = new ToggleButtonMeta(
                icon: PmIconEnum.DarkMode,
                tooltip: "Dunkles Design aktivieren",
                isChecked: new IsCheckedMeta(
                    icon: PmIconEnum.LightMode,
                    tooltip: "Helles Design aktivieren"
                )),
        [PmTitleBarToggleButtonEnum.Language] = new ToggleButtonMeta(
                icon: PmIconEnum.DarkMode,
                tooltip: "Englich",
                isChecked: new IsCheckedMeta(
                    icon: PmIconEnum.LightMode,
                    tooltip: "Deutsch"
                )),
        [PmTitleBarToggleButtonEnum.Profile] = new ToggleButtonMeta(
            label: "Dr. Ala Alduweebi",
            tooltip: "Profil"),
    };

    /// <summary>
    /// Gibt die Metadaten für den angegebenen ToggleButton-Namen zurück (falls vorhanden).
    /// </summary>
    public static ToggleButtonMeta? GetMeta(Enum toggleButton)
        => Metadata.GetValueOrDefault(toggleButton);

    /// <summary>
    /// Wendet Tooltip und Icon automatisch auf generische ToggleButton-Instanzen an.
    /// </summary>
    public static void ApplyMetadata<TEnum>(PmToggleButtonGeneric<TEnum> toggleButton) where TEnum : Enum
    {
        var meta = GetMeta(toggleButton.ButtonName);
        if (meta == null) return;

        var toggle = toggleButton.IsChecked == true ? meta.isChecked : null;

        toggleButton.Icon = toggle?.icon ?? meta.icon ?? PmIconEnum.None;
        toggleButton.Content = toggle?.label ?? meta.label ?? toggleButton.Content;
        toggleButton.ToolTip = toggle?.tooltip ?? meta.tooltip;
    }
}