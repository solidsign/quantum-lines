using System;
using System.Numerics;
using MatrixDotNet;
using MatrixDotNet.Extensions.Conversion;

namespace quantum_lines.Utils
{
    public static class ScalarMultiplier
    {
        public static Complex ComplexMultiply(Matrix<Complex> left, Matrix<Complex> right)
        {
            right = right.Transpose();
            right = ConjugateMatrix(right);
            var res = left * right;
            if (res.Length != 1) throw new Exception("ComplexScalarMultiply wrong vectors");
            return res[0,0];
        }

        private static Matrix<Complex> ConjugateMatrix(Matrix<Complex> matrix)
        {
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    matrix[i, j] = Complex.Conjugate(matrix[i, j]);
                }
            }

            return matrix;
        }
    }
}