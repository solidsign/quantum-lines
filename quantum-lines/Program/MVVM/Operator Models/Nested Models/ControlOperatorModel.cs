using System.Numerics;
using System.Windows.Media.Imaging;
using MatrixDotNet;
using quantum_lines.Utils;

namespace quantum_lines.Program.Operators
{
    public class ControlOperatorModel : ControllerOperatorModelBase
    {
        public ControlOperatorModel(BitmapImage image) : base(OperatorId.Control, image)
        {
        }

        public override Matrix<Complex> ControlMatrix(Matrix<Complex> matrixWithoutControls)
        {
            var onMatrix = ((FixedMatrixOperatorModel) OperatorModelsFactory.Create(OperatorId.PostselectOn)).GetMatrix();
            var offMatrix = ((FixedMatrixOperatorModel) OperatorModelsFactory.Create(OperatorId.PostselectOff)).GetMatrix();
            var idMatrix = IdentityMatrix.Create(matrixWithoutControls.Rows);
            var identityPart = TensorMultiplier.Multiply(idMatrix, offMatrix);
            var operatorPart = TensorMultiplier.Multiply(matrixWithoutControls, onMatrix);
            Matrix<Complex> res = identityPart + operatorPart;
            return res;
        }
    }
}