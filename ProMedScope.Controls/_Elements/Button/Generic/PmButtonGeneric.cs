using System.Windows;

namespace ProMedScope.Controls._Elements.Button.Generic;

/// <summary>
/// Generischer Button mit Enum-basierter Identifikation.
/// </summary>
/// <typeparam name="TEnum">Enum zur Bestimmung der Button.</typeparam>
public abstract class PmButtonGeneric<TEnum> : PmButton where TEnum : Enum
{
    #region Dependency Properties

    public static readonly DependencyProperty ButtonNameProperty =
        DependencyProperty.Register(nameof(ButtonName), typeof(TEnum), typeof(PmButtonGeneric<TEnum>), new PropertyMetadata(default(TEnum)));

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
    /// Initialisiert eine neue Instanz der <see cref="PmButtonGeneric{TEnum}"/>-Klasse.
    /// </summary>
    protected PmButtonGeneric()
    {
        Click += ButtonClick;
    }

    #endregion

    #region Methoden

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