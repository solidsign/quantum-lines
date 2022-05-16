namespace quantum_lines.Program.Operators
{
    public class OperatorMenuItemViewModel
    {
        private OperatorModel _model;
        
        public OperatorMenuItemViewModel(OperatorId id)
        {
            _model = OperatorModelsFactory.Create(id);
        }

        public OperatorId OperatorId => _model.OperatorId;
    }
}