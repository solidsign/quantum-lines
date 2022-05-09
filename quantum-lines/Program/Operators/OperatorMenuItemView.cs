using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quantum_lines.Program.Operators
{
    public class OperatorMenuItemView
    {
        private OperatorMenuItemViewModel _viewModel;
        public OperatorMenuItemView(OperatorId id)
        {
            _viewModel = new OperatorMenuItemViewModel(id);
        }
    }
}
