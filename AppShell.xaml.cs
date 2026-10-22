using FrigoMalin.Views;
using Microsoft.Maui.Controls;

namespace FrigoMalin
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Enregistrement des routes de navigation
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            Routing.RegisterRoute(nameof(AddEditFoodPage), typeof(AddEditFoodPage));
            Routing.RegisterRoute(nameof(FoodDetailPage), typeof(FoodDetailPage));
            Routing.RegisterRoute(nameof(RecipeDetailPage), typeof(RecipeDetailPage));
        }
    }
}
