using ProMedScope.Controls._Elements.TabControl.TabItem;
using ProMedScope.Controls.Icon.Enums;
using System.Windows;

namespace ProMedScope.Controls.SideMenu._Elements.Item;

/// <summary>
/// Repräsentiert einen Eintrag im Seitenmenü.
/// </summary>
public class PmSideMenuItem : PmTabControlTabItem
{
    #region Dependency Properties

    public static readonly DependencyProperty MenuNameProperty =
        DependencyProperty.Register(nameof(MenuName), typeof(PmSideMenuItemEnum), typeof(PmSideMenuItem));

    public static readonly DependencyProperty IconProperty =
        DependencyProperty.Register(nameof(Icon), typeof(IconEnum), typeof(PmSideMenuItem), new PropertyMetadata(IconEnum.None));

    public static readonly DependencyProperty ViewProperty =
        DependencyProperty.Register(nameof(View), typeof(object), typeof(PmSideMenuItem));

    #endregion

    #region Eigenschaften

    /// <summary>
    /// Definiert den Seitentyp des Menüeintrags.
    /// </summary>
    public PmSideMenuItemEnum MenuName
    {
        get => (PmSideMenuItemEnum)GetValue(MenuNameProperty);
        set => SetValue(MenuNameProperty, value);
    }

    /// <summary>
    /// Definiert das Symbol des Menüeintrags.
    /// </summary>
    public IconEnum Icon
    {
        get => (IconEnum)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    /// <summary>
    /// Definiert die anzuzeigende View des Menüeintrags.
    /// </summary>
    public object View
    {
        get => GetValue(ViewProperty);
        set => SetValue(ViewProperty, value);
    }

    #endregion
}