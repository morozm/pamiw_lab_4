using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using zad1.Models;
using zad1.Services;

namespace zad1
{
    public partial class ProductsViewModel : ObservableObject
    {
        private readonly IProductService _productService;

        [ObservableProperty]
        private ObservableCollection<Product> products;

        public ProductsViewModel(IProductService productService)
        {
            _productService = productService;
            LoadProductsCommand = new AsyncRelayCommand(LoadProductsAsync);
        }

        public IAsyncRelayCommand LoadProductsCommand { get; }

        private async Task LoadProductsAsync()
        {
            var productsList = await _productService.GetAllProductsAsync();
            Products = new ObservableCollection<Product>(productsList);
        }
    }
}