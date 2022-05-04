using System;

namespace quantum_lines.Operators
{
    public class OperatorsFactory
    {
        public Operator Create(OperatorId operatorId)
        {
            switch (operatorId)
            {
                case OperatorId.Hadamard:
                    return null;
                case OperatorId.Not:
                    return null;
                default:
                    throw new ArgumentOutOfRangeException(nameof(operatorId), operatorId, null);
            }
        }
    }
}