﻿using quantum_lines.Program;
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
        private MenuSchemeConnector _menuSchemeConnector;

        public SchemeView(MenuSchemeConnector menuSchemeConnector, List<QubitLineArguments> qubitLines)
        {
            _menuSchemeConnector = menuSchemeConnector;
            _viewModel = new SchemeViewModel();
            _qubitLines = new List<QubitLineView>();
            foreach (var qubitLine in qubitLines)
            {
                _qubitLines.Add(new QubitLineView(qubitLine, menuSchemeConnector, _viewModel.AddResult, _viewModel.AddInput, _viewModel.AddLine));
            }
            
            for (var i = 0; i < _qubitLines.Count; i++)
            {
                _qubitLines[i].InitAddButtons(
                    i - 1 >= 0 ? _qubitLines[i - 1] : null,
                    i + 1 < _qubitLines.Count ? _qubitLines[i + 1] : null);
            }
        }

        public void AddLine(QubitLineArguments args)
        {
            _qubitLines.Add(new QubitLineView(args, _menuSchemeConnector, _viewModel.AddResult, _viewModel.AddInput, _viewModel.AddLine));
            var last = _qubitLines.TakeLast(2).ToList();
            last[0].ReinitBottomAddButtons(last[1]);
            last[1].InitAddButtons(last[0], null);
        }

        public void RemoveLine()
        {
            var last = _qubitLines.Last();
            _qubitLines.Remove(last);
            last.Dispose();
            last = _qubitLines.Last();
            last.ReinitBottomAddButtons(null);
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
                model.ValidateModelUpdate = ValidateOperatorUpdate;
            }

            bool ValidateOperatorUpdate(OperatorModel newOperator, OperatorOnLineModel currentOperator)
            {
                if (newOperator.OperatorClass != OperatorClass.Controller) return true;
                
                foreach (var operatorOnLineModel in FindLine(currentOperator))
                {
                    if (operatorOnLineModel.OperatorModel.OperatorClass == OperatorClass.Controller)
                        return false;
                }

                return true;
            }

            List<OperatorOnLineModel> FindLine(OperatorOnLineModel model)
            {
                foreach (var operatorLine in _model.OperatorLines)
                {
                    foreach (var operatorOnLineModel in operatorLine)
                    {
                        if (operatorOnLineModel == model) return operatorLine;
                    }
                }

                throw new KeyNotFoundException();
            }
        }
    }
}
