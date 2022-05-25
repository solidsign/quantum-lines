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
                    return new FixedMatrixOperatorModel(operatorId,
                        new Matrix<Complex>(new Complex[2, 2] {{0.7071, 0.7071}, {0.7071, -0.7071}}),
                        new BitmapImage(new Uri(@"\Picture\OperatorHadamar.png", UriKind.Relative)));   //( матрица ввида (1 1)\(1 -1)
                case OperatorId.Not:
                    return new FixedMatrixOperatorModel(operatorId,
                        new Matrix<Complex>(new Complex[2, 2] {{0, 1}, {1, 0}}),
                        new BitmapImage(new Uri(@"\Picture\PaulXOperatorOnLine.png", UriKind.Relative))); //(матрица ввида(0, 1)/(1, 0)
                case OperatorId.QFT:
                    return new QFTOperatorModel(new BitmapImage(new Uri(@"\Picture\QFTOperatorFirst.png", UriKind.Relative)), 1); 
                case OperatorId.Control:
                    return new ControlOperatorModel(new BitmapImage(new Uri(@"\Picture\ControlOperator.png", UriKind.Relative))); 
                case OperatorId.AntiControl:
                    return new AntiControlOperatorModel(new BitmapImage(new Uri(@"\Picture\AntiControlOperator.png", UriKind.Relative))); 
                case OperatorId.PaulY:
                    return new FixedMatrixOperatorModel(operatorId,
                        new Matrix<Complex>(new Complex[2, 2] {{0, new Complex(0, -1)}, { new Complex(0, 1), 0 }}),
                        new BitmapImage(new Uri(@"\Picture\PaulYOperatorOnLine.png", UriKind.Relative))); // (0, -i)/(i 0)
                case OperatorId.PaulZ:
                    return new FixedMatrixOperatorModel(operatorId,
                        new Matrix<Complex>(new Complex[2, 2] { {1, 0}, {0, -1} }),
                        new BitmapImage(new Uri(@"\Picture\PaulZOperatorOnLine.png", UriKind.Relative))); // (1, 0) / (0, -1) 
                case OperatorId.PhaseS:
                    return new FixedMatrixOperatorModel(operatorId,
                         new Matrix<Complex>(new Complex[2, 2] { {1, 0}, {0, new Complex(0, 1)} }),
                        new BitmapImage(new Uri(@"\Picture\PhaseSOperatorOnLine.png", UriKind.Relative))); // (1, 0) / (0, i) 
                case OperatorId.ElemP8:
                    return new FixedMatrixOperatorModel(operatorId,
                        new Complex[2, 2] {{1, 0}, {0, new Complex(0.7071, 0.7071)}},
                        new BitmapImage(new Uri(@"\Picture\PI8Operator.png", UriKind.Relative))); // (1, 0) / (0, e^(i*pi/4)) 
                case OperatorId.PostselectOff:
                    return new FixedMatrixOperatorModel(operatorId,
                        new Matrix<Complex>(new Complex[2, 2] {{1, 0}, {0, 0}}),
                         new BitmapImage(new Uri(@"\Picture\PostSelectOFFOperator.png", UriKind.Relative))); 
                case OperatorId.PostselectOn:
                    return new FixedMatrixOperatorModel(operatorId,
                        new Matrix<Complex>(new Complex[2, 2] {{0, 0}, {0, 1}}),
                         new BitmapImage(new Uri(@"\Picture\PostSelectONOperator.png", UriKind.Relative))); 
                default:
                    return new EmptyOperatorModel();
            }
        }

        public static SizeDependentOperatorModel Create(OperatorId id, int index)
        {
            switch (id)
            {
                case OperatorId.QFT:
                    return new QFTOperatorModel(new BitmapImage( new Uri(index == 1 ? @"\Picture\QFTOperatorFirst.png" : @"\Picture\QFTOperator.png", UriKind.Relative)), index);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
