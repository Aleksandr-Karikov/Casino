using Casino.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Casino.ViewModel
{
    class CasinoViewModel:BaseViewModel
    {
        private MainWindowViewModel MainVM;
        public CasinoViewModel(MainWindowViewModel mainViewModel)
        {
            MainVM = mainViewModel;
            
        }
    }
}
