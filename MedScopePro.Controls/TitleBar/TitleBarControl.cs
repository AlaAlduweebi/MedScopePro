using MedScopePro.Controls._Elements.ContentControl;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;

namespace MedScopePro.Controls.TitleBar;

/// <summary>
/// Repräsentiert die Titelleiste der Anwendung.
/// </summary>
public class TitleBarControl : ContentControl
{
    #region Felder

    /// <summary>
    /// Speichert die Mausposition beim Drücken innerhalb der TitleBar.
    /// </summary>
    private Point _mouseDownPosition;

    /// <summary>
    /// Gibt an, ob die linke Maustaste aktuell gedrückt ist.
    /// </summary>
    private bool _isMouseDown;

    #endregion

    #region Methoden

    /// <summary>
    /// Behandelt das Drücken der linken Maustaste (Start von Drag oder Doppelklick).
    /// </summary>
    protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
    {
        base.OnMouseLeftButtonDown(e);

        var window = Window.GetWindow(this);
        if (window == null)
            return;

        if (e.ClickCount == 2)
        {
            if (window.ResizeMode != ResizeMode.NoResize)
            {
                window.WindowState = window.WindowState == WindowState.Maximized
                    ? WindowState.Normal
                    : WindowState.Maximized;
            }

            return;
        }

        _isMouseDown = true;
        _mouseDownPosition = e.GetPosition(this);
        CaptureMouse();
    }

    /// <summary>
    /// Überwacht Mausbewegung und startet das Verschieben des Fensters.
    /// </summary>
    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);

        if (!_isMouseDown || e.LeftButton != MouseButtonState.Pressed)
            return;

        var window = Window.GetWindow(this);
        if (window == null)
            return;

        Point currentPos = e.GetPosition(this);

        double moveX = Math.Abs(currentPos.X - _mouseDownPosition.X);
        double moveY = Math.Abs(currentPos.Y - _mouseDownPosition.Y);

        if (moveX < SystemParameters.MinimumHorizontalDragDistance &&
            moveY < SystemParameters.MinimumVerticalDragDistance)
        {
            return;
        }

        _isMouseDown = false;
        ReleaseMouseCapture();

        try
        {
            if (window.WindowState == WindowState.Maximized)
            {
                DragFromMaximized(window, currentPos);
            }
            else
            {
                window.DragMove();
            }
        }
        catch
        {
        }
    }

    /// <summary>
    /// Beendet den Drag-Vorgang bei Loslassen der Maustaste.
    /// </summary>
    protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
    {
        base.OnMouseLeftButtonUp(e);

        _isMouseDown = false;
        ReleaseMouseCapture();
    }

    /// <summary>
    /// Stellt ein maximiertes Fenster wieder her und startet das Ziehen.
    /// </summary>
    private void DragFromMaximized(Window window, Point currentPosInTitleBar)
    {
        Point mouseInWindow = Mouse.GetPosition(window);
        Point mouseOnScreenPx = window.PointToScreen(mouseInWindow);

        PresentationSource? source = PresentationSource.FromVisual(window);
        if (source?.CompositionTarget == null)
            return;

        Matrix fromDevice = source.CompositionTarget.TransformFromDevice;
        Point mouseOnScreenDip = fromDevice.Transform(mouseOnScreenPx);

        double percentX = _mouseDownPosition.X / ActualWidth;
        percentX = Math.Max(0, Math.Min(1, percentX));

        double restoredWidth = window.RestoreBounds.Width;
        double restoredHeight = window.RestoreBounds.Height;

        window.WindowState = WindowState.Normal;

        window.Left = mouseOnScreenDip.X - (restoredWidth * percentX);
        window.Top = mouseOnScreenDip.Y - currentPosInTitleBar.Y;

        window.DragMove();
    }

    #endregion
}