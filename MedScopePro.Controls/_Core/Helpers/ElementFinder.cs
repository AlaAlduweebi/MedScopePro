using System.Windows.Media;
using System.Windows;

namespace MedScopePro.Controls._Core.Helpers;

/// <summary>
/// Eine Hilfsklasse zum Suchen von UI-Elementen in der visuellen Struktur basierend auf einem Enum-Wert.
/// </summary>
public static class ElementFinder
{
    #region Methoden

    /// <summary>
    /// Findet den ersten visuellen Parent des angegebenen Typs.
    /// </summary>
    public static T? FindAncestor<T>(DependencyObject child) where T : DependencyObject
    {
        DependencyObject parent = VisualTreeHelper.GetParent(child);

        while (parent != null)
        {
            if (parent is T typedParent)
                return typedParent;

            parent = VisualTreeHelper.GetParent(parent);
        }

        return null;
    }

    /// <summary>
    /// Findet alle visuellen Kind-Elemente des angegebenen Typs.
    /// </summary>
    public static IEnumerable<T> FindVisualChildren<T>(DependencyObject parent) where T : DependencyObject
    {
        if (parent == null)
            yield break;

        int count = VisualTreeHelper.GetChildrenCount(parent);

        for (int i = 0; i < count; i++)
        {
            DependencyObject child = VisualTreeHelper.GetChild(parent, i);

            if (child is T typedChild)
                yield return typedChild;

            foreach (T descendant in FindVisualChildren<T>(child))
                yield return descendant;
        }
    }

    #endregion
}