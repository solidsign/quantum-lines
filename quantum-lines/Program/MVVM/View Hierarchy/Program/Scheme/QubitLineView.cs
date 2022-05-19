using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using quantum_lines.Program;
using quantum_lines.Program.Operators;

namespace quantum_lines
{
    public class QubitLineView : IEquatable<QubitLineArguments>, IDisposable
    {
        private QubitInputView _startValue;
        private OperatorsLineView _operatorsLine;
        private QubitResultView _qubitResult;

        public QubitLineView(QubitLineArguments args, MenuSchemeConnector connector, Action<QubitResultModel> addResult, Action<QubitInputModel> addInput, Action<List<OperatorOnLineModel>> addLine, Action<QubitResultModel> removeResult, Action<QubitInputModel> removeInput, Action<List<OperatorOnLineModel>> removeLine)
        {
            _qubitResult = new QubitResultView(args.QubitResultLabel, addResult, removeResult);
            _startValue = new QubitInputView(args.StartValue, args.StartValueButton, addInput, removeInput);
            _operatorsLine = new OperatorsLineView(args.OperatorsLineImages, args.UpButtons, args.DownButtons, connector, addLine, removeLine);
        }

        public void InitAddButtons(QubitLineView? up, QubitLineView? down)
        {
            _operatorsLine.InitAddButtons(up?._operatorsLine, down?._operatorsLine);
        }

        public void ReinitBottomAddButtons(QubitLineView? down)
        {
            _operatorsLine.ReinitBottomAddButtons(down?._operatorsLine);
        }

        public bool Equals(QubitLineArguments? other)
        {
            if (other == null) throw new ArgumentException();
            return
                _qubitResult.Equals(other.QubitResultLabel) &&
                _startValue.Equals(other.StartValueButton) &&
                _operatorsLine.Equals(other.OperatorsLineImages.Select(x => x.Item2).ToList());
        }

        public void Dispose()
        {
            _startValue.Dispose();
            _operatorsLine.Dispose();
            _qubitResult.Dispose();
        }
    }
}