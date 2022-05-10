using System;
using quantum_lines.Program.Operators;

namespace quantum_lines.Program
{


    public class MenuSchemeConnector
    {
        private OperatorId _operatorId = OperatorId.Undefined;
        private OperatorModel _model = null;
        public event Action<OperatorId, OperatorId> OnSet;
        public delegate bool AnyCheckedDel();
        private AnyCheckedDel _anyChecked;
        public void SetCurrentOperator(OperatorModel model)
        {
            if (model == null)
            {
                _model = null;
                _operatorId = OperatorId.Undefined;
                return;
            }
            if (_operatorId == model.OperatorId) return;
            OnSet?.Invoke(_operatorId, model.OperatorId);
            _operatorId = model.OperatorId;
        }

        public void SetAnyCheckedDel(AnyCheckedDel anyCheckedDel) => _anyChecked = anyCheckedDel;
        public bool AnyChecked()
        {
            var res = _anyChecked?.Invoke(); 
            return res.HasValue ? res.Value : false;
        }
        public OperatorModel GetCurrentOperatorModel()
        {
            return _model;
        }

        public OperatorId GetCurrentOperatorId()
        {
            return _operatorId;
        }
    }
}