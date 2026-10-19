using SQLite;
using System;

namespace FrigoMalin.Models
{
    [Table("WasteRecords")]
    public class WasteRecord
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string FoodName { get; set; } = string.Empty;

        public FoodCategory Category { get; set; } = FoodCategory.Divers;

        public double Quantity { get; set; } = 1;

        public string Unit { get; set; } = "pièce(s)";

        public decimal EstimatedCost { get; set; } = 0m;

        public DateTime ActionDate { get; set; } = DateTime.Today;

        public WasteActionType ActionType { get; set; } = WasteActionType.Consomme;

        [Ignore]
        public bool IsSaved => ActionType == WasteActionType.Consomme;

        [Ignore]
        public string ActionBadge => IsSaved ? "✅ Sauvé & Consommé" : "🗑️ Gaspillé & Jeté";

        [Ignore]
        public string CostFormatted => $"{EstimatedCost:N0} FCFA";
    }
}
