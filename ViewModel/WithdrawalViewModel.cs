using Casino.Commands;
using Casino.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Casino.ViewModel
{
    class WithdrawalViewModel:BaseViewModel
    {
        private readonly MainWindowViewModel MainVM;
        public WithdrawalViewModel(MainWindowViewModel mainVm)
        {
            MainVM = mainVm;
            CloseCommand = new LamdaCommand(OnCloseCommandExcute, CanCloseCommandExecute);
        }
        public ICommand CloseCommand { get; }
        private bool CanCloseCommandExecute(object o) => true;
        private void OnCloseCommandExcute(object o)
        {
            MainVM.CurentView = MainVM.CasinoVM;
            MainVM.WindowHeight = 450;
            MainVM.WindowWidth = 800;
        }
    }
}
