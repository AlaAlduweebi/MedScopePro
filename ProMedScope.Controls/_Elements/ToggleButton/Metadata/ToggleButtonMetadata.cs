using ProMedScope.Controls.SideMenu._Elements.ToggleButton;
using ProMedScope.Controls._Elements.ToggleButton.Generic;
using ProMedScope.Controls.TitleBar._Elements;
using ProMedScope.Controls.Icon.Enums;

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
        IconEnum? icon = null,
        string? label = null,
        string? tooltip = null,
        IsCheckedMeta? isChecked = null
    );

    /// <summary>
    /// Metadaten für den aktivierten Zustand.
    /// </summary>
    public record IsCheckedMeta(
        IconEnum? icon = null,
        string? label = null,
        string? tooltip = null
    );

    /// <summary>
    /// Enthält alle zugewiesenen Metadaten pro ToggleButton-Enum.
    /// </summary>
    private static readonly Dictionary<Enum, ToggleButtonMeta> Metadata = new()
    {
        // SideMenu
        [SideMenuToggleButtonEnum.Power] = new ToggleButtonMeta(
                icon: IconEnum.Power,
                tooltip: "Ein/Aus"
            ),

        // TitleBar
        [TitleBarToggleButtonEnum.Design] = new ToggleButtonMeta(
                icon: IconEnum.DarkMode,
                tooltip: "Dunkles Design aktivieren",
                isChecked: new IsCheckedMeta(
                    icon: IconEnum.LightMode,
                    tooltip: "Helles Design aktivieren"
                )),
        [TitleBarToggleButtonEnum.Language] = new ToggleButtonMeta(
                icon: IconEnum.DarkMode,
                tooltip: "Englich",
                isChecked: new IsCheckedMeta(
                    icon: IconEnum.LightMode,
                    tooltip: "Deutsch"
                )),
        [TitleBarToggleButtonEnum.Profile] = new ToggleButtonMeta(
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
    public static void ApplyMetadata<TEnum>(ToggleButtonControlGeneric<TEnum> toggleButton) where TEnum : Enum
    {
        var meta = GetMeta(toggleButton.ButtonName);
        if (meta == null) return;

        var toggle = toggleButton.IsChecked == true ? meta.isChecked : null;

        toggleButton.Icon = toggle?.icon ?? meta.icon ?? IconEnum.None;
        toggleButton.Content = toggle?.label ?? meta.label ?? toggleButton.Content;
        toggleButton.ToolTip = toggle?.tooltip ?? meta.tooltip;
    }
}