using Casino.Model;
using Casino.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Casino.ViewModel
{
    class MainWindowViewModel:BaseViewModel
    {
        public MainWindowViewModel()
        {
            WindowHeight = 200;
            WindowWidth = 500;
            LoginVM = new LoginViewModel(this);
            CasinoVM = new CasinoViewModel(this);
            DepositVM = new DepositViewModel(this);
            WithdrawalVM = new WithdrawalViewModel(this);
            User = new User();
            CurentView = LoginVM;

            
            Title = "Вход";

        }
        #region Fields
        private int windowHeight;
        private int windowWidth;
        private string title;
        private object curentView;
        public LoginViewModel LoginVM { get; }
        public CasinoViewModel CasinoVM { get; }
        public DepositViewModel DepositVM { get; }
        public WithdrawalViewModel WithdrawalVM { get; }
        public User User { get; set; }
        #endregion


        #region Props
        public object CurentView
        {
            get => curentView;
            set
            {
                curentView = value;
                NotifyPropertyChanged(nameof(CurentView));
            }
        }
        public int WindowWidth
        {
            get => windowWidth;
            set
            {
                windowWidth = value;
                NotifyPropertyChanged(nameof(WindowWidth));
            }
        }

        public int WindowHeight
        {
            get => windowHeight;
            set
            {
                windowHeight = value;
                NotifyPropertyChanged(nameof(WindowHeight));
            }
        }

        public string Title
        {
            get => title;
            set
            {
                title = value;
                NotifyPropertyChanged(nameof(Title));
            }
        }
        #endregion
    }
}
