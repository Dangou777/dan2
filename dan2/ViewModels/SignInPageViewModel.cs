using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dan2.Service;
using dan2.Helpers;
using System.Windows.Input;

namespace dan2.ViewModels
{
    internal class SignInPageViewModel : ViewModelBase /*ObservableObject*/
    {
        private string _togglePasswordButtonText;
        private string? _userName;
        private string? _password;
        private bool _entryAsPassword;
        private bool _isDebugMode = true;
        private DBMokup? _dbMokup;
        private string _loginMessage;
        private bool _signInMessageVisible;
        private string _signInMessageColor;

        public ICommand SignInCommand { get; } 
       public ICommand ShowPasswordCommand { get; }
        public string TogglePasswordButtonText
        {
            get => _togglePasswordButtonText;
            set
            {
                if (_togglePasswordButtonText != value)
                {
                    _togglePasswordButtonText = value;
                    OnPropertyChanged(nameof(TogglePasswordButtonText));
                }
            }
        }
        public bool SignInMessageVisible
        {
            get => _signInMessageVisible;
            set
            {

                if (_signInMessageVisible != value)
                {
                    _signInMessageVisible = value;
                    OnPropertyChanged(nameof(SignInMessageVisible));
                }

            }
        }
        public string SignInMessageColor
        {
            get => _signInMessageColor;
            set
            {
                if (value != _signInMessageColor)
                {
                    _signInMessageColor = value;
                    OnPropertyChanged(nameof(SignInMessageColor));
                }

            }
        }
        public string LoginMessage
        {
            get => _loginMessage;
            set
            {
                if (_loginMessage != value)
                {
                    _loginMessage = value;
                    OnPropertyChanged(nameof(LoginMessage));
                }
            }
        }
        public bool EntryAsPassword
        {
            get => _entryAsPassword;
            set
            {
                if (_entryAsPassword != value)
                {
                    _entryAsPassword = value;
                    OnPropertyChanged(nameof(EntryAsPassword));
                }
            }
        }
        public string UserName
        {
            get => _userName;
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    OnPropertyChanged(nameof(UserName));
                    (SignInCommand as Command)?.ChangeCanExecute();
                }
            }

        }
        public string UserPassword
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(UserPassword));
                    (SignInCommand as Command)?.ChangeCanExecute();
                }
            }
        }
        private bool canSignIn()
        {
            return !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(UserPassword);
        }
        void OnSignInButtonClicked()
        {
            if (_dbMokup!.IsExist(UserName, UserPassword))
            {
                SignInMessageVisible = true;
                SignInMessageColor = "green";
                LoginMessage = AppMessages.loginMessage;
            }
            else
            {
                SignInMessageVisible = true;
                SignInMessageColor = "red";
                LoginMessage = AppMessages.loginErrorMessage;

            }
        }


        public SignInPageViewModel()
        {
            ShowPasswordCommand = new Command(() =>
            {
                if (EntryAsPassword)
                    TogglePasswordButtonText = FontHelper.CLOSED_EYE_ICON;
                else
                    TogglePasswordButtonText = FontHelper.OPEN_EYE_ICON;
                EntryAsPassword = !EntryAsPassword;
            });

            SignInCommand = new Command(OnSignInButtonClicked, canSignIn);
            TogglePasswordButtonText = FontHelper.CLOSED_EYE_ICON;
            EntryAsPassword = true;

            _dbMokup = new DBMokup();
            if (_isDebugMode)
            {
                UserName = "admin@mail.com";
                UserPassword = "admin";
            }
        }
    }
    
}
