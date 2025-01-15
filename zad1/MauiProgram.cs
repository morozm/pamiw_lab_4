using zad1.Services;

namespace zad1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>();

            // Rejestracja serwisów
            builder.Services.AddSingleton<IProductService, ProductService>();
            builder.Services.AddSingleton<INavigationService, NavigationService>();
            builder.Services.AddTransient<ProductsViewModel>();
            builder.Services.AddTransient<ProductDetailsViewModel>();
            builder.Services.AddTransient<ProductsPage>();
            builder.Services.AddTransient<ProductDetailsPage>();

            return builder.Build();
        }
    }
}
