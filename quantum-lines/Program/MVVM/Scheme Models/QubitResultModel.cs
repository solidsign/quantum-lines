using System;

namespace quantum_lines
{
    public class QubitResultModel
    {
        private Qubit _value;

        public Qubit Value
        {
            get => _value;
            set
            {
                _value = value;
                ResultUpdated?.Invoke();
            }
        }

        public event Action ResultUpdated; 
        
        public QubitResultModel()
        {
            _value = new Qubit(QubitBasisState.Zero);
        }
    }
}