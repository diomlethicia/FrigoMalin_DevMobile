namespace FrigoMalin.Models
{
    public enum FoodCategory
    {
        FruitsEtLegumes,
        ProduitsLaitiers,
        ViandesEtPoissons,
        PlatsCuisines,
        EpicerieEtFeculents,
        Surgeles,
        Boissons,
        Divers
    }

    public enum UrgencyStatus
    {
        Perime,     // < 0 jours restants (Rouge foncé)
        Critique,   // 0 à 2 jours restants (Rouge vif)
        Alerte,     // 3 à 5 jours restants (Orange)
        BonEtat     // > 5 jours restants (Vert)
    }

    public enum WasteActionType
    {
        Consomme,   // Consommé à temps (Aliment sauvé, économie réalisée)
        Jete        // Jeté car périmé (Gaspillage, perte financière)
    }

    public enum MealType
    {
        Dejeuner,
        Diner,
        Collation
    }
}
