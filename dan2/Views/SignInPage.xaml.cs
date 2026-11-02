using dan2.Helpers;

namespace dan2.Views;

public partial class SignInPage : ContentPage
{
    private bool _entryIsPassword;
      public bool EntryIsPassword
    {
        get => _entryIsPassword;
        set
        {
            if (_entryIsPassword != value)
            {
                _entryIsPassword = value;
                OnPropertyChanged();
            }
        }
    }
    public SignInPage()
	{
		InitializeComponent();
        BindingContext = this;
    }
    private void TogglePassordButton_Clicked(object sender, EventArgs e)
    {
        var visBtn = sender as Button;
        if (EntryIsPassword)
            visBtn!.Text = FontHelper.CLOSED_EYE_ICON;
        else
            visBtn!.Text = FontHelper.OPEN_EYE_ICON;
        EntryIsPassword = !EntryIsPassword;

    }
}