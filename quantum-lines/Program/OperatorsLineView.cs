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

namespace quantum_lines
{
    public class OperatorsLineView
    {
        public OperatorsLineView(/*наверное номер линии(исходя из него вычислять координаты линии) и мб стартовый набор операторов для него*/)
        {
            // тут создаются сами линии для xaml'а
            // и накидываюстя операторы, если есть какой-то дефолтный набор - возможно его стоит инициализировать из viewModel, который будет создавать модель и в этот момент чекать надо ли накинуть стартовых операторов
        }
    }
}