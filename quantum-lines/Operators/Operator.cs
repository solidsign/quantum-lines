using MatrixDotNet;

namespace quantum_lines.Operators
{
    public class Operator
    {
        private OperatorId _id;
        private Matrix<float> _operatorMatrix;

        public Operator(OperatorId id,Matrix<float> operatorMatrix)
        {
            _id = id;
            _operatorMatrix = operatorMatrix;
        }
    }
}