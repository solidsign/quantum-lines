using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<Operation> Operations { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            Operations = new ObservableCollection<Operation>
        {
            new Operation {Id=1, ImagePath="/Images/iphone6s.jpg", Title="Operator" },
            new Operation {Id=2, ImagePath="/Images/lumia950.jpg", Title="OperatorFactory" },
            new Operation {Id=3, ImagePath="/Images/nexus5x.jpg", Title="OperatorsHolder" },
        };
            operationsList.ItemsSource = Operations;

        }

        public class Operation
        {
            public int Id { get; set; }
            public string Title { get; set; } // модель телефона
            public string ImagePath { get; set; } // путь к изображению
        }

        private void operationsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Operation p = (Operation)operationsList.SelectedItem;
            MessageBox.Show(p.Title);
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
