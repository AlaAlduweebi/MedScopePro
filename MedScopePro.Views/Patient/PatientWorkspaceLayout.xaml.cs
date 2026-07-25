using MedScopePro.Controls._Core.Helpers;
using MedScopePro.Controls.Widget;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;

namespace MedScopePro.Views.Patient
{
    /// <summary>
    /// Interaktionslogik für PatientWorkspaceLayout.xaml
    /// </summary>
    public partial class PatientWorkspaceLayout : UserControl
    {
        #region Fields

        /// <summary>
        /// Speichert den ursprünglichen Parent des Widgets.
        /// </summary>
        private Panel? _originalParent;

        /// <summary>
        /// Speichert die ursprüngliche Position des Widgets im Parent.
        /// </summary>
        private int _originalIndex;

        /// <summary>
        /// Referenz auf das aktuell maximierte Widget.
        /// </summary>
        private WidgetControl? _maximizedWidget;

        #endregion

        #region Konstruktor

        /// <summary>
        /// Konstruktor
        /// </summary>
        public PatientWorkspaceLayout()
        {
            InitializeComponent();

            Loaded += (_, _) =>
            {
                RegisterMaximizeEvents(this);
            };
        }

        #endregion

        #region Methoden

        /// <summary>
        /// Registriert Maximize-Events für alle WidgetControls.
        /// </summary>
        private void RegisterMaximizeEvents(DependencyObject parent)
        {
            foreach (var widget in ElementFinder.FindVisualChildren<WidgetControl>(parent))
            {
                widget.MaximizeRequested += OnWidgetMaximizeRequested;
                widget.RestoreRequested += OnWidgetRestoreRequested;
            }
        }

        /// <summary>
        /// Verschiebt das Widget ins Overlay und zeigt es groß an.
        /// </summary>
        private void OnWidgetMaximizeRequested(WidgetControl widget)
        {
            _maximizedWidget = widget;

            _originalParent = VisualTreeHelper.GetParent(widget) as Panel;
            if (_originalParent == null)
                return;

            _originalIndex = _originalParent.Children.IndexOf(widget);
            _originalParent.Children.Remove(widget);

            OverlayContent.Child = widget;
            Overlay.Visibility = Visibility.Visible;

            widget.SetMaximizeButtonVisibility(Visibility.Collapsed);
            widget.SetRestoreButtonVisibility(Visibility.Visible);
            widget.IsMaximized = true;
        }

        /// <summary>
        /// Schließt das Overlay bei Klick außerhalb des Widgets.
        /// </summary>
        private void OverlayMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource == Overlay)
                RestoreWidget();
        }

        /// <summary>
        /// Setzt das maximierte Widget zurück an seine ursprüngliche Position.
        /// </summary>
        private void RestoreWidget()
        {
            if (_maximizedWidget == null || _originalParent == null)
                return;

            OverlayContent.Child = null;

            _originalParent.Children.Insert(_originalIndex, _maximizedWidget);
            Overlay.Visibility = Visibility.Collapsed;

            _maximizedWidget?.SetMaximizeButtonVisibility(Visibility.Visible);
            _maximizedWidget?.SetRestoreButtonVisibility(Visibility.Collapsed);

            _maximizedWidget.IsMaximized = false;
            _maximizedWidget = null;
        }

        /// <summary>
        /// Handhabt das Restore-Event und setzt das Widget zurück.
        /// </summary>
        private void OnWidgetRestoreRequested(object? sender, EventArgs e)
        {
            RestoreWidget();
        }

        #endregion
    }
}