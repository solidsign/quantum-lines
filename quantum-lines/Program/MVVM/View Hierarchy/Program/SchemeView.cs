using quantum_lines.Program;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using quantum_lines.Program.Calculation;
using quantum_lines.Program.Operators;

namespace quantum_lines
{
    // это все окно с кубитами и насаженными операторами
    public class SchemeView
    {
        private List<QubitLineView> _qubitLines;
        private SchemeViewModel _viewModel;

        public SchemeView(MenuSchemeConnector menuSchemeConnector, List<QubitLineArguments> qubitLines)
        {
            _viewModel = new SchemeViewModel();
            _qubitLines = new List<QubitLineView>();
            foreach (var qubitLine in qubitLines)
            {
                _qubitLines.Add(new QubitLineView(qubitLine, menuSchemeConnector, _viewModel.AddResult, _viewModel.AddInput, _viewModel.AddLine));
            }
        }

    }

    public class SchemeViewModel
    {
        private SchemeModel _model;
        private CalculationHandler _calculationHandler;

        public SchemeViewModel()
        {
            _model = new SchemeModel();
            _calculationHandler = new CalculationHandler(_model);
        }
        
        public void AddInput(QubitInputModel model)
        {
            _model.Inputs.Add(model);
            model.ValueUpdated += _model.InvokeSchemeUpdated;
        }

        public void AddResult(QubitResultModel model)
        {
            _model.Results.Add(model);
        }

        public void AddLine(List<OperatorOnLineModel> models)
        {
            _model.OperatorLines.Add(models);
            foreach (var model in models)
            {
                model.OperatorOnLineUpdated += _model.InvokeSchemeUpdated;
            }
        }
        
        public void RemoveInput(QubitInputModel model)
        {
            model.ValueUpdated -= _model.InvokeSchemeUpdated;
            _model.Inputs.Remove(model);
        }

        public void RemoveResult(QubitResultModel model)
        {
            _model.Results.Remove(model);
        }

        public void RemoveLine(List<OperatorOnLineModel> models)
        {
            foreach (var model in models)
            {
                model.OperatorOnLineUpdated -= _model.InvokeSchemeUpdated;
            }
            _model.OperatorLines.Remove(models);
        }
    }
}
