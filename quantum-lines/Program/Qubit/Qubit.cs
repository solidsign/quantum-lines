using System;
using System.Numerics;
using MatrixDotNet;

namespace quantum_lines
{
    public struct Qubit
    {
        public Matrix<Complex> StateMatrix;
        
        /// <summary>
        /// Коэф при |0>
        /// </summary>
        public Complex Alpha => StateMatrix[0, 0];
        
        /// <summary>
        /// Коэф при |1>
        /// </summary>
        public Complex Beta => StateMatrix[1, 0];

        public Qubit(Matrix<Complex> stateMatrix)
        {
            StateMatrix = stateMatrix;
        }

        public Qubit(Complex alpha, Complex beta)
        {
            StateMatrix = new Matrix<Complex>(new Complex[2,1]{{alpha},{beta}});
        }
        
        public Qubit(double alpha, double beta)
        {
            StateMatrix = new Matrix<Complex>(new Complex[2,1]{{alpha},{beta}});
        }
        
        public Qubit(QubitBasisState basisState)
        {
            StateMatrix = new Matrix<Complex>(2, 1, Complex.Zero);
            switch (basisState)
            {
                case QubitBasisState.Zero:
                    StateMatrix[0,0] = Complex.One;
                    break;
                case QubitBasisState.One:
                    StateMatrix[1,0] = Complex.One;
                    break;
                case QubitBasisState.Plus:
                    throw new NotImplementedException();
                case QubitBasisState.Minus:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentOutOfRangeException(nameof(basisState), basisState, null);
            }
        }

        public static string BasisStateToString(QubitBasisState startValue)
        {
            switch (startValue)
            {
                case QubitBasisState.Zero:
                    return "|0>";
                case QubitBasisState.One:
                    return "|1>";
                case QubitBasisState.Plus:
                    return "|+>";
                case QubitBasisState.Minus:
                    return "|+>";
                default:
                    throw new ArgumentOutOfRangeException(nameof(startValue), startValue, null);
            }
        }

        public Possibility ONPossitility => new Possibility(Alpha.Magnitude * Alpha.Magnitude);
        public Possibility OFFPossitility => new Possibility(Beta.Magnitude * Beta.Magnitude);
    }
}