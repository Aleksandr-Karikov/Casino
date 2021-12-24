using Casino.Commands;
using Casino.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Casino.ViewModel
{
    class DepositViewModel:BaseViewModel
    {
        private MainWindowViewModel MainVM;
        public DepositViewModel(MainWindowViewModel mainViewModel)
        {
            MainVM = mainViewModel;
            CloseCommand = new LamdaCommand(OnCloseCommandExcute, CanCloseCommandExecute);
            DepositCommand = new LamdaCommand(OnDepositCommandExcute, CanDepositCommandExecute);
        }
        private string cvv;
        private string number;
        private string date;
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
        public string Date
        {
            get => date;
            set
            {
                date = value;
                NotifyPropertyChanged(nameof(Date));
            }
        }
        public string Number
        {
            get => number;
            set
            {
                number = value;
                NotifyPropertyChanged(nameof(Number));
            }
        }
        public string Cvv
        {
            get => cvv;
            set
            {
                cvv = value;
                NotifyPropertyChanged(nameof(Cvv));
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
        public ICommand DepositCommand { get; }
        private bool CanDepositCommandExecute(object o)
        {
            return true;
        }
        private async void OnDepositCommandExcute(object o)
        {
            if (string.IsNullOrEmpty(Cvv) || string.IsNullOrEmpty(Date) || string.IsNullOrEmpty(Number))
            {
                MessageBox.Show("Одно из полей не заполнено");
                return;
            }
            if (Number.Length!=16 && !decimal.TryParse(Number,out var temp))
            {
                MessageBox.Show("Номер карты не корректен");
                return;
            }
            Regex regex = new Regex(@"\d{2}/\d{2}");
            MatchCollection matches = regex.Matches(Date);
            if (matches.Count == 0 || matches[0].ToString() != Date)
            {
                MessageBox.Show("Срок годности карты не корректен");
                return;
            }
            if (Cvv.Length != 3 && !int.TryParse(Number, out var temp2))
            {
                MessageBox.Show("Cvv не корректен");
                return;
            }
            if (Sum <= 0)
            {
                MessageBox.Show("Сумма пополнения не корректна");
                return;
            }
            await MainVM.User.AddBalance(Sum);
            await MainVM.CasinoVM.Update();
            MessageBox.Show("Пополнение выполнено успешно");
        }
    }
}
