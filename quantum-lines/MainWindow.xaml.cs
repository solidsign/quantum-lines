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
        private const int QUBIT_LINES_AMOUNT = 8;
        private int qubitLinesAmount;
        private ProgramView _programView;

        private List<QubitLineGridComponents> _qubitLines;

        public MainWindow()
        {
            InitializeComponent();
            qubitLinesAmount = 0;
            _qubitLines = new List<QubitLineGridComponents>(QUBIT_LINES_AMOUNT);
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
            var res = new List<QubitLineArguments>(QUBIT_LINES_AMOUNT);
            for (int i = 0; i < QUBIT_LINES_AMOUNT; i++)
            {
                res.Add(CreateQubitLine(i));
            }

            qubitLinesAmount = res.Count;
            return res;
        }

        private QubitLineArguments CreateQubitLine(int index)
        {
            var line = AddLine(index);
            var (images,upButtons,downButtons, stackPanel) = AddOperatorImages(index);
            var qubitBasisStateButton = QubitBasisStateButton(index);
            var (qubitResult, qubitResultImage) = AddQubitResult(index);

            var qubitLineArguments = new QubitLineArguments(qubitBasisStateButton, QubitBasisState.Zero, images, upButtons, downButtons, qubitResult);
            _qubitLines.Add(new QubitLineGridComponents(qubitLineArguments, line, qubitResultImage, stackPanel));
            return qubitLineArguments;
        }

        private (List<(OperatorId id, Image image)>, List<Button>, List<Button>, StackPanel) AddOperatorImages(int index)
        {
            var images = new List<(OperatorId id, Image image)>(QUBIT_LINE_SIZE);
            var upButtons = new List<Button>(QUBIT_LINE_SIZE);
            var downButtons = new List<Button>(QUBIT_LINE_SIZE);

            var overallStackPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal
            };
            Grid.SetRow(overallStackPanel, index);
            Grid.SetColumn(overallStackPanel, 1);

            for (int i = 0; i < QUBIT_LINE_SIZE; i++)
            {
                var stackPanel = new StackPanel
                {
                    Orientation = Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };

                var image = new Image()
                {
                    Height = 50,
                    Width = 50,
                    Margin = new Thickness(10, 0, 10, 0)
                };

                var upAddButton = new Button
                {
                    Content = "↑",
                    Width = 20,
                    FontSize = 10,
                    Visibility = Visibility.Hidden
                };
                
                var downAddButton = new Button
                {
                    Content = "↓",
                    Width = 20,
                    FontSize = 10,
                    Visibility = Visibility.Hidden
                };
                
                stackPanel.Children.Add(upAddButton);
                stackPanel.Children.Add(image);
                stackPanel.Children.Add(downAddButton);
                overallStackPanel.Children.Add(stackPanel);
                images.Add((OperatorId.Empty, image));
                upButtons.Add(upAddButton);
                downButtons.Add(downAddButton);
            }

            schemeGrid.Children.Add(overallStackPanel);
            return (images, upButtons, downButtons, overallStackPanel);
        }

        private (Label, Image) AddQubitResult(int index)
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

            return (qubitResultLabel, qubitResultBackground);
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

        private Line AddLine(int index)
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
            return line;
        }

        private void addLineButton_Click(object sender, RoutedEventArgs e)
        {
            if (qubitLinesAmount == 8)
            {
                MessageBox.Show("Достигнуто максимальное число кубит - 8");
                return;
            }
            
            _programView.AddLine(CreateQubitLine(qubitLinesAmount));
            qubitLinesAmount++;
        }

        private void removeLineButton_Click(object sender, RoutedEventArgs e)
        {
            if (qubitLinesAmount == 1)
            {
                MessageBox.Show("Достигнуто минимальное число кубит - 1");
                return;
            }
            
            _programView.RemoveLine();
            RemoveQubitLine();
            qubitLinesAmount--;
        }

        private void RemoveQubitLine()
        {
            var last = _qubitLines.Last();
            schemeGrid.Children.Remove(last.Line);
            schemeGrid.Children.Remove(last.QubitResultLabel);
            schemeGrid.Children.Remove(last.ResultBackground);
            schemeGrid.Children.Remove(last.StartValueButton);
            schemeGrid.Children.Remove(last.OperatorsLineImages);

            _qubitLines.Remove(last);
        }
    }
}
