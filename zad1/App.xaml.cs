namespace zad1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            var productsPage = Handler.MauiContext.Services.GetService<ProductsPage>();
            return new Window(new NavigationPage(productsPage));
        }
    }
}
