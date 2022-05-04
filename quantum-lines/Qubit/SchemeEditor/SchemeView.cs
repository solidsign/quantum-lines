using System;
using System.Collections.Generic;

namespace quantum_lines.Operators
{
    public class SchemeView
    {
        private List<OperatorsLine> _lines;

        private event Action<List<OperatorsLine>> _onLinesUpdate;
        
        public SchemeView(SchemeViewModel viewModel, List<OperatorsLine> startLines)
        {
            _lines = startLines;
            _onLinesUpdate += viewModel.OnOperatorLinesChanged;
        }
    }
}