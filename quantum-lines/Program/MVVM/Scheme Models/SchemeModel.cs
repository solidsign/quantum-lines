using System;
using System.Collections.Generic;
using quantum_lines.Program.Operators;

namespace quantum_lines
{
    public class SchemeModel
    {
        public SchemeModel()
        {
            Inputs = new List<QubitInputModel>();
            Results = new List<QubitResultModel>();
            OperatorLines = new List<List<OperatorOnLineModel>>();
        }

        public event Action? SchemeUpdated;
        
        public void InvokeSchemeUpdated()
        {
            SchemeUpdated?.Invoke();
        }
        public List<QubitInputModel> Inputs { get; private set; }
        public List<QubitResultModel> Results { get; private set; }
        public List<List<OperatorOnLineModel>> OperatorLines { get; private set; }
    }
}