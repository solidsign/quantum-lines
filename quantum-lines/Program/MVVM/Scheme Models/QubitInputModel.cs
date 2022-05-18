using System;

namespace quantum_lines
{
    public class QubitInputModel : IDisposable
    {
        public Qubit StartQubitValue { get; private set; }
        public event Action? ValueUpdated;

        public QubitInputModel(QubitBasisState startQubitValue)
        {
            StartQubitValue = new Qubit(startQubitValue);
        }

        public void UpdateValue(QubitBasisState state)
        {
            StartQubitValue = new Qubit(state);
            ValueUpdated?.Invoke();
        }

        public void Dispose()
        {
            ValueUpdated = null;
        }
    }
}