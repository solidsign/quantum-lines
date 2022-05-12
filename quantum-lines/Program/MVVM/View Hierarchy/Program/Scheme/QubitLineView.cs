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
using quantum_lines.Program;

namespace quantum_lines
{
    public class QubitLineView
    {
        private QubitInputView _startValue;
        private OperatorsLineView _operatorsLine;

        public QubitLineView(QubitLineArguments args, MenuSchemeConnector connector)
        {
            _startValue = new QubitInputView(args.StartValue, args.StartValueButton);
            _operatorsLine = new OperatorsLineView(args.OperatorsLineImages, connector);
        }
    }
}