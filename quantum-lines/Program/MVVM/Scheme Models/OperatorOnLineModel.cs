using System;
using System.Windows.Media.Imaging;

namespace quantum_lines.Program.Operators
{
    public class OperatorOnLineModel : IDisposable
    {
        public OperatorModel OperatorModel { get; private set; }
        public BitmapImage Image => OperatorModel.Image;
        public OperatorId OperatorId => OperatorModel.OperatorId;
        public OperatorClass OperatorClass => OperatorModel.OperatorClass;

        public int? SizeDependentIndex { get; private set; }

        public event Action? OperatorOnLineUpdated;

        public Func<OperatorModel, OperatorOnLineModel, bool>? ValidateModelUpdate;

        public OperatorOnLineModel(OperatorId operatorId)
        {
            OperatorModel = OperatorModelsFactory.Create(operatorId);
            if (OperatorClass == OperatorClass.SizeDependentMatrix)
            {
                SizeDependentIndex = 1;
            }
            else
            {
                SizeDependentIndex = null;
            }
        }
        
        public void UpdateModel(OperatorId newModelId)
        {
            var newModel = OperatorModelsFactory.Create(newModelId);
            if (newModel.OperatorClass == OperatorClass.SizeDependentMatrix)
            {
                SizeDependentIndex = null;
            }
            if (ValidateModelUpdate != null && !ValidateModelUpdate(newModel, this))
            {
                // TODO: когда будут кнопки контроллеров - проверить, что ограничение на количество контроллеров отрабатывает корректно
                // TODO: вывести сообщение об ошибке
                return;
            }

            OperatorModel = newModel;
            OperatorOnLineUpdated?.Invoke();
        }
        
        /// <summary>
        /// for size dependent operators
        /// </summary>
        /// <param name="newModelId"></param>
        /// <param name="index"></param>
        public void UpdateModel(OperatorId newModelId, int index)
        {
            var newModel = OperatorModelsFactory.Create(newModelId, index);
            
            if (newModel.OperatorClass != OperatorClass.SizeDependentMatrix) throw new ArgumentException();

            SizeDependentIndex = index;
            OperatorModel = newModel;
            OperatorOnLineUpdated?.Invoke();
        }

        public void Dispose()
        {
            OperatorOnLineUpdated = null;
        }

        public void UpdateSizeDependentIndex(int? index)
        {
            SizeDependentIndex = index;
        }
    }
}