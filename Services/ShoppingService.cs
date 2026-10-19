using FrigoMalin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrigoMalin.Services
{
    public class ShoppingService : IShoppingService
    {
        private readonly IDatabaseService _dbService;

        public ShoppingService(IDatabaseService dbService)
        {
            _dbService = dbService;
        }

        public async Task<List<ShoppingItem>> GetShoppingItemsAsync()
        {
            var db = await _dbService.GetConnectionAsync();
            var items = await db.Table<ShoppingItem>().ToListAsync();
            // Tri : les articles non encore achetés en premier
            return items.OrderBy(i => i.IsPurchased).ThenByDescending(i => i.Id).ToList();
        }

        public async Task<int> AddShoppingItemAsync(ShoppingItem item)
        {
            var db = await _dbService.GetConnectionAsync();
            return await db.InsertAsync(item);
        }

        public async Task<int> UpdateShoppingItemAsync(ShoppingItem item)
        {
            var db = await _dbService.GetConnectionAsync();
            return await db.UpdateAsync(item);
        }

        public async Task<int> DeleteShoppingItemAsync(int id)
        {
            var db = await _dbService.GetConnectionAsync();
            return await db.DeleteAsync<ShoppingItem>(id);
        }

        public async Task<FoodItem> TransferToFridgeAsync(ShoppingItem item, DateTime manualExpiryDate)
        {
            var db = await _dbService.GetConnectionAsync();

            // Création automatique de l'aliment dans le frigo avec :
            // - Nom auto-rempli
            // - Catégorie auto-remplie
            // - Quantité auto-remplie
            // - Date d'achat auto-remplie (date du jour)
            // - Date de péremption saisie MANUELLEMENT par l'utilisateur
            var foodItem = new FoodItem
            {
                Name = item.Name,
                Category = item.Category,
                Quantity = item.Quantity,
                Unit = item.Unit,
                EstimatedPrice = item.EstimatedPrice,
                PurchaseDate = DateTime.Today,
                ExpiryDate = manualExpiryDate.Date,
                IsConsumed = false,
                IsDiscarded = false,
                Notes = "Acheté au marché via la checklist"
            };

            await db.InsertAsync(foodItem);

            // Mise à jour de l'item dans la checklist
            item.IsPurchased = true;
            item.TransferredToFridge = true;
            await db.UpdateAsync(item);

            return foodItem;
        }
    }
}
