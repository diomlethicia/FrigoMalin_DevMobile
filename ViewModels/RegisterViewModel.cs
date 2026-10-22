using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FrigoMalin.Services;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace FrigoMalin.ViewModels
{
    public partial class RegisterViewModel : ObservableObject
    {
        private readonly IAuthService _authService;

        [ObservableProperty]
        private string _fullName = string.Empty;

        [ObservableProperty]
        private string _email = string.Empty;

        [ObservableProperty]
        private string _password = string.Empty;

        [ObservableProperty]
        private int _householdSize = 2;

        [ObservableProperty]
        private bool _isBusy;

        [ObservableProperty]
        private string _errorMessage = string.Empty;

        public RegisterViewModel(IAuthService authService)
        {
            _authService = authService;
        }

        [RelayCommand]
        public async Task RegisterAsync()
        {
            if (string.IsNullOrWhiteSpace(FullName) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage = "Veuillez remplir tous les champs obligatoires.";
                return;
            }

            IsBusy = true;
            ErrorMessage = string.Empty;

            var success = await _authService.RegisterAsync(FullName, Email, Password, HouseholdSize);
            IsBusy = false;

            if (success)
            {
                if (Application.Current?.MainPage != null)
                {
                    await Application.Current.MainPage.DisplayAlert("Compte créé !", "Bienvenue sur FrigoMalin ! Vous êtes maintenant connecté.", "Continuer");
                }
                await Shell.Current.GoToAsync("//FridgePage");
            }
            else
            {
                ErrorMessage = "Impossible de créer le compte. Veuillez vérifier vos données.";
            }
        }

        [RelayCommand]
        public async Task NavigateBackToLoginAsync()
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
