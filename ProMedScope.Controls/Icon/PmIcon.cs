using ProMedScope.Controls._Elements.ContentControl;
using System.Windows.Media;
using System.Windows;

namespace ProMedScope.Controls.Icon;

/// <summary>
/// Benutzerdefiniertes Icon.
/// </summary>	
public class PmIcon : PmContentControl
{
    #region Dependency Properties

    public static readonly DependencyProperty IconMaterialProperty =
        DependencyProperty.Register(nameof(IconMaterial), typeof(PmIconEnum), typeof(PmIcon), new PropertyMetadata(default(PmIconEnum), OnIconVisualChanged));

    public static readonly DependencyProperty RenderedDrawingImageProperty =
        DependencyProperty.Register(nameof(RenderedDrawingImage), typeof(ImageSource), typeof(PmIcon));

    #endregion

    #region Eigenschaften

    /// <summary>
    /// Repräsentiert das zentrale Symbol.
    /// </summary>
    public PmIconEnum IconMaterial
    {
        get { return (PmIconEnum)GetValue(IconMaterialProperty); }
        set { SetValue(IconMaterialProperty, value); }
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
    static PmIcon()
    {
        ForegroundProperty.OverrideMetadata(typeof(PmIcon),
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
        if (d is PmIcon icon)
            icon.UpdateGeometryPaths();
    }

    /// <summary>
    /// Aktualisiert das angezeigte Icon.
    /// </summary>
    private void UpdateGeometryPaths()
    {
        if (IconMaterial == PmIconEnum.None)
        {
            RenderedDrawingImage = null;
            return;
        }

        var key = $"{IconMaterial}IconPath";

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