using System;
using System.Windows.Media.Imaging;

namespace quantum_lines.Program.Operators
{
    public class OperatorOnLineModel : IDisposable
    {
        public OperatorModel OperatorModel { get; private set; }
        public BitmapImage Image => OperatorModel.Image;
        public OperatorId OperatorId => OperatorModel.OperatorId;
        public event Action? OperatorOnLineUpdated;

        public Func<OperatorModel, OperatorOnLineModel, bool>? ValidateModelUpdate;

        public OperatorOnLineModel(OperatorId operatorId)
        {
            OperatorModel = OperatorModelsFactory.Create(operatorId);
        }
        
        public void UpdateModel(OperatorId newModelId)
        {
            var newModel = OperatorModelsFactory.Create(newModelId);
            if (ValidateModelUpdate != null && !ValidateModelUpdate(newModel, this))
            {
                // TODO: когда будут кнопки контроллеров - проверить, что ограничение на количество контроллеров отрабатывает корректно
                // TODO: вывести сообщение об ошибке
                return;
            }

            OperatorModel = newModel;
            OperatorOnLineUpdated?.Invoke();
        }

        public void Dispose()
        {
            OperatorOnLineUpdated = null;
        }
    }
}