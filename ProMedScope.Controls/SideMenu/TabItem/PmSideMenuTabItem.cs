using ProMedScope.Controls._Elements.TabControl.TabItem;
using ProMedScope.Controls.Icon;
using System.Windows;

namespace ProMedScope.Controls.SideMenu.TabItem;

/// <summary>
/// Repräsentiert einen Eintrag im Seitenmenü.
/// </summary>
public class PmSideMenuTabItem : PmTabControlTabItem
{
    #region Dependency Properties

    public static readonly DependencyProperty MenuNameProperty =
        DependencyProperty.Register(nameof(MenuName), typeof(PmSideMenuEnum), typeof(PmSideMenuTabItem));

    public static readonly DependencyProperty IconProperty =
        DependencyProperty.Register(nameof(Icon), typeof(PmIconEnum), typeof(PmSideMenuTabItem), new PropertyMetadata(PmIconEnum.None));

    #endregion

    #region Eigenschaften

    /// <summary>
    /// Definiert den Seitentyp des Menüeintrags.
    /// </summary>
    public PmSideMenuEnum MenuName
    {
        get => (PmSideMenuEnum)GetValue(MenuNameProperty);
        set => SetValue(MenuNameProperty, value);
    }

    /// <summary>
    /// Definiert das Symbol des Menüeintrags.
    /// </summary>
    public PmIconEnum Icon
    {
        get => (PmIconEnum)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    #endregion
}