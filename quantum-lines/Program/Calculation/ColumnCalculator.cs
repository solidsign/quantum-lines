using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Windows.Media;
using MatrixDotNet;
using quantum_lines.Program.Operators;
using quantum_lines.Utils;

namespace quantum_lines.Program.Calculation
{
    public class ColumnCalculator
    {
        private Matrix<Complex> _inValues;
        private List<OperatorModel> _operators;

        public ColumnCalculator(Matrix<Complex> inValues, List<OperatorOnLineModel> operators)
        {
            _inValues = inValues;
            _operators = operators.Select(x => x.OperatorModel).ToList();
        }

        public Matrix<Complex> Calculate()
        {
            if (_operators.Any(x => x.OperatorClass == OperatorClass.Controller))
            {
                CalculateWithController(_operators.FindIndex(x => x.OperatorClass == OperatorClass.Controller));
            }
            else
            {
                CalculateWithOutController();
            }

            return _inValues;
        }

        private void CalculateWithController(int controllerIndex)
        {
            var controllerOp = _operators[controllerIndex] as ControllerOperatorModelBase ?? throw new InvalidOperationException("CalculateWithController:  Controller operator found wrong");

            var leftPart = GetOperatorsMatrix(
                _operators.TakeWhile(x => x.OperatorClass != OperatorClass.Controller).ToList());
            var rightPart = GetOperatorsMatrix(
                _operators
                    .SkipWhile(x => x.OperatorClass != OperatorClass.Controller)
                    .Where(x => x.OperatorClass != OperatorClass.Controller)
                    .ToList());
            
            
            var controlledMatrix = controllerOp.ControlMatrix(leftPart, rightPart);
            _inValues = MatrixOperations.Multiply(controlledMatrix, _inValues);
            if (_inValues == null) throw new ArithmeticException("CalculateWithOutController result is null");
        }

        private void CalculateWithOutController()
        {
            var matrix = GetOperatorsMatrix(_operators);
            _inValues = MatrixOperations.Multiply(matrix, _inValues);
            if (_inValues == null) throw new ArithmeticException("CalculateWithOutController result is null");
        }

        private Matrix<Complex>? GetOperatorsMatrix(List<OperatorModel> operators)
        {
            if (operators.Count == 0) return null;
            
            Matrix<Complex> res = new Matrix<Complex>(new Complex[1,1]{{1}});

            for (var i = 0; i < operators.Count; i++)
            {
                switch (operators[i].OperatorClass)
                {
                    case OperatorClass.FixedMatrix:
                        res = TensorMultiplier.Multiply(res, GetFixedMatrix(operators[i]));
                        break;
                    case OperatorClass.SizeDependentMatrix:
                        int size = 1;
                        var op = operators[i];
                        i++;
                        while (i < operators.Count && operators[i].OperatorClass == OperatorClass.SizeDependentMatrix &&
                               ((SizeDependentOperatorModel) operators[i]).Index != 1)
                        {
                            size++;
                            i++;
                        }
                        res = TensorMultiplier.Multiply(res, GetSizedMatrix(size, op));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return res;
        }

        private Matrix<Complex> GetFixedMatrix(OperatorModel model)
        {
            return ((FixedMatrixOperatorModel) model).GetMatrix();
        }

        private Matrix<Complex> GetSizedMatrix(int size, OperatorModel model)
        {
            return ((SizeDependentOperatorModel) model).GetMatrix(size);
        }
    }
}