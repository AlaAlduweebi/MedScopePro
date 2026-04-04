using ProMedScope.Controls._Elements.Button.Metadata;
using ProMedScope.Controls.Icon.Enums;
using System.Windows;

namespace ProMedScope.Controls._Elements.Button.Generic;

/// <summary>
/// Generischer Button mit Enum-basierter Identifikation.
/// </summary>
/// <typeparam name="TEnum">Enum zur Bestimmung der Button.</typeparam>
public abstract class ButtonControlGeneric<TEnum> : ButtonControl where TEnum : Enum
{
    #region Dependency Properties

    public static readonly DependencyProperty ButtonNameProperty =
        DependencyProperty.Register(nameof(ButtonName), typeof(TEnum), typeof(ButtonControlGeneric<TEnum>), new PropertyMetadata(default(TEnum)));

    public static readonly DependencyProperty IconProperty =
        DependencyProperty.Register(nameof(Icon), typeof(IconEnum), typeof(ButtonControlGeneric<TEnum>), new PropertyMetadata(default(IconEnum)));

    #endregion

    #region Eigenschaften

    /// <summary>
    /// Der Name des Buttons, der als Enum-Wert definiert ist.
    /// </summary>
    public TEnum ButtonName
    {
        get => (TEnum)GetValue(ButtonNameProperty);
        set => SetValue(ButtonNameProperty, value);
    }

    #endregion

    #region Konstruktor

    /// <summary>
    /// Initialisiert eine neue Instanz der <see cref="ButtonControlGeneric{TEnum}"/>-Klasse.
    /// </summary>
    protected ButtonControlGeneric()
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

        ButtonMetadata.ApplyMetadata(this);
    }

    /// <summary>
    /// Event-Handler für Button-Klick.
    /// Führt die entsprechende Aktion basierend auf dem <see cref="ButtonName"/> aus.
    /// </summary>
    protected virtual void ButtonClick(object sender, RoutedEventArgs e)
    {
        ArgumentNullException.ThrowIfNull(e);
        ArgumentNullException.ThrowIfNull(sender);
    }

    #endregion
}