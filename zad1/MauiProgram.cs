using Microsoft.Maui.Hosting;
using Microsoft.Extensions.DependencyInjection;
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
            builder.Services.AddTransient<ProductsViewModel>();
            builder.Services.AddTransient<ProductDetailsViewModel>();

            return builder.Build();
        }
    }
}
