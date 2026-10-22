using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FrigoMalin.Models;
using FrigoMalin.Services;
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FrigoMalin.ViewModels
{
    public partial class FoodDetailViewModel : ObservableObject, IQueryAttributable
    {
        private readonly IFoodService _foodService;

        [ObservableProperty]
        private FoodItem? _item;

        [ObservableProperty]
        private string _storageAdvice = string.Empty;

        public FoodDetailViewModel(IFoodService foodService)
        {
            _foodService = foodService;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("FoodItem", out var value) && value is FoodItem food)
            {
                Item = food;
                UpdateStorageAdvice(food.Category);
            }
        }

        private void UpdateStorageAdvice(FoodCategory category)
        {
            StorageAdvice = category switch
            {
                FoodCategory.ViandesEtPoissons => "Zone très froide (0°C à 2°C) : À placer sur la clayette du bas, juste au-dessus du bac à légumes.",
                FoodCategory.ProduitsLaitiers => "Zone fraîche (4°C à 6°C) : À placer sur les étages intermédiaires pour une conservation optimale.",
                FoodCategory.FruitsEtLegumes => "Bac à légumes : Humidité contrôlée, idéal pour éviter le flétrissement des légumes frais.",
                FoodCategory.PlatsCuisines => "Étage supérieur : Bien emballer sous film ou boîte hermétique après complet refroidissement.",
                FoodCategory.Surgeles => "Congélateur (-18°C) : Conserver au congélateur jusqu'à la date limite.",
                _ => "Conserver dans un endroit frais et sec."
            };
        }

        [RelayCommand]
        public async Task MarkConsumedAsync()
        {
            if (Item == null) return;
            await _foodService.MarkAsConsumedAsync(Item.Id);
            if (Application.Current?.MainPage != null)
            {
                await Application.Current.MainPage.DisplayAlert("Bravo !", $"'{Item.Name}' a été marqué comme consommé. Vous avez évité le gaspillage !", "OK");
            }
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        public async Task MarkDiscardedAsync()
        {
            if (Item == null) return;
            await _foodService.MarkAsDiscardedAsync(Item.Id);
            if (Application.Current?.MainPage != null)
            {
                await Application.Current.MainPage.DisplayAlert("Noté", $"'{Item.Name}' a été enregistré comme jeté dans votre bilan.", "OK");
            }
            await Shell.Current.GoToAsync("..");
        }
    }
}
