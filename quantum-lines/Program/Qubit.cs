using System;
using System.Numerics;
using MatrixDotNet;

namespace quantum_lines
{
    public struct Qubit
    {
        public Matrix<Complex> State;

        public Qubit(Matrix<Complex> state)
        {
            State = state;
        }
        
        public Qubit(QubitBasisState basisState)
        {
            State = new Matrix<Complex>(2, 1, Complex.Zero);
            switch (basisState)
            {
                case QubitBasisState.Zero:
                    State[0,0] = Complex.One;
                    break;
                case QubitBasisState.One:
                    State[1,0] = Complex.One;
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
    }
}