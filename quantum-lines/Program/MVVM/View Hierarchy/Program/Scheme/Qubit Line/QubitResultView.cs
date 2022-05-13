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
            add => _model.ResultUpdated += value;
            remove => _model.ResultUpdated -= value;
        }

        public QubitResultViewModel()
        {
            _model = new QubitResultModel();
        }
    }
}