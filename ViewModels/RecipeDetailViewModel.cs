using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FrigoMalin.Models;
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace FrigoMalin.ViewModels
{
    public partial class RecipeDetailViewModel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        private Recipe? _recipe;

        [ObservableProperty]
        private ObservableCollection<string> _ingredientList = new();

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("Recipe", out var value) && value is Recipe r)
            {
                Recipe = r;
                IngredientList.Clear();
                var items = r.IngredientsCsv.Split(',', System.StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in items)
                {
                    IngredientList.Add(item.Trim());
                }
            }
        }

        [RelayCommand]
        public async Task CookRecipeAsync()
        {
            if (Recipe != null && Application.Current?.MainPage != null)
            {
                await Application.Current.MainPage.DisplayAlert("Bon appétit !", $"Bravo d'avoir préparé '{Recipe.Title}' ! Les aliments de votre frigo ont été sauvés.", "Super !");
                await Shell.Current.GoToAsync("..");
            }
        }
    }
}
