using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace quantum_lines
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Thumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            UIElement thumb = e.Source as UIElement;

            Canvas.SetLeft(thumb, Canvas.GetLeft(thumb) + e.HorizontalChange);
            Canvas.SetTop(thumb, Canvas.GetTop(thumb) + e.VerticalChange);
            // Point currentMousePosition = Mouse.GetPosition(Application.Current.MainWindow);     //получает координаты клика по холсту
            double left = Canvas.GetLeft((UIElement)sender);
            double top = Canvas.GetTop((UIElement)sender);

        }

        private void InsertingSquares(object sender, MouseEventArgs e)
        {

        }

        private void TrackingCoord(object sender, MouseEventArgs e)
        {
            Point pt = e.GetPosition(this);
            lblCoordinateInfo.Content = String.Format("X: {0}, Y: {1}", pt.X, pt.Y);
        }

    }
}
