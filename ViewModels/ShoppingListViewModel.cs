using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FrigoMalin.Models;
using FrigoMalin.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace FrigoMalin.ViewModels
{
    public partial class ShoppingListViewModel : ObservableObject
    {
        private readonly IShoppingService _shoppingService;

        [ObservableProperty]
        private ObservableCollection<ShoppingItem> _shoppingItems = new();

        [ObservableProperty]
        private string _newItemName = string.Empty;

        [ObservableProperty]
        private FoodCategory _newItemCategory = FoodCategory.FruitsEtLegumes;

        [ObservableProperty]
        private double _newItemQuantity = 1;

        [ObservableProperty]
        private string _newItemUnit = "kg";

        [ObservableProperty]
        private decimal _newItemPrice = 1500m;

        [ObservableProperty]
        private bool _isBusy;

        // Propriétés de la modale de transfert vers le frigo
        [ObservableProperty]
        private bool _isTransferModalVisible = false;

        [ObservableProperty]
        private ShoppingItem? _selectedItemToTransfer;

        [ObservableProperty]
        private string _transferName = string.Empty;

        [ObservableProperty]
        private FoodCategory _transferCategory;

        [ObservableProperty]
        private double _transferQuantity;

        [ObservableProperty]
        private string _transferUnit = string.Empty;

        [ObservableProperty]
        private DateTime _transferPurchaseDate = DateTime.Today;

        // DATE DE PÉREMPTION SAISIE MANUELLEMENT PAR L'UTILISATEUR DANS LA MODALE
        [ObservableProperty]
        private DateTime _transferManualExpiryDate = DateTime.Today.AddDays(3);

        public List<FoodCategory> Categories => Enum.GetValues(typeof(FoodCategory)).Cast<FoodCategory>().ToList();

        public ShoppingListViewModel(IShoppingService shoppingService)
        {
            _shoppingService = shoppingService;
        }

        [RelayCommand]
        public async Task LoadShoppingItemsAsync()
        {
            if (IsBusy) return;
            try
            {
                IsBusy = true;
                var list = await _shoppingService.GetShoppingItemsAsync();
                ShoppingItems.Clear();
                foreach (var item in list)
                {
                    ShoppingItems.Add(item);
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        public async Task AddItemAsync()
        {
            if (string.IsNullOrWhiteSpace(NewItemName))
            {
                if (Microsoft.Maui.Controls.Application.Current?.MainPage != null)
                {
                    await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert("Champs requis", "Entrez le nom de l'article à acheter.", "OK");
                }
                return;
            }

            var item = new ShoppingItem
            {
                Name = NewItemName.Trim(),
                Category = NewItemCategory,
                Quantity = NewItemQuantity > 0 ? NewItemQuantity : 1,
                Unit = string.IsNullOrWhiteSpace(NewItemUnit) ? "pièce(s)" : NewItemUnit,
                EstimatedPrice = NewItemPrice,
                IsPurchased = false,
                TransferredToFridge = false,
                AddedDate = DateTime.Today
            };

            await _shoppingService.AddShoppingItemAsync(item);
            NewItemName = string.Empty;
            await LoadShoppingItemsAsync();
        }

        // DÉCLENCHÉ LORSQUE L'UTILISATEUR COCHE UN ARTICLE DANS LA CHECKLIST DU MARCHÉ
        [RelayCommand]
        public void OnItemChecked(ShoppingItem item)
        {
            if (item == null) return;

            // Pré-remplissage automatique des informations :
            SelectedItemToTransfer = item;
            TransferName = item.Name;
            TransferCategory = item.Category;
            TransferQuantity = item.Quantity;
            TransferUnit = item.Unit;
            TransferPurchaseDate = DateTime.Today; // Date d'achat automatique = aujourd'hui

            // Date de péremption : Valeur initiale par défaut que l'utilisateur ajuste manuellement
            TransferManualExpiryDate = DateTime.Today.AddDays(4);

            // Ouverture de la modale de validation
            IsTransferModalVisible = true;
        }

        [RelayCommand]
        public async Task ConfirmTransferAsync()
        {
            if (SelectedItemToTransfer == null)
            {
                IsTransferModalVisible = false;
                return;
            }

            // Enregistrement dans le frigo avec la date de péremption manuelle choisie
            await _shoppingService.TransferToFridgeAsync(SelectedItemToTransfer, TransferManualExpiryDate);

            IsTransferModalVisible = false;
            await LoadShoppingItemsAsync();

            if (Microsoft.Maui.Controls.Application.Current?.MainPage != null)
            {
                await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert(
                    "🎉 Transféré au Frigo !",
                    $"'{SelectedItemToTransfer.Name}' a été ajouté au frigo avec la date de péremption du {TransferManualExpiryDate:dd/MM/yyyy}.",
                    "Super");
            }
        }

        [RelayCommand]
        public void CancelTransfer()
        {
            IsTransferModalVisible = false;
            if (SelectedItemToTransfer != null)
            {
                SelectedItemToTransfer.IsPurchased = false;
            }
        }

        [RelayCommand]
        public async Task DeleteItemAsync(ShoppingItem item)
        {
            if (item == null) return;
            await _shoppingService.DeleteShoppingItemAsync(item.Id);
            await LoadShoppingItemsAsync();
        }
    }
}
