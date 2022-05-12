using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace quantum_lines.Program.Operators
{
    public class OperatorMenuItemView
    {
        private OperatorMenuItemViewModel _viewModel;
        private MenuSchemeConnector _connector;
        public OperatorMenuItemView(OperatorId id, ToggleButton button, MenuSchemeConnector connector)
        {
            _connector = connector;
            _viewModel = new OperatorMenuItemViewModel(id);
            button.Unchecked += Button_UnChecked;
            button.Checked += Button_Checked;

        }

        private void Button_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            _connector.SetCurrentOperator(_viewModel.OperatorId);
            _viewModel.OnClick();
        }
        private void Button_UnChecked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (_connector.AnyChecked()) return;
            _connector.SetCurrentOperator(OperatorId.Empty);
        }

    }
}
