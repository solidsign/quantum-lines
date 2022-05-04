using System.Collections.Generic;
using MatrixDotNet;
using quantum_lines.Utils;

namespace quantum_lines.Operators
{
    public class SchemeModel
    {
        private Matrix<float> _matrix;

        public SchemeModel(Matrix<float> matrix)
        {
            _matrix = matrix;
        }
        
        public void Update(List<OperatorsLine> lines)
        {
            _matrix = Converter.LinesToMatrix(lines);
        }
    }
}