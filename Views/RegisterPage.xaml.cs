using FrigoMalin.ViewModels;
using Microsoft.Maui.Controls;

namespace FrigoMalin.Views
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage(RegisterViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
