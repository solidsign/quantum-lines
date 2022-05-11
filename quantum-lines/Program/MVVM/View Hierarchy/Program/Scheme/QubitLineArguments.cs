using System.Collections.Generic;
using System.Windows.Controls;

namespace quantum_lines
{
    public class QubitLineArguments
    {
        public readonly Dictionary<OperatorId, Button> OperatorsLineButtons;
        public readonly QubitBasisState StartValue;
        public readonly Button StartValueButton;

        public QubitLineArguments(Button startValueButton, QubitBasisState startValue, Dictionary<OperatorId, Button> operatorsLineButtons)
        {
            StartValueButton = startValueButton;
            StartValue = startValue;
            OperatorsLineButtons = operatorsLineButtons;
        }
    }
}