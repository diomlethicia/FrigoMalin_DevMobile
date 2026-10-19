using SQLite;
using System;

namespace FrigoMalin.Models
{
    [Table("WeeklyMeals")]
    public class WeeklyMeal
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string DayName { get; set; } = "Lundi"; // Lundi, Mardi, Mercredi...

        public MealType Type { get; set; } = MealType.Dejeuner;

        public string RecipeOrDishName { get; set; } = string.Empty;

        public string KeyIngredients { get; set; } = string.Empty;

        public bool IsCooked { get; set; } = false;

        [Ignore]
        public string MealTypeDisplay => Type switch
        {
            MealType.Dejeuner => "☀️ Déjeuner",
            MealType.Diner => "🌙 Dîner",
            _ => "🍎 Collation"
        };
    }
}
