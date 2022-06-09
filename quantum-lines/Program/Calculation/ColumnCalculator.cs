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
                CalculateWithController();
            }
            else
            {
                CalculateWithOutController();
            }

            return _inValues;
        }

        private void CalculateWithController()
        {
            var controlsIndexes
                = _operators.FindAll(x => x.OperatorClass == OperatorClass.Controller)
                .Select(x => _operators.IndexOf(x)).OrderBy(x => x).ToList();

            var controlsAmount = controlsIndexes.Count;
            var additionsAmount = 1 << controlsAmount;

            var res = new Matrix<Complex>(1 << _operators.Count,1 << _operators.Count, 0);

            for (int variant = 0; variant < additionsAmount - 1; variant++)
            {
                List<Matrix<Complex>> temp = new List<Matrix<Complex>>();
                for (var i = 0; i < _operators.Count; i++)
                {
                    if (controlsIndexes.Contains(i))
                    {
                        var controllerIndex = controlsIndexes.IndexOf(i);

                        if ((variant >> controllerIndex) % 2 == 0)
                        {
                            temp.Add(GetIdentityPartControllerMatrix(i));
                        }
                        else
                        {
                            temp.Add(GetActionPartControllerMatrix(i));
                        }

                        continue;
                    }
                    temp.Add(IdentityMatrix.Create(2));
                }
                
                res = MatrixOperations.Add(res, TensorMultiplier.Multiply(temp.ToArray()));
            }

            List<Matrix<Complex>> list = new List<Matrix<Complex>>();
            for (var i = 0; i < _operators.Count; i++)
            {
                if (_operators[i].OperatorClass == OperatorClass.Controller)
                {
                    list.Add(GetActionPartControllerMatrix(i));
                    continue;
                }
                switch (_operators[i].OperatorClass)
                {
                    case OperatorClass.FixedMatrix:
                        list.Add(GetFixedMatrix(_operators[i]));
                        break;
                    case OperatorClass.SizeDependentMatrix:
                        int size = 0;
                        var op = _operators[i];
                        do
                        {
                            size++;
                            i++;
                        } while (i < _operators.Count &&
                                 _operators[i].OperatorClass == OperatorClass.SizeDependentMatrix &&
                                 ((SizeDependentOperatorModel) _operators[i]).Index != 1);
                        list.Add(GetSizedMatrix(size, op));
                        i--;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            res = MatrixOperations.Add(res, TensorMultiplier.Multiply(list.ToArray()));
            
            var result = MatrixOperations.Multiply(res, _inValues);
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

        private Matrix<Complex> GetIdentityPartControllerMatrix(int index)
        {
            if(_operators[index] is ControllerOperatorModelBase controllerModel)
            {
                return controllerModel.GetIdentityPostselect();
            }

            throw new ArgumentException();
        }
        private Matrix<Complex> GetActionPartControllerMatrix(int index)
        {
            if(_operators[index] is ControllerOperatorModelBase controllerModel)
            {
                return controllerModel.GetActionPostselect();
            }

            throw new ArgumentException();
        }
    }
}