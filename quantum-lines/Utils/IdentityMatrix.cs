using System.Numerics;
using MatrixDotNet;

namespace quantum_lines.Utils
{
    public static class IdentityMatrix
    {
        public static Matrix<Complex> Create(int size)
        {
            var m = new Matrix<Complex>(size, size, Complex.Zero);
            for (int i = 0; i < size; i++)
            {
                m[i,i] = Complex.One;
            }

            return m;
        }
    }
}