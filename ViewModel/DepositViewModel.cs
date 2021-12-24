using Casino.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Casino.ViewModel
{
    class DepositViewModel
    {
        private MainWindowViewModel MainVM;
        public DepositViewModel(MainWindowViewModel mainViewModel)
        {
            MainVM = mainViewModel;
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
