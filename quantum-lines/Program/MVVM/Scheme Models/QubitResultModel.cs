using System;

namespace quantum_lines
{
    public class QubitResultModel
    {
        public Qubit Value { get; private set; }

        public void SetResult(Qubit value)
        {
            Value = value;
            ResultUpdated?.Invoke();
        }

        public event Action ResultUpdated; 
        
        public QubitResultModel()
        {
            Value = new Qubit(QubitBasisState.Zero);
        }
    }
}