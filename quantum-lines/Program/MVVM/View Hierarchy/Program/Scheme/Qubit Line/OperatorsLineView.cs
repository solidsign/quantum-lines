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
using quantum_lines.Program.Operators;

namespace quantum_lines
{
    public class OperatorsLineView
    {
        private List<OperatorOnLineView> _views;
        public OperatorsLineView(Dictionary<OperatorId, Image> buttons, MenuSchemeConnector connector)
        {
            _views = new List<OperatorOnLineView>();
            foreach (var i in buttons)
            {
                _views.Add(new OperatorOnLineView(i.Key, i.Value, connector));
            }
        }
    }
}