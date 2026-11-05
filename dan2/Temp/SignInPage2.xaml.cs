using dan2.Helpers;
namespace dan2.Temp;

public partial class SignInPage2 : ContentPage
{
	public SignInPage2()
	{
		InitializeComponent();
	}
    void OnSignInButtonClicked(object sender, EventArgs e)
    {
        var visBtn = sender as Button;
        if (PasswordEntry.IsPassword)
            visBtn!.Text = FontHelper.CLOSED_EYE_ICON;
        else
            visBtn!.Text = FontHelper.OPEN_EYE_ICON;

        PasswordEntry.IsPassword = !PasswordEntry.IsPassword;
    }
}