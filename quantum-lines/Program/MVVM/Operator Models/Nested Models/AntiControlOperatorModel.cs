using System.Numerics;
using System.Windows.Media.Imaging;
using MatrixDotNet;
using quantum_lines.Utils;

namespace quantum_lines.Program.Operators
{
    public class AntiControlOperatorModel : ControllerOperatorModelBase
    {
        public AntiControlOperatorModel(BitmapImage image) : base(OperatorId.AntiControl, image)
        {
        }

        public override Matrix<Complex> ControlMatrix(Matrix<Complex> matrixWithoutControls)
        {
            var onMatrix = ((FixedMatrixOperatorModel) OperatorModelsFactory.Create(OperatorId.PostselectOn)).GetMatrix();
            var offMatrix = ((FixedMatrixOperatorModel) OperatorModelsFactory.Create(OperatorId.PostselectOff)).GetMatrix();
            var idMatrix = IdentityMatrix.Create(matrixWithoutControls.Rows);
            var identityPart = TensorMultiplier.Multiply(idMatrix, onMatrix);
            var operatorPart = TensorMultiplier.Multiply(matrixWithoutControls, offMatrix);
            Matrix<Complex> res = identityPart + operatorPart;
            return res;
        }
    }
}