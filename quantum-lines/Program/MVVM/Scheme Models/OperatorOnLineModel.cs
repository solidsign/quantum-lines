using System;
using System.Windows.Media.Imaging;

namespace quantum_lines.Program.Operators
{
    public class OperatorOnLineModel
    {
        public OperatorModel OperatorModel { get; private set; }
        public BitmapImage Image => OperatorModel.Image;
        public OperatorId OperatorId => OperatorModel.OperatorId;
        public event Action OperatorOnLineUpdated;

        public OperatorOnLineModel(OperatorId operatorId)
        {
            OperatorModel = OperatorModelsFactory.Create(operatorId);
        }
        
        public void UpdateModel(OperatorId newModel)
        {
            OperatorModel = OperatorModelsFactory.Create(newModel);
            OperatorOnLineUpdated?.Invoke();
        }
    }
}