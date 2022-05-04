using System.Collections.Generic;
using quantum_lines.Operators;

namespace quantum_lines.Qubit
{
    public class QubitsSolver
    {
        private SchemeModel _model;
        private List<Qubit> _values;
        
        public QubitsSolver(SchemeModel model, IEnumerable<Qubit> startValues)
        {
            _model = model;
            _values = new List<Qubit>(startValues);
        }

        public List<Qubit> Calculate()
        {
            return _values;
        }
    }
}