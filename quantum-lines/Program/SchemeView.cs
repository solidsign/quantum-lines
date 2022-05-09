using quantum_lines.Program;
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
    // это все окно с кубитами и насаженными операторами
    public class SchemeView
    {
        private MenuSchemeConnector _menuSchemeConnector;
        private List<QubitLineView> _qubitLines;

        public SchemeView(MenuSchemeConnector menuSchemeConnector)
        {
            _menuSchemeConnector = menuSchemeConnector;
        }

    }
}
