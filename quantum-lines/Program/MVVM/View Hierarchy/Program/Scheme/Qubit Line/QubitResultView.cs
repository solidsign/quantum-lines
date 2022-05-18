using System;
using System.Windows.Controls;

namespace quantum_lines
{
    public class QubitResultView : IEquatable<Label>, IDisposable
    {
        private QubitResultViewModel _viewModel;
        private Label _label;

        public QubitResultView(Label label, Action<QubitResultModel> addResult)
        {
            _viewModel = new QubitResultViewModel(addResult);
            _viewModel.ResultUpdate += UpdateLabel;
            _label = label;
            _label.Content = _viewModel.ONPossibility;
        }

        private void UpdateLabel() => _label.Content = _viewModel.ONPossibility;
        public bool Equals(Label? other)
        {
            return _label == other;
        }

        public void Dispose()
        {
            _viewModel.ResultUpdate -= UpdateLabel;
            _viewModel.Dispose();
        }
    }

    public class QubitResultViewModel : IDisposable
    {
        private QubitResultModel _model;
        public string ONPossibility => _model.Value.ONPossitility.ToString();
        public event Action? ResultUpdate
        {
            add => _model.ResultUpdated += value;
            remove => _model.ResultUpdated -= value;
        }

        public QubitResultViewModel(Action<QubitResultModel> addResult)
        {
            _model = new QubitResultModel();
            addResult(_model);
        }

        public void Dispose()
        {
            _model.Dispose();
        }
    }
}