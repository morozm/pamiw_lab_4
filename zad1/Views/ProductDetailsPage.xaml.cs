namespace zad1
{
    public partial class ProductDetailsPage : ContentPage
    {
        public ProductDetailsPage(ProductDetailsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;  // Przypisanie ViewModelu z DI
        }
    }
}
