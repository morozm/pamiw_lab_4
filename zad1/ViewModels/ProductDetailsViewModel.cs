using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using zad1.Services;
using zad1.Models;
using System.Diagnostics;

public partial class ProductDetailsViewModel : ObservableObject
{
    private readonly IProductService _productService;
    private readonly INavigationService _navigationService;

    [ObservableProperty]
    private Product product;

    public ProductDetailsViewModel(IProductService productService, INavigationService navigationService)
    {
        _productService = productService;
        _navigationService = navigationService;

        SaveProductCommand = new AsyncRelayCommand(SaveProductAsync);
        DeleteProductCommand = new AsyncRelayCommand(DeleteProductAsync);
    }

    public IAsyncRelayCommand SaveProductCommand { get; }
    public IAsyncRelayCommand DeleteProductCommand { get; }

    private async Task SaveProductAsync()
    {
        Debug.WriteLine($"Saving Product: {Product.Name}, {Product.Description}, {Product.Price}");
        if (Product.Id == 0)
        {
            await _productService.AddProductAsync(Product);
        }
        else
        {
            await _productService.UpdateProductAsync(Product);
        }
        await _navigationService.GoBackAsync();
    }
    private async Task DeleteProductAsync()
    {   
        if (Product != null)
        {
            Debug.WriteLine($"Deleting Product: {Product.Name}, {Product.Description}, {Product.Price}");
            await _productService.DeleteProductAsync(Product.Id);
            await _navigationService.GoBackAsync();
        }
    }
}

