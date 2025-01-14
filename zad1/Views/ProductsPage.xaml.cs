using Microsoft.Maui.Controls;

namespace zad1
{
    public partial class ProductsPage : ContentPage
    {
        public ProductsPage(ProductsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;  // Przypisanie ViewModelu z DI
        }
    }
}
