using FrigoMalin.Models;
using FrigoMalin.ViewModels;
using Microsoft.Maui.Controls;

namespace FrigoMalin.Views
{
    public partial class ShoppingListPage : ContentPage
    {
        private readonly ShoppingListViewModel _viewModel;

        public ShoppingListPage(ShoppingListViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadShoppingItemsCommand.ExecuteAsync(null);
        }

        private void OnItemCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value && sender is CheckBox checkBox && checkBox.BindingContext is ShoppingItem item)
            {
                // Si l'utilisateur vient de cocher l'article, ouvrir la modale de transfert
                _viewModel.OnItemChecked(item);
            }
        }
    }
}
