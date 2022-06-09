using System.Numerics;
using System.Windows.Media.Imaging;
using MatrixDotNet;

namespace quantum_lines.Program.Operators
{
    public abstract class ControllerOperatorModelBase : OperatorModel
    {
        protected ControllerOperatorModelBase(OperatorId operatorId, BitmapImage image) : base(operatorId, OperatorClass.Controller, image)
        {
        }

        public abstract Matrix<Complex> GetIdentityPostselect();
        public abstract Matrix<Complex> GetActionPostselect();
    }
}