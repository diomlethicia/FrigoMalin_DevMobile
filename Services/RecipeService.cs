using FrigoMalin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrigoMalin.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IDatabaseService _dbService;
        private readonly IFoodService _foodService;

        public RecipeService(IDatabaseService dbService, IFoodService foodService)
        {
            _dbService = dbService;
            _foodService = foodService;
        }

        public async Task<List<Recipe>> GetRecipesWithUrgencyMatchingAsync()
        {
            var db = await _dbService.GetConnectionAsync();
            var recipes = await db.Table<Recipe>().ToListAsync();

            // Récupérer les aliments critiques ou en alerte du frigo (<= 5 jours)
            var activeFoods = await _foodService.GetActiveFoodItemsAsync();
            var expiringFoods = activeFoods.Where(f => f.DaysRemaining <= 5).Select(f => f.Name.ToLowerInvariant()).ToList();

            foreach (var recipe in recipes)
            {
                int matchScore = 0;
                var ingredients = recipe.IngredientsCsv.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                                      .Select(i => i.Trim().ToLowerInvariant());

                foreach (var ingredient in ingredients)
                {
                    // Si un ingrédient de la recette est présent dans nos aliments qui vont bientôt périmer
                    if (expiringFoods.Any(food => food.Contains(ingredient) || ingredient.Contains(food)))
                    {
                        matchScore++;
                    }
                }
                recipe.UrgentIngredientsMatched = matchScore;
            }

            // Tri par score d'urgence décroissant : les recettes qui sauvent le plus d'aliments en premier
            return recipes.OrderByDescending(r => r.UrgentIngredientsMatched).ThenBy(r => r.PrepTimeMinutes).ToList();
        }

        public async Task<List<WeeklyMeal>> GetWeeklyMealsAsync()
        {
            var db = await _dbService.GetConnectionAsync();
            var meals = await db.Table<WeeklyMeal>().ToListAsync();
            // Ordre logique des jours
            var daysOrder = new List<string> { "Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi", "Dimanche" };
            return meals.OrderBy(m => daysOrder.IndexOf(m.DayName)).ThenBy(m => m.Type).ToList();
        }

        public async Task<int> AddWeeklyMealAsync(WeeklyMeal meal)
        {
            var db = await _dbService.GetConnectionAsync();
            return await db.InsertAsync(meal);
        }

        public async Task<int> ToggleMealCookedAsync(int mealId)
        {
            var db = await _dbService.GetConnectionAsync();
            var meal = await db.Table<WeeklyMeal>().Where(m => m.Id == mealId).FirstOrDefaultAsync();
            if (meal != null)
            {
                meal.IsCooked = !meal.IsCooked;
                return await db.UpdateAsync(meal);
            }
            return 0;
        }

        public async Task<int> AddRecipeAsync(Recipe recipe)
        {
            var db = await _dbService.GetConnectionAsync();
            return await db.InsertAsync(recipe);
        }
    }
}
