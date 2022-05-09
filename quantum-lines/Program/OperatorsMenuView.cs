using quantum_lines.Program.Operators;
using System.Collections.Generic;

namespace quantum_lines.Program
{
    public class OperatorsMenuView
    {
        // тут должно быть разделение на виды операторов по блокам (как в Quirk'е: арифметические, крученые, верченые, ебанутые и тд)
        private OperatorMenuViewModel _viewModel;
        private List<OperatorMenuItemView> _operators;
        public OperatorsMenuView()
        {
            _operators = new List<OperatorMenuItemView>;
            _viewModel = new OperatorMenuViewModel();
            // тут должны подниматься все реализованные операторы
            // и рассовываться по блокам
            // 
            // доставать все существующие операторы  и разделением их по разным стоит на уровне ViewModel
            // а тут только визуально их распихивать
            //
            // ViewModel для OperatorsMenu можно просто в первой строчке создать написав что-то типа
            // _viewModel = new OperatorsMenuViewModel(this);
            // и дальше юзать информацию, которую предоставит _viewModel для расстановки
            // _viewModel наверное надо будет хранить как поле в этом классе
        }

        // тут еще должна быть обработка нажатий по операторам
    }
}