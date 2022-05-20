using System;

namespace quantum_lines
{
    public class QubitResultModel : IDisposable
    {
        public Possibility Value { get; private set; }

        public void SetResult(Possibility value)
        {
            Value = value;
            ResultUpdated?.Invoke();
        }

        public event Action? ResultUpdated; 
        
        public QubitResultModel()
        {
            Value = new Qubit(QubitBasisState.Zero).ONPossitility;
        }

        public void Dispose()
        {
            ResultUpdated = null;
        }
    }
}