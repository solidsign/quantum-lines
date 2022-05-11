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
    public abstract class OperatorModel
    {
        protected readonly BitmapImage _image;
        protected readonly OperatorId _operatorId;
        protected readonly OperatorClass _operatorClass;
        
        protected OperatorModel(OperatorId operatorId, OperatorClass operatorClass, BitmapImage image)
        {
            _image = image;
            _operatorId = operatorId;
            _operatorClass = operatorClass;
        }

        public OperatorClass OperatorClass => _operatorClass;
        public OperatorId OperatorId => _operatorId;
        public BitmapImage Image => _image;
    }
}