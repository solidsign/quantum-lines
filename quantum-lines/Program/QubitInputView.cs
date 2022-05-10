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
    public class QubitInputView
    {
        private Button _currentValueButton;
        private Qubit _currentQubitValue;
        // тут стоит добавить штуку, что когда нажимаешь на Label меняется стартовое значение как на Quirk
        public QubitInputView(QubitBasisState startValue, Button button)
        {
            _currentQubitValue = new Qubit(startValue);

            _currentValueButton = button;
            _currentValueButton.Content = Qubit.BasisStateToString(startValue);
        }
    }
}