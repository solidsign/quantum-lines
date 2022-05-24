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

        public override Matrix<Complex> ControlMatrix(Matrix<Complex> leftPart, Matrix<Complex> rightPart)
        {
            var onMatrix = ((FixedMatrixOperatorModel) OperatorModelsFactory.Create(OperatorId.PostselectOn)).GetMatrix();
            var offMatrix = ((FixedMatrixOperatorModel) OperatorModelsFactory.Create(OperatorId.PostselectOff)).GetMatrix();
            var leftIdMatrix = IdentityMatrix.Create(leftPart.Rows);
            var rightIdMatrix = IdentityMatrix.Create(rightPart.Rows);
            var identityPart = TensorMultiplier.Multiply(leftIdMatrix, offMatrix, rightIdMatrix);
            var operatorPart = TensorMultiplier.Multiply(leftPart, onMatrix, rightPart);
            Matrix<Complex> res = MatrixOperations.Add(identityPart, operatorPart);
            return res;
        }
    }
}