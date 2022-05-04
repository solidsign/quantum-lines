using System.Collections.Generic;

namespace quantum_lines.Operators
{
    public static class OperatorsHolder
    {
        private static Dictionary<OperatorId, Operator> _operators;

        public static IReadOnlyDictionary<OperatorId, Operator> Operators => _operators;

        public static void LoadOperators()
        {
            // см readme в operators/matrixes
        }
    }
}