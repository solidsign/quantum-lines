using System.Numerics;
using System.Windows.Media.Imaging;
using MatrixDotNet;

namespace quantum_lines.Program.Operators
{
    public class AntiControlOperatorModel : ControllerOperatorModelBase
    {
        public AntiControlOperatorModel(BitmapImage image) : base(OperatorId.AntiControl, image)
        {
        }

        public override Matrix<Complex> ControlMatrix(Matrix<Complex> matrixWithoutControls)
        {
            // TODO
            return matrixWithoutControls;
        }
    }
}