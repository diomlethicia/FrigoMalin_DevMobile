using FrigoMalin.ViewModels;
using Microsoft.Maui.Controls;
using System;

namespace FrigoMalin.Views
{
    public partial class FridgePage : ContentPage
    {
        private readonly FridgeViewModel _viewModel;

        public FridgePage(FridgeViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadItemsCommand.ExecuteAsync(null);
        }

        private async void OnAddFoodClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(AddEditFoodPage));
        }
    }
}
