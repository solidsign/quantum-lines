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

        public override Matrix<Complex> ControlMatrix(Matrix<Complex>? leftPart, Matrix<Complex>? rightPart)
        {
            var onMatrix = ((FixedMatrixOperatorModel) OperatorModelsFactory.Create(OperatorId.PostselectOn)).GetMatrix();
            var offMatrix = ((FixedMatrixOperatorModel) OperatorModelsFactory.Create(OperatorId.PostselectOff)).GetMatrix();
            if (leftPart == null) leftPart = new Matrix<Complex>(new Complex[1, 1] {{1}});
            if (rightPart == null) rightPart = new Matrix<Complex>(new Complex[1, 1] {{1}});
            var leftIdMatrix = IdentityMatrix.Create(leftPart.Rows);
            var rightIdMatrix = IdentityMatrix.Create(rightPart.Rows);
            var identityPart = TensorMultiplier.Multiply(leftIdMatrix, onMatrix, rightIdMatrix);
            var operatorPart = TensorMultiplier.Multiply(leftPart, offMatrix, rightPart);
            Matrix<Complex> res = identityPart + operatorPart;
            return res;
        }
    }
}