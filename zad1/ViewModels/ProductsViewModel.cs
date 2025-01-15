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
            Products = new ObservableCollection<Product>();
            LoadProductsCommand = new AsyncRelayCommand(LoadProductsAsync);
            AddNewProductCommand = new RelayCommand(AddNewProduct);
        }

        public IAsyncRelayCommand LoadProductsCommand { get; }
        public RelayCommand AddNewProductCommand { get; }

        private async Task LoadProductsAsync()
        {
            var productsList = await _productService.GetAllProductsAsync();
            Products = new ObservableCollection<Product>(productsList);
        }

        private void AddNewProduct()
        {
            Console.WriteLine("AddNewProductCommand executed");

            // Tworzenie nowego produktu
            var newProduct = new Product
            {
                Name = "New Product",
                Description = "New Description",
                Price = 0.0m
            };

            // Dodawanie nowego produktu do kolekcji
            Products.Add(newProduct);

            // Opcjonalnie: Dodanie produktu do bazy danych lub innej usługi
            _productService.AddProductAsync(newProduct);
        }
    }
}
