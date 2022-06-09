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
        
        public override Matrix<Complex> GetIdentityPostselect()
        {
            return ((FixedMatrixOperatorModel) OperatorModelsFactory.Create(OperatorId.PostselectOn)).GetMatrix();
        }

        public override Matrix<Complex> GetActionPostselect()
        {
            return ((FixedMatrixOperatorModel) OperatorModelsFactory.Create(OperatorId.PostselectOff)).GetMatrix();
        }
    }
}