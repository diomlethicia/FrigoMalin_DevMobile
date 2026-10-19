using FrigoMalin.ViewModels;
using Microsoft.Maui.Controls;

namespace FrigoMalin.Views
{
    public partial class AddEditFoodPage : ContentPage
    {
        public AddEditFoodPage(AddEditFoodViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
