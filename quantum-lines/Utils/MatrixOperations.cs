using System;
using System.Numerics;
using MatrixDotNet;

namespace quantum_lines.Utils
{
    public static class MatrixOperations
    {
        public static Complex[,]? Multiply(Matrix<Complex> left, Matrix<Complex> right)
        {
            if (left.Columns != right.Rows) return null;
            Complex [,] resultArr = new Complex[left.Rows, right.Columns]; 
            var resultMatrix = new Matrix<Complex>(left.Rows, right.Columns);
            for (int i = 0; i < resultMatrix.Rows; i++)
            {
                for (int j = 0; j < resultMatrix.Columns; j++)
                {
                    for (int counter = 0; counter < left.Columns; counter++)
                    {
                        resultArr[i, j] += Complex.Multiply(left[i, counter], right[counter, j]);
                    }
                }
            }
            return resultArr;
        }
        
        public static Matrix<Complex> Multiply(Complex left, Matrix<Complex> right)
        {
            for (int i = 0; i < right.Rows; i++)
            {
                for (int j = 0; j < right.Columns; j++)
                {
                    right[i, j] = Complex.Multiply(left, right[i, j]);
                }
            }
            return right;
        }
        
        public static Matrix<Complex> Add(Matrix<Complex> left, Matrix<Complex> right)
        {
            var resultMatrix = new Matrix<Complex>(left.Rows, right.Columns);
            for (int i = 0; i < right.Rows; i++)
            {
                for (int j = 0; j < right.Columns; j++)
                {
                    resultMatrix[i, j] = Complex.Add(left[i, j], right[i, j]);
                }
            }
            return resultMatrix;
        }
        
        public static Matrix<Complex> Subtract(Matrix<Complex> left, Matrix<Complex> right)
        {
            var resultMatrix = new Matrix<Complex>(left.Rows, right.Columns);
            for (int i = 0; i < right.Rows; i++)
            {
                for (int j = 0; j < right.Columns; j++)
                {
                    resultMatrix[i, j] = Complex.Subtract(left[i, j], right[i, j]);
                }
            }
            return resultMatrix;
        }
    }
}