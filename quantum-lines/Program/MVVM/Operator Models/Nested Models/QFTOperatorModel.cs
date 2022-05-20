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

        // size - количество кубит
        // надо составить матрицу линейного оператора для size
        // как вариант можно взять формулу QFT|x> и подставлять в нее стандартный базис
        // т.е. подставлять в формулу вместо |x> |000....0000>, |000...00001>, |000...00010>, ..., |111..1111>
        // и составлять таким образом матрицу, записывая в каждый столбец то, что вышло из формулы для соответствующего набора кубитов
        public Matrix<Complex> CreateMatrix(int size)
        {
            int N = (int)Math.Pow(2, size);
            Matrix<Complex> matrix = new Matrix<Complex>(row: N, col: N, value: Complex.One);
            int degree = 1;
            for (int i = 1; i < N; i++)
            {
                for (int j = 1; j < N; j++)
                {
                    int multiplex = (degree * j) % 4;
                    switch (multiplex)
                    {
                        case 0:
                            matrix[i, j] = new Complex(1, 0);
                            continue;
                        case 1:
                            matrix[i, j] = new Complex(0, 1);
                            continue;
                        case 2:
                            matrix[i, j] = new Complex(-1, 0);
                            continue;
                        case 3:
                            matrix[i, j] = new Complex(0, -1);
                            continue;

                    }
                }
                degree++;
            }

            return matrix;
        }
    }
}