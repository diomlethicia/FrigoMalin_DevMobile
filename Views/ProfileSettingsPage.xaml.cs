using FrigoMalin.ViewModels;
using Microsoft.Maui.Controls;

namespace FrigoMalin.Views
{
    public partial class ProfileSettingsPage : ContentPage
    {
        private readonly ProfileSettingsViewModel _viewModel;

        public ProfileSettingsPage(ProfileSettingsViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.LoadProfile();
        }
    }
}
