using FrigoMalin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FrigoMalin.Services
{
    public interface IFoodService
    {
        Task<List<FoodItem>> GetActiveFoodItemsAsync(string? searchQuery = null, FoodCategory? categoryFilter = null);
        Task<List<FoodItem>> GetUrgentFoodItemsAsync();
        Task<FoodItem?> GetFoodItemByIdAsync(int id);
        Task<int> AddFoodItemAsync(FoodItem item);
        Task<int> UpdateFoodItemAsync(FoodItem item);
        Task MarkAsConsumedAsync(int id);
        Task MarkAsDiscardedAsync(int id);
        Task<int> DeleteFoodItemAsync(int id);
    }
}
