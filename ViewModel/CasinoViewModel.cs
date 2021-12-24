using Casino.Commands;
using Casino.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Casino.ViewModel
{
    class CasinoViewModel : BaseViewModel
    {
        Dictionary<int, string> Slots = new Dictionary<int, string>()
        {
            {0,"../Icons/7.png" },
            {1,"../Icons/Vish.png" },
            {2,"../Icons/Sliva.png" },
            {3,"../Icons/Limon.png" },
            {4,"../Icons/Klubnica.png" },
            {5,"../Icons/Banan.png" },
            {6,"../Icons/Arbus.png" },
            {7,"../Icons/Apelsin.png" },

        };
        private MainWindowViewModel MainVM;
        public CasinoViewModel(MainWindowViewModel mainViewModel)
        {
            MainVM = mainViewModel;
            StartCommand = new LamdaCommand(OnStartCommandExcute, CanStartCommandExecute);
            DepositCommand = new LamdaCommand(OnDepositCommandExcute, CanDepositCommandExecute);
            WithdrawalCommand = new LamdaCommand(OnWithdrawalCommandExcute, CanWithdrawalCommandExecute);
            ChangeUserCommand = new LamdaCommand(OnChangeUserCommandExcute, CanChangeUserCommandExecute);
            Set5000Command = new LamdaCommand(OnSet5000CommandExcute, CanSet5000CommandExecute);
            Set50Command = new LamdaCommand(OnSet50CommandExcute, CanSet50CommandExecute);
            Set500Command = new LamdaCommand(OnSet500CommandExcute, CanSet500CommandExecute);
            Set5Command = new LamdaCommand(OnSet5CommandExcute, CanSet5CommandExecute);
            SetX2Command = new LamdaCommand(OnSetX2CommandExcute, CanSetX2CommandExecute);
            SetDevideCommand = new LamdaCommand(OnSetDevideCommandExcute, CanSetDevideCommandExecute);
            SetAllInCommand = new LamdaCommand(OnSetAllInCommandExcute, CanSetAllInCommandExecute);
            CansleCommand = new LamdaCommand(OnCansleCommandExcute, CanCansleCommandExecute);
            SetCommand = new LamdaCommand(OnSetCommandExcute, CanSetCommandExecute);
        }
        public async Task Update()
        {
            await MainVM.User.UpdateDatas();
            Balance = MainVM.User.Balance;
            Login = MainVM.User.Login;
        }
        private int? balance;
        public int? Balance
        {
            get => balance;
            set
            {
                balance = value;
                NotifyPropertyChanged(nameof(Balance));
            }
        }
        private int bet;
        public int Bet
        {
            get => bet;
            set
            {
                bet = value;
                NotifyPropertyChanged(nameof(Bet));
            }
        }

        private decimal winSum;
        public decimal WinSum
        {
            get => winSum;
            set
            {
                winSum = value;
                NotifyPropertyChanged(nameof(WinSum));
            }
        }
        private int betBox;
        public int BetBox
        {
            get => betBox;
            set
            {
                betBox = value;
                NotifyPropertyChanged(nameof(BetBox));
            }
        }
        private string login;
        public string Login
        {
            get => login;
            set
            {
                login = value;
                NotifyPropertyChanged(nameof(Login));
            }
        }

        private string displayedSlot1Path;
        public string DisplayedSlot1Path
        {
            get => displayedSlot1Path;
            set
            {
                displayedSlot1Path = value;
                NotifyPropertyChanged(nameof(DisplayedSlot1Path));
            }
        }
        private string displayedSlot2Path;
        public string DisplayedSlot2Path
        {
            get => displayedSlot2Path;
            set
            {
                displayedSlot2Path = value;
                NotifyPropertyChanged(nameof(DisplayedSlot2Path));
            }
        }

        private string displayedSlot3Path;
        public string DisplayedSlot3Path
        {
            get => displayedSlot3Path;
            set
            {
                displayedSlot3Path = value;
                NotifyPropertyChanged(nameof(DisplayedSlot3Path));
            }
        }
        public ICommand SetCommand { get; }
        private bool CanSetCommandExecute(object o)
        {
            if (IsEnabled) return false;
            return true;
        }
        private void OnSetCommandExcute(object o)
        {
            Bet = BetBox;
        }
        public ICommand CansleCommand { get; }
        private bool CanCansleCommandExecute(object o)
        {
            if (IsEnabled) return false;
            return true;
        }
        private void OnCansleCommandExcute(object o)
        {
            Bet = 0;
        }
        public ICommand SetAllInCommand { get; }
        private bool CanSetAllInCommandExecute(object o)
        {
            if (IsEnabled) return false;
            return true;
        }
        private void OnSetAllInCommandExcute(object o)
        {
            Bet = (int)Balance;
        }
        public ICommand SetDevideCommand { get; }
        private bool CanSetDevideCommandExecute(object o)
        {
            if (IsEnabled) return false;
            return true;
        }
        private void OnSetDevideCommandExcute(object o)
        {
            Bet /= 2;
        }
        public ICommand SetX2Command { get; }
        private bool CanSetX2CommandExecute(object o)
        {
            if (IsEnabled) return false;
            return true;
        }
        private void OnSetX2CommandExcute(object o)
        {
            Bet *= 2;
        }
        public ICommand Set50Command { get; }
        private bool CanSet50CommandExecute(object o)
        {
            if (IsEnabled) return false;
            return true;
        }
        private void OnSet50CommandExcute(object o)
        {
            Bet += 50;
        }
        public ICommand Set500Command { get; }
        private bool CanSet500CommandExecute(object o)
        {
            if (IsEnabled) return false;
            return true;
        }
        private void OnSet500CommandExcute(object o)
        {
            Bet += 500;
        }
        public ICommand Set5000Command { get; }
        private bool CanSet5000CommandExecute(object o)
        {
            if (IsEnabled) return false;
            return true;
        }
        private void OnSet5000CommandExcute(object o)
        {
            Bet += 5000;
        }
        public ICommand Set5Command { get; }
        private bool CanSet5CommandExecute(object o)
        {
            if (IsEnabled) return false;
            return true;
        }
        private void OnSet5CommandExcute(object o)
        {
            Bet += 5;
        }
        public ICommand ChangeUserCommand { get; }
        private bool CanChangeUserCommandExecute(object o)
        {
            if (IsEnabled) return false;
            return true;
        }
        private void OnChangeUserCommandExcute(object o)
        {
            MainVM.CurentView = MainVM.LoginVM;
            MainVM.WindowHeight = 200;
            MainVM.WindowWidth = 500;
        }
        public ICommand WithdrawalCommand { get; }
        private bool CanWithdrawalCommandExecute(object o)
        {
            if (IsEnabled) return false;
            return true;
        }
        private void OnWithdrawalCommandExcute(object o)
        {
            MainVM.CurentView = MainVM.WithdrawalVM;
            MainVM.WindowHeight = 200;
            MainVM.WindowWidth = 300;
        }
        public ICommand DepositCommand { get; }
        private bool CanDepositCommandExecute(object o)
        {
            if (IsEnabled) return false;
            return true;
        }
        private void OnDepositCommandExcute(object o)
        {
            MainVM.CurentView = MainVM.DepositVM;
            MainVM.WindowHeight = 270;
            MainVM.WindowWidth = 350;
        }
        public ICommand StartCommand { get; }
        private bool CanStartCommandExecute(object o)
        {
            if (IsEnabled || Bet <= 0 || Bet > Balance) return false;
            return true;
        }
        private bool IsEnabled{get;set;}
        private async void OnStartCommandExcute(object o)
        {
            await Start();

        }
        private async Task Start()
        {
           // Bet = 100;
            IsEnabled = true;
            Random rnd = new Random();
            int slot1=0,slot2=0,slot3=0;
            for (int i = 0; i < 30; i++)
            {
                slot1 = rnd.Next(0, 8);
                slot2 = rnd.Next(0, 8);
                slot3 = rnd.Next(0, 8);
                DisplayedSlot1Path = Slots[slot1];
                DisplayedSlot2Path = Slots[slot2];
                DisplayedSlot3Path = Slots[slot3];
                switch (i)
                {
                    case >28:
                        await Task.Delay(2000);
                        break;
                    case >22:
                        await Task.Delay(1000);
                        break;
                    case > 0:
                        await Task.Delay(300);
                        break;
                }




            }
            if (slot1 == slot2 && slot1 == slot3)
            {
                if (slot1 != 0)
                {
                    WinSum = (slot1 + 5) * Bet;
                    Balance += (int)WinSum;
                }
                else
                {
                   //ban
                }
            } else
            if ((slot1 == slot2 && slot1!=slot3)  || (slot3 == slot1 && slot2 != slot3))
            {
                if (slot1 != 0)
                {
                    WinSum = (slot1 + 3) * Bet;
                    Balance += (int)WinSum;
                }

            }
            else if (slot3 == slot2 && slot1 != slot3)
            {
                if (slot3 != 0)
                {
                    WinSum = (slot3 + 3) * Bet;
                    Balance += (int)WinSum;
                }
            }
            else
            {
                winSum = 0;
                Balance -= Bet;
            }
            await MainVM.User.SetBalance((int)Balance);
            await Update();
            IsEnabled = false;
        }
    }
}
