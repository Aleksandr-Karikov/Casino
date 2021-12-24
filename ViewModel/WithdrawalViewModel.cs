using Casino.Commands;
using Casino.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
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
            WithdrawalCommand = new LamdaCommand(OnWithdrawalCommandExcute, CanWithdrawalCommandExecute);
        }
        private string number;
        public string Number
        {
            get => number;
            set
            {
                number = value;
                NotifyPropertyChanged(nameof(Number));
            }
        }
        private int sum;
        public int Sum
        {
            get => sum;
            set
            {
                sum = value;
                NotifyPropertyChanged(nameof(Sum));
            }
        }
        public ICommand CloseCommand { get; }
        private bool CanCloseCommandExecute(object o) => true;
        private void OnCloseCommandExcute(object o)
        {
            MainVM.CurentView = MainVM.CasinoVM;
            MainVM.WindowHeight = 600;
            MainVM.WindowWidth = 1050;
        }
        public ICommand WithdrawalCommand { get; }
        private bool CanWithdrawalCommandExecute(object o) => true;
        private async void OnWithdrawalCommandExcute(object o)
        {
            if (string.IsNullOrEmpty(Number))
            {
                MessageBox.Show("Одно из полей не заполнено");
                return;
            }
            if (Number.Length != 16 && !decimal.TryParse(Number, out var temp))
            {
                MessageBox.Show("Номер карты не корректен");
                return;
            }

            if (Sum <= 0 || Sum > MainVM.User.Balance)
            {
                MessageBox.Show("Сумма пополнения не корректна");
                return;
            }
            await MainVM.User.AddBalance(-Sum);
            await MainVM.CasinoVM.Update();
            MessageBox.Show("Операция выполнена");
        }
    }
}
