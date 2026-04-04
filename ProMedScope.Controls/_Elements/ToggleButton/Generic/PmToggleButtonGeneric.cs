using ProMedScope.Controls._Elements.ToggleButton.Metadata;
using ProMedScope.Controls.Icon.Enums;
using System.Windows;

namespace ProMedScope.Controls._Elements.ToggleButton.Generic;

/// <summary>
/// Generischer ToggleButton mit Enum-basierter Identifikation.
/// </summary>
/// <typeparam name="TEnum">Enum zur Bestimmung der ToggleButton.</typeparam>
public abstract class PmToggleButtonGeneric<TEnum> : PmToggleButton where TEnum : Enum
{
    #region Dependency Properties

    public static readonly DependencyProperty ButtonNameProperty =
        DependencyProperty.Register(nameof(ButtonName), typeof(TEnum), typeof(PmToggleButtonGeneric<TEnum>), new PropertyMetadata(default(TEnum)));

    public static readonly DependencyProperty IconProperty =
        DependencyProperty.Register(nameof(Icon), typeof(IconEnum), typeof(PmToggleButtonGeneric<TEnum>), new PropertyMetadata(default(IconEnum)));

    #endregion

    #region Eigenschaften

    /// <summary>
    /// Der Name des ToggleButtons, der als Enum-Wert definiert ist.
    /// </summary>
    public TEnum ButtonName
    {
        get => (TEnum)GetValue(ButtonNameProperty);
        set => SetValue(ButtonNameProperty, value);
    }

    #endregion

    #region Konstruktor

    /// <summary>
    /// Initialisiert eine neue Instanz der <see cref="PmToggleButtonGeneric{TEnum}"/>-Klasse.
    /// </summary>
    protected PmToggleButtonGeneric()
    {
        Click += ButtonClick;
    }

    /// <summary>
    /// Repräsentiert das Symbol.
    /// </summary>
    public IconEnum Icon
    {
        get { return (IconEnum)GetValue(IconProperty); }
        set { SetValue(IconProperty, value); }
    }

    #endregion

    #region Methoden

    /// <summary>
    /// Führt die Initialisierung aus.
    /// </summary>
    protected override void OnInitialized(EventArgs e)
    {
        base.OnInitialized(e);

        ToggleButtonMetadata.ApplyMetadata(this);
    }

    /// <summary>
    /// Event-Handler für ToggleButton-Klick.
    /// Führt die entsprechende Aktion basierend auf dem <see cref="ButtonName"/> aus.
    /// </summary>
    protected virtual void ButtonClick(object sender, RoutedEventArgs e)
    {
        ArgumentNullException.ThrowIfNull(e);
        ArgumentNullException.ThrowIfNull(sender);
    }

    #endregion
}