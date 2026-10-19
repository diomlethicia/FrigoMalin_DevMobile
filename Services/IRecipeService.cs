using FrigoMalin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FrigoMalin.Services
{
    public interface IRecipeService
    {
        Task<List<Recipe>> GetRecipesWithUrgencyMatchingAsync();
        Task<List<WeeklyMeal>> GetWeeklyMealsAsync();
        Task<int> AddWeeklyMealAsync(WeeklyMeal meal);
        Task<int> ToggleMealCookedAsync(int mealId);
        Task<int> AddRecipeAsync(Recipe recipe);
    }
}
