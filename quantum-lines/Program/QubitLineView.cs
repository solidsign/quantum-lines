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
    public class QubitLineView
    {
        private QubitInputView _startValue;
        private OperatorsLineView _operatorsLine;
        private Button _removeLineButton;

        public QubitLineView(/*сюда скорее всего приходит номер линии и исходя из него все расставляется*/)
        {
            _startValue = new QubitInputView(/*мб коорды и стартовое значение*/);
            _operatorsLine = new OperatorsLineView(/*мб коорды и стартовое значение*/);
            // и инициализация кнопки по коордам с прокидыванием события в SchemeView на удаление - для этого наверное в аргументах конструктора стоит принимать SchemeView
        }
    }
}