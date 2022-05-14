using System.Numerics;
using System.Windows.Media.Imaging;
using MatrixDotNet;

namespace quantum_lines.Program.Operators
{
    public class QFTOperatorModel : OperatorModel
    {
        public QFTOperatorModel(BitmapImage image) : base(OperatorId.QFT, OperatorClass.QubitNumberParameteredMatrix, image)
        {
        }

        public Matrix<Complex> GetMatrix(int n)
        {
            // TODO
            return null;
        }
    }
}