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
                {OperatorId.QFT, QFTMenuButton}
            };
            return buttons;
        }

        
        private List<QubitLineArguments> CreateQubitLines()
        {
            var images = new List<(OperatorId id, Image image)>
            {
                (OperatorId.Empty, firstQBitImage),
                (OperatorId.Empty, secondQBitImage),
                (OperatorId.Empty, thirdQBitImage),
                (OperatorId.Empty, fourthQBitImage),
                (OperatorId.Empty, fifthQBitImage),
            };
            List<QubitLineArguments> qubitLineArguments = new List<QubitLineArguments>();   
            qubitLineArguments.Add(new QubitLineArguments(qubitBasisStateButton, QubitBasisState.Zero, images, qubitResult)); 
            return qubitLineArguments;
        }

    }
}
