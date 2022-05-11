using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace quantum_lines.Program
{
    public class ProgramView
    {
        private SchemeView _scheme;
        private OperatorsMenuView _operatorsMenu;
        public ProgramView(Dictionary<OperatorId, ToggleButton> operatorsMenuButtons, List<QubitLineArguments> qubitLineArguments)
        {
            var menuSchemeConnector = new MenuSchemeConnector();
            _scheme = new SchemeView(menuSchemeConnector, qubitLineArguments);
            _operatorsMenu = new OperatorsMenuView(operatorsMenuButtons, menuSchemeConnector);
        }




    }
}
