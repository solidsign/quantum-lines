using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using MatrixDotNet;
using quantum_lines.Program.Operators;
using quantum_lines.Utils;

namespace quantum_lines.Program.Calculation
{
    public class ColumnCalculator
    {
        private List<Qubit> _inValues;
        private List<OperatorModel> _operators;

        public ColumnCalculator(List<Qubit> inValues, List<OperatorOnLineModel> operators)
        {
            _inValues = inValues;
            _operators = operators.Select(x => x.OperatorModel).ToList();
        }

        public List<Qubit> Calculate()
        {
            List<Qubit> outValues;

            if (_operators.Any(x => x.OperatorClass == OperatorClass.Controller))
            {
                outValues = CalculateWithController(_operators.FindIndex(x => x.OperatorClass == OperatorClass.Controller));
            }
            else
            {
                outValues = CalculateWithOutController();
            }

            return outValues;
        }

        private List<Qubit> CalculateWithController(int controllerIndex)
        {
            return null;
        }

        private List<Qubit> CalculateWithOutController()
        {
            var qubits = TensorMultiplier.Multiply(_inValues.Select(x => x.StateMatrix).ToArray());
            for (int i = 0; i < _operators.Count; i++)
            {
                
            }

            return null;
        }

        private Matrix<Complex> GetOperatorMatrix(int index)
        {
            var op = _operators[index];
            switch (op.OperatorClass)
            {
                case OperatorClass.FixedMatrix:
                    return ((FixedMatrixOperatorModel) op).GetMatrix();
                // case OperatorClass.SizeDependentMatrix:
                //     return ((SizeDependentOperatorModel) op).GetMatrix(index);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}