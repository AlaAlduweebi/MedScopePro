using MedScopePro.Controls._Elements.ContentControl;
using System.Windows;

namespace MedScopePro.Controls.Widget;

/// <summary>
/// Stellt ein flexibles UI‑Widget dar, das beliebigen Inhalt aufnehmen kann.
/// </summary>
public class WidgetControl : ContentControl
{
    #region Dependency Properties

    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(nameof(Title), typeof(string), typeof(WidgetControl));

    public static readonly DependencyProperty IsExpandedProperty =
        DependencyProperty.Register(nameof(IsExpanded), typeof(bool), typeof(WidgetControl), new(true));

    public static readonly DependencyProperty IsCollapsibleProperty =
        DependencyProperty.Register(nameof(IsCollapsible), typeof(bool), typeof(WidgetControl), new(true));

    #endregion

    #region Eigenschaften

    /// <summary>
    /// Der Titel, der im Kopfbereich des Widgets angezeigt wird.
    /// </summary>
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    /// <summary>
    /// Gibt an, ob das Widget aktuell ausgeklappt dargestellt wird.
    /// </summary>
    public bool IsExpanded
    {
        get => (bool)GetValue(IsExpandedProperty);
        set => SetValue(IsExpandedProperty, value);
    }

    /// <summary>
    /// Gibt an, ob das Widget ein- und ausgeklappt werden kann.
    /// </summary>
    public bool IsCollapsible
    {
        get => (bool)GetValue(IsCollapsibleProperty);
        set => SetValue(IsCollapsibleProperty, value);
    }

    #endregion
}