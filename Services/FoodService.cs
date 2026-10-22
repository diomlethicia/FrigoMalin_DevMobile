using FrigoMalin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrigoMalin.Services
{
    public class FoodService : IFoodService
    {
        private readonly IDatabaseService _dbService;

        public FoodService(IDatabaseService dbService)
        {
            _dbService = dbService;
        }

        public async Task<List<FoodItem>> GetActiveFoodItemsAsync(string? searchQuery = null, FoodCategory? categoryFilter = null)
        {
            var db = await _dbService.GetConnectionAsync();
            var query = db.Table<FoodItem>().Where(f => !f.IsConsumed && !f.IsDiscarded);

            var items = await query.ToListAsync();

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                items = items.Where(f => f.Name.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (categoryFilter.HasValue)
            {
                items = items.Where(f => f.Category == categoryFilter.Value).ToList();
            }

            // Tri par date de péremption la plus proche
            return items.OrderBy(f => f.ExpiryDate).ToList();
        }

        public async Task<List<FoodItem>> GetUrgentFoodItemsAsync()
        {
            var all = await GetActiveFoodItemsAsync();
            return all.Where(f => f.DaysRemaining <= 2).ToList();
        }

        public async Task<FoodItem?> GetFoodItemByIdAsync(int id)
        {
            var db = await _dbService.GetConnectionAsync();
            return await db.Table<FoodItem>().Where(f => f.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> AddFoodItemAsync(FoodItem item)
        {
            var db = await _dbService.GetConnectionAsync();
            return await db.InsertAsync(item);
        }

        public async Task<int> UpdateFoodItemAsync(FoodItem item)
        {
            var db = await _dbService.GetConnectionAsync();
            return await db.UpdateAsync(item);
        }

        public async Task MarkAsConsumedAsync(int id)
        {
            var db = await _dbService.GetConnectionAsync();
            var item = await db.Table<FoodItem>().Where(f => f.Id == id).FirstOrDefaultAsync();
            if (item != null)
            {
                item.IsConsumed = true;
                await db.UpdateAsync(item);

                // Enregistrement dans le bilan anti-gaspillage : aliment sauvé !
                var record = new WasteRecord
                {
                    FoodName = item.Name,
                    Category = item.Category,
                    Quantity = item.Quantity,
                    Unit = item.Unit,
                    EstimatedCost = item.EstimatedPrice,
                    ActionDate = DateTime.Today,
                    ActionType = WasteActionType.Consomme
                };
                await db.InsertAsync(record);
            }
        }

        public async Task MarkAsDiscardedAsync(int id)
        {
            var db = await _dbService.GetConnectionAsync();
            var item = await db.Table<FoodItem>().Where(f => f.Id == id).FirstOrDefaultAsync();
            if (item != null)
            {
                item.IsDiscarded = true;
                await db.UpdateAsync(item);

                // Enregistrement dans le bilan anti-gaspillage : aliment jeté / perte financière
                var record = new WasteRecord
                {
                    FoodName = item.Name,
                    Category = item.Category,
                    Quantity = item.Quantity,
                    Unit = item.Unit,
                    EstimatedCost = item.EstimatedPrice,
                    ActionDate = DateTime.Today,
                    ActionType = WasteActionType.Jete
                };
                await db.InsertAsync(record);
            }
        }

        public async Task<int> DeleteFoodItemAsync(int id)
        {
            var db = await _dbService.GetConnectionAsync();
            return await db.DeleteAsync<FoodItem>(id);
        }
    }
}
