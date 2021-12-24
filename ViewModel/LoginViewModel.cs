using Casino.Commands;
using Casino.Model;
using Casino.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Casino.ViewModel
{
    class LoginViewModel:BaseViewModel
    {
        
        private MainWindowViewModel MainVM { get; }
        public LoginViewModel(MainWindowViewModel mainVm)
        {

            MainVM = mainVm;

            RegisterCommand = new LamdaCommand(OnRegisterCommandExcute, CanRegisterCommandExecute);
            LoginCommand = new LamdaCommand(OnLoginCommandExcute, CanLoginCommandExecute);
        }
        private string password;
        private string login;

        public string Password
        {
            get => password;
            set
            {
                password = value;
                NotifyPropertyChanged(nameof(password));
            }
        }
        public string Login
        {
            get => login;
            set
            {
                login = value;
                NotifyPropertyChanged(nameof(Login));
            }
        }

        public ICommand RegisterCommand { get; }
        private bool CanRegisterCommandExecute(object o) => true;
        private async void OnRegisterCommandExcute(object o)
        {
            if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Одно из полей не заполнено");
                return;
            }
            if (Login.Contains(' ') || Password.Contains(' '))
            {
                MessageBox.Show("Поля не могут содержать пробелов");
                return;
            }
            if (Login.Length > 30 || Login.Length <2)
            {
                MessageBox.Show("Логин не доустимой длины");
                return;
            }
            if (Password.Length > 30 || Password.Length < 6)
            {
                MessageBox.Show("Логин не доустимой длины");
                return;
            }
            try
            {
                await MainVM.User.Register(Login, Password);
                MessageBox.Show("Пользователь зарегестрирован");
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }
        public ICommand LoginCommand { get; }
        private bool CanLoginCommandExecute(object o) => true;
        private async void OnLoginCommandExcute(object o)
        {
            try
            {
                await MainVM.User.LoginUser(Login, Password);
                MessageBox.Show($"Дообро пожаловать {Login}");
                MainVM.CurentView = MainVM.CasinoVM;
                MainVM.Title = "Казино";
                MainVM.WindowHeight = 600;
                MainVM.WindowWidth = 1050;
                MainVM.CasinoVM.Login = MainVM.User.Login;
                MainVM.CasinoVM.Balance = MainVM.User.Balance;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
