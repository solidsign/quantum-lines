using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using MatrixDotNet;

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
                    return new FixedMatrixOperatorModel(operatorId, new Matrix<Complex>(new Complex[2, 2] { { 1, 1 }, { 1, -1 } }), new BitmapImage(new Uri(@"\Picture\OperatorHadamar.png", UriKind.Relative)));   //( матрица ввида (1 1)\(1 -1)
                case OperatorId.Not:
                    return new FixedMatrixOperatorModel(operatorId, new Matrix<Complex>(new Complex[2, 2] { {0, 1}, {1, 0} }), new BitmapImage(new Uri(@"\Picture\OperatorNot.png", UriKind.Relative))); //(матрица ввида(0, 1)/(1, 0)
                case OperatorId.QFT:
                    return new QFTOperatorModel(null); // TODO
                case OperatorId.Control:
                    return new ControlOperatorModel(null); // TODO
                case OperatorId.AntiControl:
                    return new AntiControlOperatorModel(null); // TODO
                default:
                    return new EmptyOperatorModel();
            }
        }
    }
}
