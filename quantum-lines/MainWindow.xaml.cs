using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using quantum_lines.Program;

namespace quantum_lines
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int QUBIT_LINE_SIZE = 10;
        private ProgramView _programView;

        public MainWindow()
        {
            InitializeComponent();
            _programView = new ProgramView(CreateMenuButtons(), CreateQubitLines()); // <- от сюда по сути и идет инициализация всей приложухи
        }

        private Dictionary<OperatorId, ToggleButton> CreateMenuButtons()
        {
            var buttons = new Dictionary<OperatorId, ToggleButton>
            {
                {OperatorId.Not, notMenuButton},
                {OperatorId.Hadamard, hadamardMenuButton},
                {OperatorId.PaulY, paulYMenuButton},
                {OperatorId.PaulZ, paulZMenuButton},
                {OperatorId.PhaseS, phaseSMenuButton},
                {OperatorId.ElemP8, elemP8MenuButton},
                {OperatorId.QFT, QFTMenuButton}
            };
            return buttons;
        }

        private List<QubitLineArguments> CreateQubitLines()
        {
            var res = new List<QubitLineArguments>(QUBIT_LINE_SIZE);
            for (int i = 0; i < QUBIT_LINE_SIZE; i++)
            {
                res.Add(CreateQubitLine(i));
            }

            return res;
        }

        private QubitLineArguments CreateQubitLine(int index)
        {
            AddLine(index);
            var images = AddOperatorImages(index);
            var qubitBasisStateButton = QubitBasisStateButton(index);
            var qubitResult = AddQubitResult(index);

            return new QubitLineArguments(qubitBasisStateButton, QubitBasisState.Zero, images, qubitResult);
        }

        private List<(OperatorId id, Image image)> AddOperatorImages(int index)
        {
            var images = new List<(OperatorId id, Image image)>(QUBIT_LINE_SIZE);

            var stackPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal
            };
            Grid.SetRow(stackPanel, index);
            Grid.SetColumn(stackPanel, 1);

            for (int i = 0; i < QUBIT_LINE_SIZE; i++)
            {
                var image = new Image()
                {
                    Height = 50,
                    Width = 50,
                    Margin = new Thickness(10, 0, 10, 0)
                };
                stackPanel.Children.Add(image);
                images.Add((OperatorId.Empty, image));
            }

            schemeGrid.Children.Add(stackPanel);
            return images;
        }

        private Label AddQubitResult(int index)
        {
            var qubitResultLabel = new Label()
            {
                Height = 50,
                Width = 50,
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center
            };
            Panel.SetZIndex(qubitResultLabel, 2);
            Grid.SetColumn(qubitResultLabel, 2);
            Grid.SetRow(qubitResultLabel, index);

            var qubitResultBackground = new Image()
            {
                Height = 50,
                Width = 50,
                Source = new BitmapImage(new Uri(@"/Picture/clearOperatorOnLine.png", UriKind.Relative))
            };
            Panel.SetZIndex(qubitResultBackground, 1);
            Grid.SetColumn(qubitResultBackground, 2);
            Grid.SetRow(qubitResultBackground, index);

            schemeGrid.Children.Add(qubitResultLabel);
            schemeGrid.Children.Add(qubitResultBackground);

            return qubitResultLabel;
        }

        private Button QubitBasisStateButton(int index)
        {
            var qubitBasisStateButton = new Button()
            {
                Height = 28,
                Width = 28,
            };
            Panel.SetZIndex(qubitBasisStateButton, 1);
            Grid.SetColumn(qubitBasisStateButton, 0);
            Grid.SetRow(qubitBasisStateButton, index);
            schemeGrid.Children.Add(qubitBasisStateButton);
            return qubitBasisStateButton;
        }

        private void AddLine(int index)
        {
            var line = new Line
            {
                X1 = 10,
                Stretch = Stretch.Fill,
                Stroke = new SolidColorBrush(Colors.Black)
            };
            Grid.SetRow(line, index);
            Grid.SetColumnSpan(line, 3);
            schemeGrid.Children.Add(line);
        }
    }
}
