using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using dan2.Helpers;
using dan2.Service;
using dan2.ViewModels;

namespace dan2.Views;

public partial class SignUpPage : ContentPage
{
    public SignUpPage()
    {
        InitialzeComponent();
        BindingContext = new SignUpPageViewModel();
    }

}