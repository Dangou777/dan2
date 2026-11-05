using dan2.Helpers;
using dan2.Service;

namespace dan2.Views;

public partial class SignInPage : ContentPage
{
    private string _userName;
    private string _password;
    private bool _entryAsPassword;
    private _isDebugMode => true;
    private DBMokup _dbMokup;
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
    public SignInPage()
    {
        InitializeComponent();
        BindingContext = this;
        EntryAsPassword = true;
        _dbMokup = new DBMokup();
        if (_isDebugMode)
        {
            UserName = "adminMail.com";
            UserPassword = "admin";
        }
    }
    void OnSignInButtonClicked(object sender, EventArgs e)
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
    void TogglePassordButton_Clicked(object sender, EventArgs e)
    {
        var visBtn = sender as Button;
        if (EntryAsPassword)
            visBtn!.Text = FontHelper.CLOSED_EYE_ICON;
        else
            visBtn!.Text = FontHelper.OPEN_EYE_ICON;

        EntryAsPassword = !EntryAsPassword;
    }
    
}
