using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using quantum_lines.Program.Operators;

namespace quantum_lines.Program.Calculation
{
    public class CalculationHandler
    {
        private readonly SchemeModel _model;

        public CalculationHandler(SchemeModel model)
        {
            _model = model;
            _model.SchemeUpdated += Calculate;
        }

        private void Calculate()
        {
            List<Qubit> workingValues = new List<Qubit>(_model.Inputs.Select(x => x.StartQubitValue).ToList());

            foreach (var operatorLine in _model.OperatorLines)
            {
                workingValues = new ColumnCalculator(workingValues, operatorLine).Calculate();
            }

            TranslateValuesToResult(workingValues);
        }

        private void TranslateValuesToResult(List<Qubit> values)
        {
            for (int i = 0; i < values.Count; i++)
            {
                _model.Results[i].SetResult(values[i]);
            }
        }
    }
}