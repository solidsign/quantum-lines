using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Windows.Documents;
using MatrixDotNet;
using quantum_lines.Program.Operators;
using quantum_lines.Utils;

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
            List<Qubit> inValues = new List<Qubit>(_model.Inputs.Select(x => x.StartQubitValue).ToList());
            var workingValues = GetStateMatrix(inValues);

            foreach (var operatorColumn in _model.OperatorColumns)
            {
                workingValues = new ColumnCalculator(workingValues, operatorColumn).Calculate();
            }

            TranslateValuesToResult(workingValues);
        }

        private void TranslateValuesToResult(Matrix<Complex> values)
        {
            for (int i = 0; i < _model.Results.Count; i++)
            {
                _model.Results[_model.Results.Count - i - 1].SetResult(MeasureResult(values, i));
            }
        }

        private Possibility MeasureResult(Matrix<Complex> values, int i)
        {
            double possibility = 0;
            for (int j = 0; j < values.Rows; j++)
            {
                if ((j >> i) % 2 == 0) continue;
                var state = new Matrix<Complex>(values.Rows, 1, Complex.Zero);
                state[j, 0] = Complex.One;
                var scalar = ScalarMultiplier.ComplexMultiply(values, state);
                possibility += scalar.Magnitude * scalar.Magnitude;
            }
            
            return new Possibility(possibility);
        }

        private Matrix<Complex> GetStateMatrix(List<Qubit> qubits)
        {
            var res = new Matrix<Complex>(new Complex[1, 1] {{1}});
            foreach (var qubit in qubits)
            {
                res = TensorMultiplier.Multiply(res, qubit.StateMatrix);
            }
            return res;
        }
    }
}