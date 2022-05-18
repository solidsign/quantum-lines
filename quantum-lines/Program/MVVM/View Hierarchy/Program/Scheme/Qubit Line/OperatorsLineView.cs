using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using quantum_lines.Program;
using quantum_lines.Program.Operators;

namespace quantum_lines
{
    public class OperatorsLineView : IEquatable<List<Image>>, IDisposable
    {
        private List<OperatorOnLineView> _views;
        public OperatorsLineView(List<(OperatorId id, Image image)> images, MenuSchemeConnector connector, Action<List<OperatorOnLineModel>> addLine)
        {
            var operatorModels = new List<OperatorOnLineModel>(images.Count);
            _views = new List<OperatorOnLineView>();
            foreach (var i in images)
            {
                _views.Add(new OperatorOnLineView(i.id, i.image, connector, AddModel));
            }
            addLine(operatorModels);
            
            void AddModel(OperatorOnLineModel model) => operatorModels.Add(model);
        }

        public bool Equals(List<Image>? other)
        {
            return _views.TrueForAll(x => other.Any(i => x.Equals(i)));
        }

        public void Dispose()
        {
            foreach (var view in _views)
            {
                view.Dispose();
            }
        }
    }
}