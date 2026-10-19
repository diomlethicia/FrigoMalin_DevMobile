using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FrigoMalin.Models;
using FrigoMalin.Services;
using FrigoMalin.Views;
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FrigoMalin.ViewModels
{
    public partial class RecipesViewModel : ObservableObject
    {
        private readonly IRecipeService _recipeService;

        [ObservableProperty]
        private ObservableCollection<Recipe> _recipes = new();

        [ObservableProperty]
        private ObservableCollection<WeeklyMeal> _weeklyMeals = new();

        [ObservableProperty]
        private bool _isBusy;

        [ObservableProperty]
        private bool _showRecipesView = true;

        [ObservableProperty]
        private bool _showMenusView = false;

        public RecipesViewModel(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [RelayCommand]
        public void SwitchTab(string tabName)
        {
            if (tabName == "Menus")
            {
                ShowRecipesView = false;
                ShowMenusView = true;
            }
            else
            {
                ShowRecipesView = true;
                ShowMenusView = false;
            }
        }

        [RelayCommand]
        public async Task LoadDataAsync()
        {
            if (IsBusy) return;
            try
            {
                IsBusy = true;

                // 1. Recettes avec scoring d'urgence anti-gaspillage
                var recipeList = await _recipeService.GetRecipesWithUrgencyMatchingAsync();
                Recipes.Clear();
                foreach (var r in recipeList)
                {
                    Recipes.Add(r);
                }

                // 2. Menus de la semaine
                var mealsList = await _recipeService.GetWeeklyMealsAsync();
                WeeklyMeals.Clear();
                foreach (var m in mealsList)
                {
                    WeeklyMeals.Add(m);
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        public async Task ToggleMealCookedAsync(WeeklyMeal meal)
        {
            if (meal == null) return;
            await _recipeService.ToggleMealCookedAsync(meal.Id);
            await LoadDataAsync();
        }

        [RelayCommand]
        public async Task ViewRecipeDetailsAsync(Recipe recipe)
        {
            if (recipe == null) return;

            await Shell.Current.GoToAsync(nameof(RecipeDetailPage), new Dictionary<string, object>
            {
                { "Recipe", recipe }
            });
        }
    }
}
