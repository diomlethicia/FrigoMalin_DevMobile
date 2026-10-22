using SQLite;
using System.Collections.Generic;

namespace FrigoMalin.Models
{
    [Table("Recipes")]
    public class Recipe
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Category { get; set; } = "Anti-Gaspi";

        public int PrepTimeMinutes { get; set; } = 20;

        public int Servings { get; set; } = 4;

        public string Description { get; set; } = string.Empty;

        // Ingrédients séparés par des virgules pour le stockage simple SQLite
        public string IngredientsCsv { get; set; } = string.Empty;

        public string Instructions { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        // Propriétés de matching dynamique
        [Ignore]
        public int UrgentIngredientsMatched { get; set; } = 0;

        [Ignore]
        public string AntiWasteBadge => UrgentIngredientsMatched > 0 
            ? $"Sauve {UrgentIngredientsMatched} ingrédient(s) du frigo" 
            : "Recette économique";
    }
}
