using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dan2.Service;
using dan2.Helpers;

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
                    OnPropertyChanged(nameof());
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
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
                    OnPropertyChanged(nameof(IsSignInButtonEnabled));
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
                    OnPropertyChanged(nameof(IsSignInButtonEnabled));
                }
            }
        }
        public bool IsSignInButtonEnabled
        {

            get => !(string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(UserPassword));

        }
        void OnSignInButtonClicked()
        {
            if (_dbMokup.isExist(UserName, UserPassword))
            {
                errorLbl.IsVisible = true;
                errorLbl.Text = "התחברות הצליחה";
            }
            else
            {
                errorLbl.IsVisible = true;
                errorLbl.Text = "סיסמה או שם משתמש שגויים";

            }
        }
        void TogglePassordButton_Clicked()
        {
            if (EntryAsPassword)
                TogglePasswordButtonText = FontHelper.CLOSED_EYE_ICON;
            else
                TogglePasswordButtonText = FontHelper.OPEN_EYE_ICON;
            EntryAsPassword = !EntryAsPassword;
        }

        public SignInPageViewModel()
        {
            ShowPasswordCommand = new(TogglePassordButton_Clicked);
           SignInCommand = new(OnSignInButtonClicked);
            EntryAsPassword = true;
            _dbMokup = new DBMokup();
            if (_isDebugMode)
            {
                UserName = "adminMail.com";
                UserPassword = "admin";
            }
        }
    }
    
}
