using quantum_lines.Program.Operators;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Linq;

namespace quantum_lines.Program
{
    public class OperatorsMenuView
    {
        private List<OperatorMenuItemView> _operators;
        private Dictionary<OperatorId, ToggleButton> _operatorsButtons;

        public OperatorsMenuView(Dictionary<OperatorId, ToggleButton> operatorsButtons, MenuSchemeConnector menuSchemeConnector)
        {
            menuSchemeConnector.SetAnyCheckedDel(AnyChecked);
             menuSchemeConnector.OnSet += OnSet;
            _operatorsButtons = operatorsButtons;
            _operators = new List<OperatorMenuItemView>();

            foreach (var operatorButton in operatorsButtons)
            {
                _operators.Add(new OperatorMenuItemView(operatorButton.Key, operatorButton.Value, menuSchemeConnector));
            }

        }
        public bool AnyChecked() => _operatorsButtons.Any(x => x.Value.IsChecked.HasValue ? x.Value.IsChecked.Value : false);
        private void OnSet(OperatorId oldId, OperatorId newId)
        {
            if (oldId == OperatorId.Undefined) return;
            if (newId == OperatorId.Undefined) return;
            _operatorsButtons[oldId].IsChecked = false;
        }
    }
}