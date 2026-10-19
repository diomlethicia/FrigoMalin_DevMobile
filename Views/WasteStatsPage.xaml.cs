using FrigoMalin.ViewModels;
using Microsoft.Maui.Controls;

namespace FrigoMalin.Views
{
    public partial class WasteStatsPage : ContentPage
    {
        private readonly WasteStatsViewModel _viewModel;

        public WasteStatsPage(WasteStatsViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadStatsCommand.ExecuteAsync(null);
        }
    }
}
