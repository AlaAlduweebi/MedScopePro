using MedScopePro.Controls.SideMenu._Elements.Item;
using MedScopePro.Controls._Elements.TabControl;
using MedScopePro.Controls.Icon.Enums;
using System.Windows;

namespace MedScopePro.Controls.SideMenu;

/// <summary>
/// Repräsentiert das Seitenmenü der Anwendung.
/// </summary>
public class SideMenuControl : TabControl
{
    #region Dependency Properties

    public static readonly DependencyProperty SelectedItemProperty =
        DependencyProperty.Register(nameof(SelectedItem), typeof(SideMenuItemControl), typeof(SideMenuControl), new PropertyMetadata(null, OnSelectedItemChanged));

    #endregion

    #region Eigenschaften

    /// <summary>
    /// Ausgewähltes Element des Seitenmenüs.
    /// </summary>
    public new SideMenuItemControl SelectedItem
    {
        get => (SideMenuItemControl)GetValue(SelectedItemProperty);
        set => SetValue(SelectedItemProperty, value);
    }

    #endregion

    #region Methoden

    /// <summary>
    /// Initialisiert die Standard-Einträge des Seitenmenüs.
    /// </summary>
    protected override void OnInitialized(EventArgs e)
    {
        base.OnInitialized(e);

        if (Items.Count > 0)
            return;

        Items.Add(new SideMenuItemControl
        {
            MenuName = SideMenuItemEnum.Dashboard,
            Icon = IconEnum.Dashboard,
            ToolTip = "Dashboard",
        });

        Items.Add(new SideMenuItemControl
        {
            MenuName = SideMenuItemEnum.Patient,
            Icon = IconEnum.Person,
            ToolTip = "Patient",
        });

        Items.Add(new SideMenuItemControl
        {
            MenuName = SideMenuItemEnum.Reports,
            Icon = IconEnum.Assignment,
            ToolTip = "Berichte",
        });

        Items.Add(new SideMenuItemControl
        {
            MenuName = SideMenuItemEnum.Settings,
            Icon = IconEnum.Settings,
            ToolTip = "Einstellungen",
        });

        SelectionChanged += (s, e) => SelectedItem = base.SelectedItem as SideMenuItemControl;
    }

    /// <summary>
    /// Wird aufgerufen, wenn sich das ausgewählte Element ändert.
    /// </summary>
    private static void OnSelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is SideMenuControl control)
        {
            control.SelectedItem = (SideMenuItemControl)e.NewValue;
        }
    }

    #endregion
}