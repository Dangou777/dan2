using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using dan2.Helpers;
using dan2.Service;

namespace dan2.ViewModels
{
    internal class SignUpPageViewModel : ViewModelBase
    {
        private string? _firstName;
        private string? _lastName;
        private string? _email;
        private string? _password;
        private string? _mobile;
        private bool _entryAsPassword;
        private string? _passwordIconCode;


        public string FirstName
        {
            get => _firstName;
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged();
                }
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged();
                }
            }
        }
        public string UserEmail
        {
            get => _email;
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged();
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
                    OnPropertyChanged();
                }
            }
        }
        public string Mobile
        {
            get => _mobile;
            set
            {
                if (_mobile != value)
                {
                    _mobile = value;
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
                    OnPropertyChanged();
                }
            }
        }
        public string PasswordIconCode
        {
            get => _passwordIconCode;
            set
            {
                if (_passwordIconCode != value)
                {
                    _passwordIconCode = value;
                    OnPropertyChanged();
                }
            }
        }
        public ICommand ShowPasswordCommand { get; }
        public ICommand SignupCommand { get; }
        private void TogglePasswordButton()
        {
            if (EntryAsPassword)
                PasswordIconCode = FontHelper.CLOSED_EYE_ICON;
            else
                PasswordIconCode = FontHelper.OPEN_EYE_ICON;
            EntryAsPassword = !EntryAsPassword;
        }
        private async void SignUp()
        {
            //Register user into DB
            //Save User to Current User
            //Go to Main Page
            await Toast.Make($" SignUp new user", ToastDuration.Short, 14).Show();
        }

        private bool Validate()
        {
            var fnameOK = !string.IsNullOrEmpty(FirstName);
            var lnameOK = !string.IsNullOrEmpty(LastName);
            var emailOK = !string.IsNullOrEmpty(UserEmail);
            var passOK = string.IsNullOrEmpty(UserPassword) ? false :
            UserPassword.Length > 5;
            var mobileOK = string.IsNullOrEmpty(Mobile) ? false :
            Mobile.Length == 10;
            return fnameOK && lnameOK && emailOK && passOK && mobileOK;
        }
        public SignUpPageViewModel()
        {
            EntryAsPassword = true;
            PasswordIconCode = FontHelper.CLOSED_EYE_ICON;
            ShowPasswordCommand = new Command(TogglePasswordButton);
            SignupCommand = new Command(SignUp, Validate);
        }

    }
}
