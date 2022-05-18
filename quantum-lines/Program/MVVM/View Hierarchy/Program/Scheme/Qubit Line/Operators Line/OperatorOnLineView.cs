using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace quantum_lines.Program.Operators
{
    public class OperatorOnLineView : IEquatable<Image>
    {
        private OperatorOnLineViewModel _viewModel;
        private MenuSchemeConnector _connector;
        private Image _image;
        public OperatorOnLineView(OperatorId operatorId, Image image, MenuSchemeConnector connector, Action<OperatorOnLineModel> addModel)
        {
            _connector = connector;
            _viewModel = new OperatorOnLineViewModel(operatorId, addModel);
            _image = image;
            ChangeButtonImage();
            image.MouseLeftButtonDown += ButtonOnClick;
        }

        private void ButtonOnClick(object sender, RoutedEventArgs e)
        {
            _viewModel.UpdateModel(_connector.GetCurrentOperator());
            ChangeButtonImage();
        }

        private void ChangeButtonImage()
        {
            _image.Source = _viewModel.Image;
        }

        public bool Equals(Image? other)
        {
            return _image == other;
        }
    }

    public class OperatorOnLineViewModel
    {
        private OperatorOnLineModel _model;
        
        public BitmapImage Image => _model.Image;
        public OperatorId OperatorId => _model.OperatorId;
        
        public OperatorOnLineViewModel(OperatorId operatorId, Action<OperatorOnLineModel> addModel)
        {
            _model = new OperatorOnLineModel(operatorId);
            addModel(_model);
        }

        public void UpdateModel(OperatorId newModel)
        {
            _model.UpdateModel(newModel);
        }
    }
}
