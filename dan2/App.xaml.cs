using dan2.Views;
using dan2.Temp;
namespace dan2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new SignUpPage());
            //return new Window(new SignInPage2());
        }
    }
}