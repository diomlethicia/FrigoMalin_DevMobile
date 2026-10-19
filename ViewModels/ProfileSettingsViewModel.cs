using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FrigoMalin.Services;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace FrigoMalin.ViewModels
{
    public partial class ProfileSettingsViewModel : ObservableObject
    {
        private readonly IAuthService _authService;
        private readonly IDatabaseService _dbService;

        [ObservableProperty]
        private string _userName = string.Empty;

        [ObservableProperty]
        private string _userEmail = string.Empty;

        [ObservableProperty]
        private int _householdSize = 3;

        [ObservableProperty]
        private int _notificationDaysBefore = 2;

        public ProfileSettingsViewModel(IAuthService authService, IDatabaseService dbService)
        {
            _authService = authService;
            _dbService = dbService;
            LoadProfile();
        }

        public void LoadProfile()
        {
            UserName = _authService.CurrentUserName;
            UserEmail = _authService.CurrentUserEmail;
            HouseholdSize = _authService.HouseholdSize;
            NotificationDaysBefore = _authService.NotificationDaysBefore;
        }

        [RelayCommand]
        public async Task SaveSettingsAsync()
        {
            _authService.UpdateSettings(HouseholdSize, NotificationDaysBefore);
            if (Application.Current?.MainPage != null)
            {
                await Application.Current.MainPage.DisplayAlert("Paramètres enregistrés", $"Vos alertes vous préviendront désormais {NotificationDaysBefore} jours avant péremption.", "OK");
            }
        }

        [RelayCommand]
        public async Task ResetDemoDataAsync()
        {
            if (Application.Current?.MainPage != null)
            {
                bool confirm = await Application.Current.MainPage.DisplayAlert("Réinitialiser", "Voulez-vous recharger les données de démonstration du projet ?", "Oui, Réinitialiser", "Annuler");
                if (confirm)
                {
                    await _dbService.ResetAndSeedDataAsync();
                    await Application.Current.MainPage.DisplayAlert("Succès", "Données de démo réinitialisées !", "OK");
                }
            }
        }

        [RelayCommand]
        public async Task LogoutAsync()
        {
            await _authService.LogoutAsync();
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
