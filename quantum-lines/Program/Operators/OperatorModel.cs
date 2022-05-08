using System;
using System.Collections.Generic;
using System.Linq;
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
        private Matrix<float> _matrix;
        private OperatorClass _operatorClass;
        private BitmapImage _image;
        private OperatorId _operatorId;
        
        public OperatorModel(OperatorId operatorId, Matrix<float> matrix, OperatorClass operatorClass, BitmapImage image)
        {
            _matrix = matrix;
            _operatorClass = operatorClass;
            _image = image;
            _operatorId = operatorId;
        }
    }
}