using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quantum_lines.Program
{
    // он будет создаваться в MainWindow при старте приложухи
    // и он типа каскадом будет создавать все вьюхи, вьюмодели, модели
    public class ProgramView
    {
        private SchemeView _scheme;
        private OperatorsMenuView _operatorsMenu;

        public ProgramView(/*возможно стартовый конфиг*/)
        {
            _scheme = new SchemeView(/*возможно сюда надо будет прокидывать этот конфиг*/);
            _operatorsMenu = new OperatorsMenuView();
        }
    }
}
