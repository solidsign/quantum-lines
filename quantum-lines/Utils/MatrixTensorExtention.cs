using System.Numerics;
using MatrixDotNet;

namespace quantum_lines.Utils
{
    public static class TensorMultiplier
    {
        public static Matrix<Complex> Multiply(params Matrix<Complex>[] matrices)
        {
            var res = matrices[0];
            for (int i = 1; i < matrices.Length; i++)
            {
                res = Multiply(res, matrices[i]);
            }

            return res;
        }

        private static Matrix<Complex> Multiply(Matrix<Complex> a, Matrix<Complex> b)
        {
            var matrix = new Matrix<Complex>(a.Rows * b.Rows, a.Columns * b.Columns);
            
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Columns; j++)
                {
                    for (int k = 0; k < b.Rows; k++)
                    {
                        for (int l = 0; l < b.Columns; l++)
                        {
                            matrix[i * b.Rows + k, j * b.Columns + l] = a[i, j] * b[k, l];
                        }
                    }
                }
            }

            return matrix;
        }
    }
}