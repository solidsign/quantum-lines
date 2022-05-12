using System.Collections.Generic;
using System.Windows.Controls;

namespace quantum_lines
{
    public class QubitLineArguments
    {
        public readonly List<(OperatorId, Image)> OperatorsLineImages;
        public readonly QubitBasisState StartValue;
        public readonly Button StartValueButton;
        public readonly Label QubitResultLabel;

        public QubitLineArguments(Button startValueButton, QubitBasisState startValue, List<(OperatorId, Image)> operatorsLineImages, Label qubitResultLabel)
        {
            QubitResultLabel = qubitResultLabel;
            StartValueButton = startValueButton;
            StartValue = startValue;
            OperatorsLineImages = operatorsLineImages;
            
        }
    }
}