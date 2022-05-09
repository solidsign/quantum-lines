using System;

namespace quantum_lines.Program
{


    public class MenuSchemeConnector
    {
        private OperatorId _operatorId = OperatorId.Undefined;
        public event Action<OperatorId, OperatorId> OnSet;
        public delegate bool AnyCheckedDel();
        private AnyCheckedDel _anyChecked;
        public void SetCurrentOperator(OperatorId operatorId)
        {
            if (_operatorId == operatorId) return;
            OnSet?.Invoke(_operatorId, operatorId);
            _operatorId = operatorId;
        }

        public void SetAnyCheckedDel(AnyCheckedDel anyCheckedDel) => _anyChecked = anyCheckedDel;
        public bool AnyChecked()
        {
            var res = _anyChecked?.Invoke(); 
            return res.HasValue ? res.Value : false;
        }
        public OperatorId GetCurrentOperator()
        {
            return _operatorId;
        }
    }
}