using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Shapes;

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
    
    public class QubitLineComponents
    {
        public readonly StackPanel OperatorsLineImages;
        public readonly Button StartValueButton;
        public readonly Label QubitResultLabel;
        public readonly Line Line;
        public readonly Image ResultBackground;

        public QubitLineComponents(QubitLineArguments args, Line line, Image resultBackground, StackPanel operatorsLineImages)
        {
            QubitResultLabel = args.QubitResultLabel;
            StartValueButton = args.StartValueButton;
            OperatorsLineImages = operatorsLineImages;
            Line = line;
            ResultBackground = resultBackground;
        }
    }
    
    
}