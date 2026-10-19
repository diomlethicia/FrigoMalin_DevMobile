using SQLite;
using System;

namespace FrigoMalin.Models
{
    [Table("ShoppingItems")]
    public class ShoppingItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public string Name { get; set; } = string.Empty;

        public FoodCategory Category { get; set; } = FoodCategory.Divers;

        public double Quantity { get; set; } = 1;

        public string Unit { get; set; } = "pièce(s)";

        public decimal EstimatedPrice { get; set; } = 0m;

        public bool IsPurchased { get; set; } = false;

        public bool TransferredToFridge { get; set; } = false;

        public DateTime AddedDate { get; set; } = DateTime.Today;

        [Ignore]
        public string CategoryDisplay => Category switch
        {
            FoodCategory.FruitsEtLegumes => "🥦 Fruits & Légumes",
            FoodCategory.ProduitsLaitiers => "🧀 Produits Laitiers",
            FoodCategory.ViandesEtPoissons => "🥩 Viandes & Poissons",
            FoodCategory.PlatsCuisines => "🍲 Plats Cuisinés",
            FoodCategory.EpicerieEtFeculents => "🌾 Épicerie & Féculents",
            FoodCategory.Surgeles => "❄️ Surgelés",
            FoodCategory.Boissons => "🧃 Boissons",
            _ => "📦 Divers"
        };
    }
}
