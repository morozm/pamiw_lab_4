namespace zad1.Services
{
    public interface INavigationService
    {
        Task NavigateToAsync(string pageKey, object parameter = null);
        Task GoBackAsync();
    }
}
