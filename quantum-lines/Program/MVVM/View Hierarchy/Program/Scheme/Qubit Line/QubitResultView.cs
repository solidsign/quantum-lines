using System;
using System.Windows.Controls;

namespace quantum_lines
{
    public class QubitResultView
    {
        private QubitResultViewModel _viewModel;
        private Label _label;

        public QubitResultView(Label label)
        {
            _viewModel = new QubitResultViewModel();
            _viewModel.ResultUpdate += UpdateLabel;
            _label = label;
            _label.Content = _viewModel.ONPossibility;
        }

        private void UpdateLabel() => _label.Content = _viewModel.ONPossibility;
    }

    public class QubitResultViewModel
    {
        private QubitResultModel _model;
        public string ONPossibility => _model.Value.ONPossitility.ToString();
        public event Action ResultUpdate
        {
            add => _model.ResultUpdate += value;
            remove => _model.ResultUpdate -= value;
        }

        public QubitResultViewModel()
        {
            _model = new QubitResultModel();
        }
    }

    public class QubitResultModel
    {
        private Qubit _value;

        public Qubit Value
        {
            get => _value;
            set
            {
                _value = value;
                ResultUpdate?.Invoke();
            }
        }

        public event Action ResultUpdate; 
        
        public QubitResultModel()
        {
            _value = new Qubit(QubitBasisState.Zero);
        }
    }
}