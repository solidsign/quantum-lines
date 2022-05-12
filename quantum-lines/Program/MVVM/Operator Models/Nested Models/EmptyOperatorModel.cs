using quantum_lines.Program.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using MatrixDotNet;

namespace quantum_lines.Program.Operators
{

    public class EmptyOperatorModel : FixedMatrixOperatorModel
    {
        public EmptyOperatorModel() : base(OperatorId.Empty, new Matrix<Complex>(new Complex[2, 2] { {1,0}, {0,1} }), new BitmapImage(new Uri(@"\Picture\clearOperatorOnLine.png", UriKind.Relative)))
        {

        }
    }
}
