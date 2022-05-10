using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using MatrixDotNet;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace quantum_lines.Program.Operators
{
    public class OperatorModel
    {
        private readonly Matrix<Complex> _matrix;
        private readonly BitmapImage _image;
        private readonly OperatorId _operatorId;
        
        public OperatorModel(OperatorId operatorId, Matrix<Complex> matrix, BitmapImage image)
        {
            _matrix = matrix;
            _image = image;
            _operatorId = operatorId;
        }

        public OperatorId OperatorId => _operatorId;
        public Matrix<Complex> Matrix => _matrix;
        public BitmapImage Image => _image;
    }
}