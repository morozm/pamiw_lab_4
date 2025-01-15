using Microsoft.Maui.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace zad1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        // Nadpisanie metody CreateWindow
        protected override Window CreateWindow(IActivationState activationState)
        {
            // Uzyskanie instancji ProductsPage z kontenera usług
            var productsPage = Handler.MauiContext.Services.GetService<ProductsPage>();
            return new Window(new NavigationPage(productsPage));
        }
    }
}
