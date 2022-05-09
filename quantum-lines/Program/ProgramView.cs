using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace quantum_lines.Program
{
    // он будет создаваться в MainWindow при старте приложухи
    // и он типа каскадом будет создавать все вьюхи, вьюмодели, модели
    public class ProgramView
    {
        private SchemeView _scheme;
        private OperatorsMenuView _operatorsMenu;
        private MenuSchemeConnector _menuSchemeConnector;
        public ProgramView(Dictionary<OperatorId, ToggleButton> operatorsMenuButtons)
        {
            _menuSchemeConnector = new MenuSchemeConnector();
            _scheme = new SchemeView(_menuSchemeConnector);
            _operatorsMenu = new OperatorsMenuView(operatorsMenuButtons, _menuSchemeConnector);
        }




    }
}
