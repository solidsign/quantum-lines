using System.Numerics;
using System.Windows.Media.Imaging;
using MatrixDotNet;

namespace quantum_lines.Program.Operators
{
    public class QFTOperatorModel : OperatorModel
    {
        public QFTOperatorModel(OperatorId operatorId, BitmapImage image) : base(operatorId, OperatorClass.QubitNumberParameteredMatrix, image)
        {
        }

        public Matrix<Complex> GetMatrix(int n)
        {
            // TODO
            return null;
        }
    }
}