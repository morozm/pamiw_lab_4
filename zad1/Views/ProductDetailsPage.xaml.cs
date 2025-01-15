namespace zad1
{
    public partial class ProductDetailsPage : ContentPage
    {
        public ProductDetailsPage(ProductsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;  // Przypisanie ViewModelu z DI
        }
    }
}
