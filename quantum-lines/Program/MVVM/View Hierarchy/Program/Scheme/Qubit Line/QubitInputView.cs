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
        private QubitBasisState _basisState;
        private Qubit _startQubitValue;

        public Qubit StartValue => _startQubitValue;
        
        public QubitInputView(QubitBasisState startValue, Button button)
        {
            _startQubitValue = new Qubit(startValue);
            _basisState = startValue;

            _currentValueButton = button;
            _currentValueButton.Content = Qubit.BasisStateToString(startValue);
            _currentValueButton.Click += ChangeValueButtonOnClick;
        }

        private void ChangeValueButtonOnClick(object sender, RoutedEventArgs e)
        {
            int n = (int)_basisState + 1;
            n %= Enum.GetValues(typeof(QubitBasisState)).Length;
            var bs = (QubitBasisState) n;
            _startQubitValue = new Qubit(bs);
            _basisState = bs;
            _currentValueButton.Content = Qubit.BasisStateToString(bs);
        }
    }
}