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

        public List<List<OperatorOnLineModel>> OperatorColumns
        {
            get
            {
                List<List<OperatorOnLineModel>> res = new List<List<OperatorOnLineModel>>();
                for (var i = 0; i < OperatorLines[0].Count; i++)
                {
                    List<OperatorOnLineModel> col = new List<OperatorOnLineModel>();
                    for (var j = 0; j < OperatorLines.Count; j++)
                    {
                        col.Add(OperatorLines[j][i]);
                    }

                    res.Add(col);
                }
                return res;
            }
        }
    }
}