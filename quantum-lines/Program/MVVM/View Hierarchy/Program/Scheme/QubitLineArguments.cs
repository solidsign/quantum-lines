using System.Collections.Generic;
using System.Windows.Controls;

namespace quantum_lines
{
    public class QubitLineArguments
    {
        public readonly Dictionary<OperatorId, Image> OperatorsLineImages;
        public readonly QubitBasisState StartValue;
        public readonly Button StartValueButton;

        public QubitLineArguments(Button startValueButton, QubitBasisState startValue, Dictionary<OperatorId, Image> operatorsLineImages)
        {
            StartValueButton = startValueButton;
            StartValue = startValue;
            OperatorsLineImages = operatorsLineImages;
        }
    }
}