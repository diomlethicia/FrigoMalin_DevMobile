using FrigoMalin.Views;
using Microsoft.Maui.Controls;

namespace FrigoMalin
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Enregistrement de la route de navigation pour l'ajout d'aliment
            Routing.RegisterRoute(nameof(AddEditFoodPage), typeof(AddEditFoodPage));
        }
    }
}
