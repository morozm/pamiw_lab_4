using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using zad1.Services;
using zad1.Models;

namespace zad1
{
    public partial class ProductDetailsViewModel : ObservableObject
    {
        private readonly IProductService _productService;

        [ObservableProperty]
        private Product product;

        public ProductDetailsViewModel(IProductService productService)
        {
            _productService = productService;
            SaveProductCommand = new AsyncRelayCommand(SaveProductAsync);
        }

        public IAsyncRelayCommand SaveProductCommand { get; }

        private async Task SaveProductAsync()
        {
            if (Product.Id == 0)
            {
                await _productService.AddProductAsync(Product);
            }
            else
            {
                await _productService.UpdateProductAsync(Product);
            }
        }
    }
}
