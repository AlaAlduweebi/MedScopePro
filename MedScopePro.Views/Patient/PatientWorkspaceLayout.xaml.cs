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
            foreach (var widget in FindVisualChildren<WidgetControl>(parent))
            {
                widget.MaximizeRequested += OnWidgetMaximizeRequested;
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

            _maximizedWidget = null;
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
}