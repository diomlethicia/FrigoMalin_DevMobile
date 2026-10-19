using FrigoMalin.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FrigoMalin.Services
{
    public interface IShoppingService
    {
        Task<List<ShoppingItem>> GetShoppingItemsAsync();
        Task<int> AddShoppingItemAsync(ShoppingItem item);
        Task<int> UpdateShoppingItemAsync(ShoppingItem item);
        Task<int> DeleteShoppingItemAsync(int id);
        Task<FoodItem> TransferToFridgeAsync(ShoppingItem item, DateTime manualExpiryDate);
    }
}
