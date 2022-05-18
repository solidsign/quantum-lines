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
        public readonly List<Button> UpButtons; 
        public readonly List<Button> DownButtons; 

        public QubitLineArguments(Button startValueButton, QubitBasisState startValue, List<(OperatorId, Image)> operatorsLineImages, List<Button> upButtons, List<Button> downButtons, Label qubitResultLabel)
        {
            QubitResultLabel = qubitResultLabel;
            StartValueButton = startValueButton;
            StartValue = startValue;
            OperatorsLineImages = operatorsLineImages;
            UpButtons = upButtons;
            DownButtons = downButtons;
        }
    }
    
    public class QubitLineGridComponents
    {
        public readonly StackPanel OperatorsLineImages;
        public readonly Button StartValueButton;
        public readonly Label QubitResultLabel;
        public readonly Line Line;
        public readonly Image ResultBackground;

        public QubitLineGridComponents(QubitLineArguments args, Line line, Image resultBackground, StackPanel operatorsLineImages)
        {
            QubitResultLabel = args.QubitResultLabel;
            StartValueButton = args.StartValueButton;
            OperatorsLineImages = operatorsLineImages;
            Line = line;
            ResultBackground = resultBackground;
        }
    }
    
    
}