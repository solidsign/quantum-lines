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
    public class QubitInputView : IEquatable<Button>, IDisposable
    {
        private Button _currentValueButton;
        
        private QubitInputViewModel _viewModel;
        
        public QubitInputView(QubitBasisState startValue, Button button, Action<QubitInputModel> addInput)
        {
            _viewModel = new QubitInputViewModel(startValue, addInput);

            _currentValueButton = button;
            _currentValueButton.Content = _viewModel.QubitState;
            _currentValueButton.Click += ChangeValueButtonOnClick;
        }

        private void ChangeValueButtonOnClick(object sender, RoutedEventArgs e)
        {
            _viewModel.SwitchState();
            _currentValueButton.Content = _viewModel.QubitState;
        }

        public bool Equals(Button? other)
        {
            return _currentValueButton == other;
        }

        public void Dispose()
        {
            _currentValueButton.Click -= ChangeValueButtonOnClick;
            _viewModel.Dispose();
        }
    }

    public class QubitInputViewModel : IDisposable
    {
        private QubitInputModel _model;
        private QubitBasisState _basisState;

        public string QubitState => Qubit.BasisStateToString(_basisState);
        public QubitInputViewModel(QubitBasisState startValue, Action<QubitInputModel> addInput)
        {
            _basisState = startValue;
            _model = new QubitInputModel(startValue);
            addInput(_model);
        }
        public void SwitchState()
        {
            int n = (int)_basisState + 1;
            n %= Enum.GetValues(typeof(QubitBasisState)).Length;
            _basisState = (QubitBasisState) n;
            _model.UpdateValue(_basisState);
        }

        public void Dispose()
        {
            _model.Dispose();
        }
    }
}