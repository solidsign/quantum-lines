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
    public class OperatorOnLineView
    {
        private OperatorOnLineViewModel _viewModel;
        private MenuSchemeConnector _connector;

        public OperatorOnLineView(OperatorId operatorId, Image image, MenuSchemeConnector connector)
        {
            _connector = connector;
            _viewModel = new OperatorOnLineViewModel(operatorId);
            image.MouseLeftButtonDown += ButtonOnClick;
        }

        private void ButtonOnClick(object sender, RoutedEventArgs e)
        {
            _viewModel.UpdateModel(_connector.GetCurrentOperator());
            ChangeButtonImage();
        }

        private void ChangeButtonImage()
        {

            // TODO
        }
    }

    public class OperatorOnLineViewModel
    {
        private OperatorModel _model;

        public BitmapImage Image => _model.Image;
        public OperatorId OperatorId => _model.OperatorId;
        
        public OperatorOnLineViewModel(OperatorId operatorId)
        {
            _model = OperatorModelsFactory.Create(operatorId);
        }

        public void UpdateModel(OperatorId newModel)
        {
            _model = OperatorModelsFactory.Create(newModel);
        }
    }
}
