using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FrigoMalin.Services;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace FrigoMalin.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly IAuthService _authService;

        [ObservableProperty]
        private string _email = "lucraine.fien@univ.edu";

        [ObservableProperty]
        private string _password = "Password123!";

        [ObservableProperty]
        private bool _rememberMe = true;

        [ObservableProperty]
        private bool _isBusy;

        [ObservableProperty]
        private string _errorMessage = string.Empty;

        public LoginViewModel(IAuthService authService)
        {
            _authService = authService;
        }

        [RelayCommand]
        public async Task LoginAsync()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage = "Veuillez renseigner votre email et mot de passe.";
                return;
            }

            IsBusy = true;
            ErrorMessage = string.Empty;

            var success = await _authService.LoginAsync(Email, Password);
            IsBusy = false;

            if (success)
            {
                // Navigation vers la page d'accueil (TabBar Frigo)
                await Shell.Current.GoToAsync("//FridgePage");
            }
            else
            {
                ErrorMessage = "Identifiants invalides. Veuillez réessayer.";
            }
        }

        [RelayCommand]
        public async Task DemoLoginAsync()
        {
            Email = "lucraine.fien@univ.edu";
            Password = "Password123!";
            await LoginAsync();
        }

        [RelayCommand]
        public async Task NavigateToRegisterAsync()
        {
            await Shell.Current.GoToAsync("RegisterPage");
        }
    }
}
