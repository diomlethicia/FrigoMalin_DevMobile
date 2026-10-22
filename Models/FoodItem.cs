using SQLite;
using System;

namespace FrigoMalin.Models
{
    [Table("FoodItems")]
    public class FoodItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public string Name { get; set; } = string.Empty;

        public FoodCategory Category { get; set; } = FoodCategory.Divers;

        public double Quantity { get; set; } = 1;

        public string Unit { get; set; } = "pièce(s)";

        public DateTime PurchaseDate { get; set; } = DateTime.Today;

        public DateTime ExpiryDate { get; set; } = DateTime.Today.AddDays(3);

        public decimal EstimatedPrice { get; set; } = 0m;

        public bool IsConsumed { get; set; } = false;

        public bool IsDiscarded { get; set; } = false;

        public string Notes { get; set; } = string.Empty;

        // Propriétés calculées pour l'affichage (non stockées dans SQLite)
        [Ignore]
        public int DaysRemaining => (ExpiryDate.Date - DateTime.Today).Days;

        [Ignore]
        public UrgencyStatus Urgency
        {
            get
            {
                if (DaysRemaining < 0) return UrgencyStatus.Perime;
                if (DaysRemaining <= 2) return UrgencyStatus.Critique;
                if (DaysRemaining <= 5) return UrgencyStatus.Alerte;
                return UrgencyStatus.BonEtat;
            }
        }

        [Ignore]
        public string UrgencyLabel
        {
            get
            {
                return Urgency switch
                {
                    UrgencyStatus.Perime => "PÉRIMÉ",
                    UrgencyStatus.Critique => "TRÈS URGENT",
                    UrgencyStatus.Alerte => "À CONSOMMER",
                    _ => "BON ÉTAT"
                };
            }
        }

        [Ignore]
        public string DaysRemainingText
        {
            get
            {
                if (DaysRemaining < 0)
                    return $"Périmé depuis {Math.Abs(DaysRemaining)} jour(s)";
                if (DaysRemaining == 0)
                    return "Périme AUJOURD'HUI !";
                if (DaysRemaining == 1)
                    return "Périme DEMAIN !";
                return $"Reste {DaysRemaining} jour(s)";
            }
        }

        [Ignore]
        public string CategoryDisplay => Category switch
        {
            FoodCategory.FruitsEtLegumes => "Fruits & Légumes",
            FoodCategory.ProduitsLaitiers => "Produits Laitiers",
            FoodCategory.ViandesEtPoissons => "Viandes & Poissons",
            FoodCategory.PlatsCuisines => "Plats Cuisinés",
            FoodCategory.EpicerieEtFeculents => "Épicerie & Féculents",
            FoodCategory.Surgeles => "Surgelés",
            FoodCategory.Boissons => "Boissons",
            _ => "Divers"
        };
    }
}
