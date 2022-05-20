using System.Numerics;
using System.Windows.Media.Imaging;
using MatrixDotNet;

namespace quantum_lines.Program.Operators
{
    public abstract class SizeDependentOperatorModel : OperatorModel
    {
        /// <summary>
        /// номер в законнекченной последовательности, индексация с 1
        /// </summary>
        protected int _index;

        public int Index => _index;
        protected SizeDependentOperatorModel(OperatorId id, BitmapImage image, int index) : base(id, OperatorClass.SizeDependentMatrix, image)
        {
            _index = index;
        }

        public abstract Matrix<Complex> GetMatrix(int size);
    }
}