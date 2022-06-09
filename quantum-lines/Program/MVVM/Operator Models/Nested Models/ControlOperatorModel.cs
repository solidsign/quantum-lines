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
        
        public override Matrix<Complex> GetIdentityPostselect()
        {
            return ((FixedMatrixOperatorModel) OperatorModelsFactory.Create(OperatorId.PostselectOff)).GetMatrix();
        }

        public override Matrix<Complex> GetActionPostselect()
        {
            return ((FixedMatrixOperatorModel) OperatorModelsFactory.Create(OperatorId.PostselectOn)).GetMatrix();
        }
    }
}