using System.Numerics;
using System.Windows.Media.Imaging;
using MatrixDotNet;

namespace quantum_lines.Program.Operators
{
    public class ControlOperatorModel : ControllerOperatorModelBase
    {
        public ControlOperatorModel(BitmapImage image) : base(OperatorId.Control, image)
        {
        }

        public override Matrix<Complex> ControlMatrix(Matrix<Complex> matrixWithoutControls, int controllingQubit)
        {
            // TODO
            return matrixWithoutControls;
        }
    }
}