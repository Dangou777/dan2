using dan2.Helpers;
using dan2.Service;
using dan2.ViewModels;

namespace dan2.Views;

public partial class SignInPage : ContentPage
{
    public SignInPage()
    {
        InitializeComponent();
        BindingContext = new SignInPageViewModel();
    }


}
