using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace quantum_lines.Program.Operators
{
    public static class OperatorModelsFactory
    {
        public static OperatorModel Create(OperatorId operatorId)
        {
            switch (operatorId)
            {
                case OperatorId.Empty:
                    return new EmptyOperatorModel();
                case OperatorId.Hadamard:
                    return new FixedMatrixOperatorModel(operatorId, null, new BitmapImage(new Uri(@"\Picture\OperatorHadamar.png", UriKind.Relative)));
                case OperatorId.Not:
                    return new FixedMatrixOperatorModel(operatorId, null, new BitmapImage(new Uri(@"\Picture\OperatorNot.png", UriKind.Relative)));
                case OperatorId.QFT:
                    return new QFTOperatorModel(operatorId, null);
                default:
                    return new FixedMatrixOperatorModel(operatorId, null, null);
            }
        }
    }
}
