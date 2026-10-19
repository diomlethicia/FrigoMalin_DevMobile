using FrigoMalin.ViewModels;
using Microsoft.Maui.Controls;

namespace FrigoMalin.Views
{
    public partial class FoodDetailPage : ContentPage
    {
        public FoodDetailPage(FoodDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
