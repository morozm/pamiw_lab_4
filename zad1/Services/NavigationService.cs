namespace zad1.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IServiceProvider _serviceProvider;

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task NavigateToAsync(string pageKey, object parameter = null)
        {
            var pageType = Type.GetType(pageKey);
            if (pageType == null)
            {
                throw new ArgumentException($"Page type '{pageKey}' not found");
            }

            var page = _serviceProvider.GetService(pageType) as Page;
            if (page == null)
            {
                throw new InvalidOperationException($"Could not create page of type {pageType}");
            }

            if (parameter != null)
            {
                page.BindingContext = parameter;
            }

            // Używamy Application.Current, a nie MauiApp.Current
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public async Task GoBackAsync()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
