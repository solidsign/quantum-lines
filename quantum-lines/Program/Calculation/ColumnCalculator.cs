using System.Collections.Generic;
using System.Linq;
using quantum_lines.Program.Operators;

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
            List<Qubit> outValues = new List<Qubit>(_inValues);
            
            // TODO

            return outValues;
        }
    }
}