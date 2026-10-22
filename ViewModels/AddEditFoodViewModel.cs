using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FrigoMalin.Models;
using FrigoMalin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrigoMalin.ViewModels
{
    public partial class AddEditFoodViewModel : ObservableObject
    {
        private readonly IFoodService _foodService;

        [ObservableProperty]
        private string _name = string.Empty;

        [ObservableProperty]
        private FoodCategory _selectedCategory = FoodCategory.FruitsEtLegumes;

        [ObservableProperty]
        private double _quantity = 1;

        [ObservableProperty]
        private string _unit = "pièce(s)";

        [ObservableProperty]
        private decimal _estimatedPrice = 1000m;

        [ObservableProperty]
        private DateTime _purchaseDate = DateTime.Today;

        [ObservableProperty]
        private DateTime _expiryDate = DateTime.Today.AddDays(4);

        [ObservableProperty]
        private string _notes = string.Empty;

        public List<FoodCategory> Categories => Enum.GetValues(typeof(FoodCategory)).Cast<FoodCategory>().ToList();

        public AddEditFoodViewModel(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [RelayCommand]
        public async Task SaveAsync()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                if (Microsoft.Maui.Controls.Application.Current?.MainPage != null)
                {
                    await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert("Champs requis", "Veuillez entrer le nom de l'aliment.", "OK");
                }
                return;
            }

            var item = new FoodItem
            {
                Name = Name.Trim(),
                Category = SelectedCategory,
                Quantity = Quantity > 0 ? Quantity : 1,
                Unit = string.IsNullOrWhiteSpace(Unit) ? "pièce(s)" : Unit,
                EstimatedPrice = EstimatedPrice >= 0 ? EstimatedPrice : 0,
                PurchaseDate = PurchaseDate,
                ExpiryDate = ExpiryDate.Date, // Date manuelle
                Notes = Notes
            };

            await _foodService.AddFoodItemAsync(item);

            if (Microsoft.Maui.Controls.Application.Current?.MainPage != null)
            {
                await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert("Succès", $"'{item.Name}' a été ajouté au frigo !", "OK");
                await Microsoft.Maui.Controls.Shell.Current.GoToAsync("..");
            }
        }
    }
}
