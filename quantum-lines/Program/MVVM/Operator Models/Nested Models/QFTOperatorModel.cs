using System;
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
        public override Matrix<Complex> GetMatrix(int size)
        {
            int N = 1 << size;
            double coef = 1.0 / Math.Sqrt((double) N);
            Matrix<Complex> matrix = new Matrix<Complex>(row: N, col: N, value: Complex.One);
            for (int i = 1; i < N; i++)
            {
                for (int j = 1; j < N; j++)
                {
                    double multiplex = (i * j);
                    matrix[i, j] = new Complex(Math.Cos(2.0 * Math.PI * multiplex / (double) N), Math.Sin(2.0 * Math.PI * multiplex / (double) N));
                }
            }

            matrix *= coef;
            return matrix;
        }
    }
}