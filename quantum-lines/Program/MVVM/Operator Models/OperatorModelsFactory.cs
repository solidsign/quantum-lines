﻿using System;
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
                    return new QFTOperatorModel(operatorId, null);
                case OperatorId.PaulX:
                // return new(operatorId, new Matrix<Complex>(new Complex[2, 2] { { 0, 1 }, { 1, 0 } }), new BitmapImage(new Uri(@"Picture\PaulXOperatorOnLine.png", UriKind.Relative)));           // матрица вида (0, 1)/ (1, 0)
                case OperatorId.PaulY:
                // return new(operatorId, new Matrix<Complex>(new Complex[2, 2] { { 0, 1 }, { 1, 0 } }), new BitmapImage(new Uri(@"Picture\PaulYOperatorOnLine.png", UriKind.Relative)));           // (0, -i)/(i 0)
                case OperatorId.PaulZ:
                // return new(operatorId, new Matrix<Complex>(new Complex[2, 2] { { 0, 1 }, { 1, 0 } }), new BitmapImage(new Uri(@"Picture\PaulZOperatorOnLine.png", UriKind.Relative)));           // (1, 0) / (0, -1)
                case OperatorId.PhaseS:
                //  return new(operatorId, new Matrix<Complex>(new Complex[2, 2] { { 0, 1 }, { 1, 0 } }), new BitmapImage(new Uri(@"Picture\PhaseSOperatorOnLine.png", UriKind.Relative)));         // (1, 0) / (0, -i)
                case OperatorId.ElemP8:
                    //  return new(operatorId, new Matrix<Complex>(new Complex[2, 2] { { 0, 1 }, { 1, 0 } }), new BitmapImage(new Uri(@"Picture\PaulXOperatorOnLine.png", UriKind.Relative)));      // (1, 0) / (0, e^(i*pi/4))
                default:
                    return new FixedMatrixOperatorModel(operatorId, null, null);
            }
        }
    }
}
