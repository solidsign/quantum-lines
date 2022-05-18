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
    public class OperatorOnLineView : IEquatable<Image>, IDisposable
    {
        private OperatorOnLineViewModel _viewModel;
        private MenuSchemeConnector _connector;
        private Image _image;
        private Button _upButton;
        private Button _downButton;
        private OperatorOnLineView? _upperView;
        private OperatorOnLineView? _bottomView;
        public OperatorOnLineView(OperatorId operatorId, Image image, Button upButton, Button downButton, MenuSchemeConnector connector, Action<OperatorOnLineModel> addModel)
        {
            _connector = connector;
            _viewModel = new OperatorOnLineViewModel(operatorId, addModel);
            _image = image;
            _upButton = upButton;
            _downButton = downButton;
            ChangeButtonImage();
            image.MouseLeftButtonDown += ButtonOnClick;         
            _upButton.Click += UpButtonOnClick;
            _downButton.Click += DownButtonOnClick;
        }

        public void InitAddButtons(OperatorOnLineView? upperView, OperatorOnLineView? bottomView)
        {
            InitUpperButton(upperView);
            InitBottomButton(bottomView);
        }

        private void InitUpperButton(OperatorOnLineView? upperView)
        {
            _upperView = upperView;
            if (_upperView == null) return;
            if (_upperView._viewModel.OperatorClass != OperatorClass.SizeDependentMatrix) return;
            _upButton.Visibility = Visibility.Visible;
        }
        
        private void InitBottomButton(OperatorOnLineView? bottomView)
        {
            _bottomView = bottomView;
            if (_bottomView == null) return;
            if (_bottomView._viewModel.OperatorClass != OperatorClass.SizeDependentMatrix) return;
            _downButton.Visibility = Visibility.Visible;
        }

        private void DownButtonOnClick(object sender, RoutedEventArgs e)
        {
            _bottomView.DownButtonFromAboveOnClick(_viewModel.OperatorId, _viewModel.SizeDependentIndex.Value);
        }
        
        private void UpButtonOnClick(object sender, RoutedEventArgs e)
        {
            _upperView.UpButtonFromBottomOnClick(_viewModel.OperatorId, _viewModel.SizeDependentIndex.Value);
        }

        private void DownButtonFromAboveOnClick(OperatorId id, int index)
        { 
            _viewModel.UpdateSizeDependentIndex(index + 1);
            _viewModel.UpdateSizeDependentIndexFinished();
        }

        private void UpButtonFromBottomOnClick(OperatorId id, int index)
        {
            _viewModel.UpdateSizeDependentIndex(1);
            if (_bottomView == null)
            {
                _viewModel.UpdateSizeDependentIndexFinished();
                return;
            }
            if (_bottomView._viewModel.OperatorClass != OperatorClass.SizeDependentMatrix)
            {
                _viewModel.UpdateSizeDependentIndexFinished();
                return;
            }
            _bottomView.UpdateSizeDependentIndexCascade(2);
        }

        private void UpdateSizeDependentIndexCascade(int index)
        {
            _viewModel.UpdateSizeDependentIndex(index);

            if (_bottomView == null)
            {
                _viewModel.UpdateSizeDependentIndexFinished();
                return;
            }
            if (_bottomView._viewModel.OperatorClass != OperatorClass.SizeDependentMatrix)
            {
                _viewModel.UpdateSizeDependentIndexFinished();
                return;
            }
            _bottomView.UpdateSizeDependentIndexCascade(index + 1);
        }

        private void ButtonOnClick(object sender, RoutedEventArgs e)
        {
            _viewModel.UpdateModel(_connector.GetCurrentOperator());
            if (_viewModel.OperatorClass != OperatorClass.SizeDependentMatrix)
            {
                _upButton.Visibility = Visibility.Hidden;
                _downButton.Visibility = Visibility.Hidden;
            }  
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

        public void Dispose()
        {
            _image.MouseLeftButtonDown -= ButtonOnClick;
            _upButton.Click -= UpButtonOnClick;
            _downButton.Click -= DownButtonOnClick;
            _viewModel.Dispose();
        }
    }

    public class OperatorOnLineViewModel : IDisposable
    {
        private OperatorOnLineModel _model;
        
        public BitmapImage Image => _model.Image;
        public OperatorId OperatorId => _model.OperatorId;
        public OperatorClass OperatorClass => _model.OperatorClass;
        public int? SizeDependentIndex => _model.SizeDependentIndex;
        
        public OperatorOnLineViewModel(OperatorId operatorId, Action<OperatorOnLineModel> addModel)
        {
            _model = new OperatorOnLineModel(operatorId);
            addModel(_model);
        }

        public void UpdateModel(OperatorId newModel)
        {
            _model.UpdateModel(newModel);
        }

        /// <summary>
        /// for size dependent operators
        /// </summary>
        /// <param name="newModel"></param>
        /// <param name="index"></param>
        public void UpdateModel(OperatorId newModel, int index)
        {
            _model.UpdateModel(newModel, index);
        }

        public void Dispose()
        {
            _model.Dispose();
        }

        public void UpdateSizeDependentIndex(int? index)
        {
            _model.UpdateSizeDependentIndex(index);
        }

        public void UpdateSizeDependentIndexFinished()
        {
            _model.UpdateSizeDependentIndexFinished();
        } 
    }
}
