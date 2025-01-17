﻿using CommunityToolkit.Mvvm.ComponentModel;
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
        EditProductCommand = new RelayCommand<Product>(EditProduct);
        DeleteProductCommand = new RelayCommand<Product>(DeleteProduct);
    }

    public IAsyncRelayCommand LoadProductsCommand { get; }
    public RelayCommand AddNewProductCommand { get; }
    public RelayCommand<Product> EditProductCommand { get; }
    public RelayCommand<Product> DeleteProductCommand { get; }

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

    private async void EditProduct(Product product)
    {
        // Tworzymy odpowiednią instancję ViewModelu
        var productDetailsViewModel = new ProductDetailsViewModel(_productService, _navigationService)
        {
            Product = product
        };

        // Nawigujemy do strony ProductDetailsPage, przekazując ViewModel
        await _navigationService.NavigateToAsync("zad1.ProductDetailsPage", productDetailsViewModel);
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

        _productService.AddProductAsync(newProduct);
        Products.Add(newProduct);
    }
    private async void DeleteProduct(Product product)
    {
        if (product != null)
        {
            // Usuwanie produktu z serwisu
            await _productService.DeleteProductAsync(product.Id);

            // Usuwanie produktu z kolekcji, co automatycznie odświeża UI
            Products.Remove(product);
        }
    }
}

