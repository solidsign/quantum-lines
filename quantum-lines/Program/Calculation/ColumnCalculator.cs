using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
                var controllerIndex = _operators.FindIndex(x => x.OperatorClass == OperatorClass.Controller);
                CalculateWithController(controllerIndex);
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

            var leftPart = _operators.TakeWhile(x => x.OperatorClass != OperatorClass.Controller).ToList();
            var rightPart = _operators
                .SkipWhile(x => x.OperatorClass != OperatorClass.Controller)
                .Where(x => x.OperatorClass != OperatorClass.Controller)
                .ToList();

            var leftPartMatrix = GetOperatorsMatrix(leftPart);
            var rightPartMatrix = GetOperatorsMatrix(rightPart);
            
            var controlledMatrix = controllerOp.ControlMatrix(leftPartMatrix, rightPartMatrix);
            var result = MatrixOperations.Multiply(controlledMatrix, _inValues);
            if (result == null) throw new ArithmeticException("CalculateWithOutController result is null");
            _inValues = new Matrix<Complex>(result);
        }

        private void CalculateWithOutController()
        {
            var matrix = GetOperatorsMatrix(_operators);

            var result = MatrixOperations.Multiply(matrix, _inValues);
            if (result == null) throw new ArithmeticException("CalculateWithOutController result is null");
            _inValues = new Matrix<Complex>(result);
        }

        private Matrix<Complex> GetOperatorsMatrix(List<OperatorModel> operators)
        {
            Matrix<Complex> res = new Matrix<Complex>(new Complex[1,1]{{1}});

            for (var i = 0; i < operators.Count; i++)
            {
                switch (operators[i].OperatorClass)
                {
                    case OperatorClass.FixedMatrix:
                        res = TensorMultiplier.Multiply(res, GetFixedMatrix(operators[i]));
                        break;
                    case OperatorClass.SizeDependentMatrix:
                        int size = 0;
                        var op = operators[i];

                        do
                        {
                            size++;
                            i++;
                        } while (i < operators.Count &&
                                 operators[i].OperatorClass == OperatorClass.SizeDependentMatrix &&
                                 ((SizeDependentOperatorModel) operators[i]).Index != 1);
                        
                        res = TensorMultiplier.Multiply(res, GetSizedMatrix(size, op));
                        i--;
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