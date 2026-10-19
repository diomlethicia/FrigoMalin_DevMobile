using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FrigoMalin.Models;
using FrigoMalin.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FrigoMalin.ViewModels
{
    public partial class FridgeViewModel : ObservableObject
    {
        private readonly IFoodService _foodService;

        [ObservableProperty]
        private ObservableCollection<FoodItem> _foodItems = new();

        [ObservableProperty]
        private int _urgentCount;

        [ObservableProperty]
        private bool _hasUrgentItems;

        [ObservableProperty]
        private string _urgentAlertText = string.Empty;

        [ObservableProperty]
        private string _searchText = string.Empty;

        [ObservableProperty]
        private bool _isBusy;

        public FridgeViewModel(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [RelayCommand]
        public async Task LoadItemsAsync()
        {
            if (IsBusy) return;
            try
            {
                IsBusy = true;
                var list = await _foodService.GetActiveFoodItemsAsync(SearchText);
                FoodItems.Clear();
                foreach (var item in list)
                {
                    FoodItems.Add(item);
                }

                var urgentList = await _foodService.GetUrgentFoodItemsAsync();
                UrgentCount = urgentList.Count;
                HasUrgentItems = UrgentCount > 0;
                UrgentAlertText = UrgentCount > 0 
                    ? $"⚠️ Attention : {UrgentCount} aliment(s) à consommer en urgence !" 
                    : "✨ Aucun aliment critique pour l'instant !";
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        public async Task SearchAsync()
        {
            await LoadItemsAsync();
        }

        [RelayCommand]
        public async Task MarkConsumedAsync(FoodItem item)
        {
            if (item == null) return;
            await _foodService.MarkAsConsumedAsync(item.Id);
            await LoadItemsAsync();
        }

        [RelayCommand]
        public async Task MarkDiscardedAsync(FoodItem item)
        {
            if (item == null) return;
            await _foodService.MarkAsDiscardedAsync(item.Id);
            await LoadItemsAsync();
        }

        [RelayCommand]
        public async Task DeleteItemAsync(FoodItem item)
        {
            if (item == null) return;
            await _foodService.DeleteFoodItemAsync(item.Id);
            await LoadItemsAsync();
        }
    }
}
