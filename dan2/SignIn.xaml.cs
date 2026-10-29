namespace dan2;

public partial class SignIn : ContentPage
{
	public SignIn()
	{
		InitializeComponent();
	}
    private void TogglePassordButton_Clicked(object sender, EventArgs e)
    {
        var visBtn = sender as Button;
        if (PasswordEntry.IsPassword)
            visBtn!.Text = FontHelper.CLOSED_EYE_ICON;
        else
            visBtn!.Text = FontHelper.OPEN_EYE_ICON;
        PasswordEntry.IsPassword = !PasswordEntry.IsPassword;

    }
}