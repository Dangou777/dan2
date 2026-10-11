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
            return new Window(new Fontworkout());
            // return new Window(new AppShell());
        }
    }
}