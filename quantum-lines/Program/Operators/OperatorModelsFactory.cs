using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quantum_lines.Program.Operators
{
    public static class OperatorModelsFactory
    {
        public static OperatorModel Create(OperatorId operatorId)
        {
            switch (operatorId)
            {
                case OperatorId.Hadamard:
                    return null;
                case OperatorId.Not:
                    return null;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
