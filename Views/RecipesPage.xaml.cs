using FrigoMalin.ViewModels;
using Microsoft.Maui.Controls;

namespace FrigoMalin.Views
{
    public partial class RecipesPage : ContentPage
    {
        private readonly RecipesViewModel _viewModel;

        public RecipesPage(RecipesViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadDataCommand.ExecuteAsync(null);
        }
    }
}
