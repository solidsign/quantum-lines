using System.Numerics;
using System.Windows.Media.Imaging;
using MatrixDotNet;

namespace quantum_lines.Program.Operators
{
    public class FixedMatrixOperatorModel : OperatorModel
    {
        protected readonly Matrix<Complex> _matrix;

        public FixedMatrixOperatorModel(OperatorId operatorId, Matrix<Complex> matrix, BitmapImage image) : base(
            operatorId, OperatorClass.FixedMatrix, image)
        {
            _matrix = matrix;
        }

        public Matrix<Complex> GetMatrix() => _matrix;
    }
}