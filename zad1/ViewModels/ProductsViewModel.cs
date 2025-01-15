using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using zad1.Models;
using zad1.Services;

public partial class ProductsViewModel : ObservableObject
{
    private readonly IProductService _productService;
    private readonly INavigationService _navigationService;
    private Product selectedProduct;

    [ObservableProperty]
    private ObservableCollection<Product> products;

    public ProductsViewModel(IProductService productService, INavigationService navigationService)
    {
        _productService = productService;
        _navigationService = navigationService;
        Products = new ObservableCollection<Product>();
        LoadProductsCommand = new AsyncRelayCommand(LoadProductsAsync);
        AddNewProductCommand = new RelayCommand(AddNewProduct);
        EditProductCommand = new AsyncRelayCommand<Product>(EditProduct);
    }

    public IAsyncRelayCommand LoadProductsCommand { get; }
    public RelayCommand AddNewProductCommand { get; }
    public IAsyncRelayCommand<Product> EditProductCommand { get; }

    public Product SelectedProduct
    {
        get => selectedProduct;
        set
        {
            if (SetProperty(ref selectedProduct, value))
            {
                // Można dodatkowo odświeżyć widok
            }
        }
    }

    private async Task EditProduct(Product product)
    {
        if (product != null)
        {
            // Przekazujemy pełną nazwę typu strony (w tym przestrzeń nazw)
            await _navigationService.NavigateToAsync("zad1.ProductDetailsPage", product);
        }
    }


    private async Task LoadProductsAsync()
    {
        var productsList = await _productService.GetAllProductsAsync();
        Products = new ObservableCollection<Product>(productsList);
    }

    private void AddNewProduct()
    {
        var newProduct = new Product
        {
            Name = "New Product",
            Description = "New Description",
            Price = 0.0m
        };

        Products.Add(newProduct);
        _productService.AddProductAsync(newProduct);
    }
}

