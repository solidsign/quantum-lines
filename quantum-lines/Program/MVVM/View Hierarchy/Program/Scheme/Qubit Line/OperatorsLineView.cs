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
        private List<OperatorOnLineModel> _operatorModels;
        private Action<List<OperatorOnLineModel>> _removeLine;
        public OperatorsLineView(List<(OperatorId id, Image image)> images, List<Button> upButtons, List<Button> downButtons, MenuSchemeConnector connector, Action<List<OperatorOnLineModel>> addLine, Action<List<OperatorOnLineModel>> removeLine)
        {
            _removeLine = removeLine;
            _operatorModels = new List<OperatorOnLineModel>(images.Count);
            _views = new List<OperatorOnLineView>();
            for (var i = 0; i < images.Count; i++)
            {
                _views.Add(new OperatorOnLineView(images[i].id, images[i].image, upButtons[i], downButtons[i], connector, AddModel));
            }
            addLine(_operatorModels);
            
            void AddModel(OperatorOnLineModel model) => _operatorModels.Add(model);
        }

        public void InitAddButtons(OperatorsLineView? up, OperatorsLineView? down)
        {
            for (var i = 0; i < _views.Count; i++)
            {
                _views[i].InitAddButtons(up?._views[i], down?._views[i]);
            }
        }

        public void ReinitBottomAddButtons(OperatorsLineView? down)
        {
            for (var i = 0; i < _views.Count; i++)
            {
                _views[i].ReinitBottomAddButtons(down?._views[i]);
            }
        }

        public bool Equals(List<Image>? other)
        {
            if (other == null) throw new ArgumentException();
            return _views.TrueForAll(x => other.Any(i => x.Equals(i)));
        }

        public void Dispose()
        {
            _removeLine(_operatorModels);
            foreach (var view in _views)
            {
                view.Dispose();
            }
        }
    }
}