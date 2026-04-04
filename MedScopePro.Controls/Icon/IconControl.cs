using MedScopePro.Controls._Elements.ContentControl;
using MedScopePro.Controls.Icon.Enums;
using System.Windows.Media;
using System.Windows;

namespace MedScopePro.Controls.Icon;

/// <summary>
/// Benutzerdefiniertes Icon.
/// </summary>	
public class IconControl : ContentControl
{
    #region Dependency Properties

    public static readonly DependencyProperty IconMaterialProperty =
        DependencyProperty.Register(nameof(IconMaterial), typeof(IconEnum), typeof(IconControl), new PropertyMetadata(default(IconEnum), OnIconVisualChanged));

    public static readonly DependencyProperty IconStyleProperty =
    DependencyProperty.Register(nameof(IconStyle), typeof(IconStyleEnum), typeof(IconControl), new PropertyMetadata(default(IconStyleEnum), OnIconVisualChanged));

    public static readonly DependencyProperty RenderedDrawingImageProperty =
        DependencyProperty.Register(nameof(RenderedDrawingImage), typeof(ImageSource), typeof(IconControl));

    #endregion

    #region Eigenschaften

    /// <summary>
    /// Repräsentiert das zentrale Symbol.
    /// </summary>
    public IconEnum IconMaterial
    {
        get { return (IconEnum)GetValue(IconMaterialProperty); }
        set { SetValue(IconMaterialProperty, value); }
    }

    /// <summary>
    /// Definiert den Stil des Icons, entweder als Outline oder Fill.
    /// </summary>
    public IconStyleEnum IconStyle
    {
        get { return (IconStyleEnum)GetValue(IconStyleProperty); }
        set { SetValue(IconStyleProperty, value); }
    }

    /// <summary>
    /// Liefert das gerenderte Image des Icons.
    /// </summary>
    public ImageSource? RenderedDrawingImage
    {
        get => (ImageSource?)GetValue(RenderedDrawingImageProperty);
        set => SetValue(RenderedDrawingImageProperty, value);
    }

    #endregion

    /// <summary>
    /// Reagiert auf Änderungen der Foreground-Farbe und aktualisiert das Icon.
    /// </summary>
    static IconControl()
    {
        ForegroundProperty.OverrideMetadata(typeof(IconControl),
            new FrameworkPropertyMetadata(Brushes.Black, OnIconVisualChanged));
    }

    #region Methoden

    /// <summary>
    /// Wird beim Laden des Control-Templates ausgeführt.
    /// </summary>
    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        UpdateGeometryPaths();
    }

    /// <summary>
    /// Wird aufgerufen, wenn sich eine Eigenschaft ändert und aktualisiert die Icon-Darstellung.
    /// </summary>
    private static void OnIconVisualChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is IconControl icon)
            icon.UpdateGeometryPaths();
    }

    /// <summary>
    /// Aktualisiert das angezeigte Icon.
    /// </summary>
    private void UpdateGeometryPaths()
    {
        if (IconMaterial == IconEnum.None)
        {
            RenderedDrawingImage = null;
            return;
        }

        var key = IconStyle == IconStyleEnum.Outline
            ? $"{IconMaterial}IconPath"
            : $"{IconMaterial}FillIconPath";

        var geometry = TryFindResource(key) as Geometry;
        if (geometry == null)
        {
            RenderedDrawingImage = null;
            return;
        }

        var color = Foreground ?? Brushes.Black;
        RenderedDrawingImage = BuildDrawingImage(geometry, color);
    }

    /// <summary>
    /// Erstellt ein DrawingImage basierend auf der angegebenen Geometrie.
    /// </summary>
    private static DrawingImage BuildDrawingImage(Geometry geometry, Brush brush)
    {
        return new DrawingImage(new DrawingGroup
        {
            Children =
        {
            BuildGeometryDrawing(geometry, brush),
        },
        });
    }

    /// <summary>
    /// Erstellt eine GeometryDrawing.
    /// </summary>
    private static GeometryDrawing BuildGeometryDrawing(Geometry geometry, Brush brush)
    {
        return new GeometryDrawing
        {
            Geometry = geometry,
            Brush = brush,
        };
    }

    #endregion
}