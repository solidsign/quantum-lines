using System.Numerics;
using System.Windows.Media.Imaging;
using MatrixDotNet;

namespace quantum_lines.Program.Operators
{
    public class QFTOperatorModel : SizeDependentOperatorModel
    {
        public QFTOperatorModel(BitmapImage image, int index) : base(OperatorId.QFT, image, index)
        {
        }
    }
}