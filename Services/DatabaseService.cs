using FrigoMalin.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FrigoMalin.Services
{
    public class DatabaseService : IDatabaseService
    {
        private SQLiteAsyncConnection? _connection;
        private readonly string _dbPath;

        public DatabaseService()
        {
            var folder = FileSystem.AppDataDirectory;
            _dbPath = Path.Combine(folder, "FrigoMalin_v1.db3");
        }

        public async Task<SQLiteAsyncConnection> GetConnectionAsync()
        {
            if (_connection != null)
                return _connection;

            _connection = new SQLiteAsyncConnection(_dbPath, SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.SharedCache);

            await _connection.CreateTableAsync<FoodItem>();
            await _connection.CreateTableAsync<ShoppingItem>();
            await _connection.CreateTableAsync<Recipe>();
            await _connection.CreateTableAsync<WeeklyMeal>();
            await _connection.CreateTableAsync<WasteRecord>();

            // Si la base est neuve, initialiser avec des données de démonstration
            var count = await _connection.Table<FoodItem>().CountAsync();
            if (count == 0)
            {
                await SeedInitialDataAsync(_connection);
            }

            return _connection;
        }

        public async Task ResetAndSeedDataAsync()
        {
            var db = await GetConnectionAsync();
            await db.DropTableAsync<FoodItem>();
            await db.DropTableAsync<ShoppingItem>();
            await db.DropTableAsync<Recipe>();
            await db.DropTableAsync<WeeklyMeal>();
            await db.DropTableAsync<WasteRecord>();

            await db.CreateTableAsync<FoodItem>();
            await db.CreateTableAsync<ShoppingItem>();
            await db.CreateTableAsync<Recipe>();
            await db.CreateTableAsync<WeeklyMeal>();
            await db.CreateTableAsync<WasteRecord>();

            await SeedInitialDataAsync(db);
        }

        private static async Task SeedInitialDataAsync(SQLiteAsyncConnection db)
        {
            var today = DateTime.Today;

            // 1. Aliments du Frigo avec différents degrés d'urgence
            var foodItems = new List<FoodItem>
            {
                // CRITIQUE / URGENT (<= 2 jours)
                new() {
                    Name = "Lait demi-écrémé",
                    Category = FoodCategory.ProduitsLaitiers,
                    Quantity = 1,
                    Unit = "Bouteille 1L",
                    PurchaseDate = today.AddDays(-5),
                    ExpiryDate = today.AddDays(1), // Demain !
                    EstimatedPrice = 1200m
                },
                new() {
                    Name = "Filets de Poulet frais",
                    Category = FoodCategory.ViandesEtPoissons,
                    Quantity = 500,
                    Unit = "g",
                    PurchaseDate = today.AddDays(-2),
                    ExpiryDate = today.AddDays(0), // Aujourd'hui !
                    EstimatedPrice = 3500m
                },
                // ALERTE / À CONSOMMER (3 à 5 jours)
                new() {
                    Name = "Tomates fraîches",
                    Category = FoodCategory.FruitsEtLegumes,
                    Quantity = 6,
                    Unit = "pièces",
                    PurchaseDate = today.AddDays(-2),
                    ExpiryDate = today.AddDays(3),
                    EstimatedPrice = 1500m
                },
                new() {
                    Name = "Yaourts nature",
                    Category = FoodCategory.ProduitsLaitiers,
                    Quantity = 4,
                    Unit = "pots",
                    PurchaseDate = today.AddDays(-3),
                    ExpiryDate = today.AddDays(4),
                    EstimatedPrice = 1800m
                },
                // BON ÉTAT (> 5 jours)
                new() {
                    Name = "Carottes",
                    Category = FoodCategory.FruitsEtLegumes,
                    Quantity = 1,
                    Unit = "kg",
                    PurchaseDate = today,
                    ExpiryDate = today.AddDays(10),
                    EstimatedPrice = 800m
                },
                new() {
                    Name = "Fromage Gouda",
                    Category = FoodCategory.ProduitsLaitiers,
                    Quantity = 250,
                    Unit = "g",
                    PurchaseDate = today,
                    ExpiryDate = today.AddDays(14),
                    EstimatedPrice = 2200m
                },
                new() {
                    Name = "Poisson Capitaine surgelé",
                    Category = FoodCategory.Surgeles,
                    Quantity = 1,
                    Unit = "kg",
                    PurchaseDate = today.AddDays(-10),
                    ExpiryDate = today.AddDays(60),
                    EstimatedPrice = 4500m
                }
            };
            await db.InsertAllAsync(foodItems);

            // 2. Liste de Marché (Checklist de courses)
            var shoppingItems = new List<ShoppingItem>
            {
                new() { Name = "Œufs frais", Category = FoodCategory.ProduitsLaitiers, Quantity = 12, Unit = "pièces", EstimatedPrice = 1500m, IsPurchased = false },
                new() { Name = "Bananes mûres", Category = FoodCategory.FruitsEtLegumes, Quantity = 1, Unit = "régime", EstimatedPrice = 1000m, IsPurchased = false },
                new() { Name = "Viande hachée de bœuf", Category = FoodCategory.ViandesEtPoissons, Quantity = 500, Unit = "g", EstimatedPrice = 3000m, IsPurchased = false },
                new() { Name = "Riz parfumé", Category = FoodCategory.EpicerieEtFeculents, Quantity = 5, Unit = "kg", EstimatedPrice = 4000m, IsPurchased = true, TransferredToFridge = true },
                new() { Name = "Jus d'orange pressé", Category = FoodCategory.Boissons, Quantity = 1, Unit = "L", EstimatedPrice = 1200m, IsPurchased = false }
            };
            await db.InsertAllAsync(shoppingItems);

            // 3. Recettes Anti-Gaspi
            var recipes = new List<Recipe>
            {
                new() {
                    Title = "Omelette Gourmande aux Tomates & Restes",
                    Category = "Anti-Gaspi Rapide",
                    PrepTimeMinutes = 15,
                    Servings = 2,
                    Description = "Parfait pour utiliser les œufs, tomates bien mûres et restes de fromage avant qu'ils ne s'abîment.",
                    IngredientsCsv = "Œufs, Tomates, Fromage, Sel, Poivre, Huile",
                    Instructions = "1. Battre les œufs dans un bol avec une pincée de sel.\n2. Couper les tomates et le fromage en petits dés.\n3. Faire chauffer la poêle avec un filet d'huile, verser les œufs puis ajouter les dés de tomates et fromage.\n4. Laisser cuire 5 à 7 minutes à feu doux."
                },
                new() {
                    Title = "Poêlée Express Poulet & Légumes du Frigo",
                    Category = "Anti-Gaspi Poulet",
                    PrepTimeMinutes = 20,
                    Servings = 3,
                    Description = "Une recette simple et saine pour cuisiner vos filets de poulet et tous les légumes qui flétrissent au fond du bac.",
                    IngredientsCsv = "Poulet, Carottes, Tomates, Oignon, Épices",
                    Instructions = "1. Découper le poulet en émincés et éplucher les carottes en fines lamelles.\n2. Faire dorer le poulet dans une sauteuse 5 minutes.\n3. Ajouter les carottes, tomates émincées et laisser mijoter 12 minutes à couvert."
                },
                new() {
                    Title = "Gratin Moelleux Anti-Gaspi au Lait & Légumes",
                    Category = "Four / Économique",
                    PrepTimeMinutes = 30,
                    Servings = 4,
                    Description = "Idéal pour écouler une bouteille de lait entamée et des légumes avant leur date de péremption.",
                    IngredientsCsv = "Lait demi-écrémé, Pommes de terre, Fromage, Carottes",
                    Instructions = "1. Préchauffer le four à 180°C.\n2. Disposer les légumes coupés en rondelles dans un plat à gratin.\n3. Verser le lait mélangé avec un peu de sel et muscade.\n4. Parsemer de fromage et enfourner pour 25 minutes."
                }
            };
            await db.InsertAllAsync(recipes);

            // 4. Menus de la Semaine
            var weeklyMeals = new List<WeeklyMeal>
            {
                new() { DayName = "Lundi", Type = MealType.Dejeuner, RecipeOrDishName = "Poêlée Poulet & Carottes", KeyIngredients = "Poulet (urgent), Carottes", IsCooked = true },
                new() { DayName = "Lundi", Type = MealType.Diner, RecipeOrDishName = "Omelette Tomates & Fromage", KeyIngredients = "Tomates, Fromage, Œufs", IsCooked = false },
                new() { DayName = "Mardi", Type = MealType.Dejeuner, RecipeOrDishName = "Poisson Capitaine & Riz sauté", KeyIngredients = "Poisson surgelé, Riz", IsCooked = false },
                new() { DayName = "Mardi", Type = MealType.Diner, RecipeOrDishName = "Gratin de Légumes au Lait", KeyIngredients = "Lait, Légumes variés", IsCooked = false },
                new() { DayName = "Mercredi", Type = MealType.Dejeuner, RecipeOrDishName = "Salade composée anti-gaspi", KeyIngredients = "Tomates, Fromage, Yaourt sauce", IsCooked = false }
            };
            await db.InsertAllAsync(weeklyMeals);

            // 5. Historique du Bilan Anti-Gaspi
            var wasteRecords = new List<WasteRecord>
            {
                new() { FoodName = "Pain de mie", Category = FoodCategory.EpicerieEtFeculents, Quantity = 1, Unit = "sachet", EstimatedCost = 800m, ActionDate = today.AddDays(-6), ActionType = WasteActionType.Consomme },
                new() { FoodName = "Crème fraîche", Category = FoodCategory.ProduitsLaitiers, Quantity = 1, Unit = "pot", EstimatedCost = 1100m, ActionDate = today.AddDays(-4), ActionType = WasteActionType.Consomme },
                new() { FoodName = "Salade verte flétrie", Category = FoodCategory.FruitsEtLegumes, Quantity = 1, Unit = "pièce", EstimatedCost = 500m, ActionDate = today.AddDays(-3), ActionType = WasteActionType.Jete },
                new() { FoodName = "Pommes rouges", Category = FoodCategory.FruitsEtLegumes, Quantity = 4, Unit = "pièces", EstimatedCost = 1200m, ActionDate = today.AddDays(-1), ActionType = WasteActionType.Consomme }
            };
            await db.InsertAllAsync(wasteRecords);
        }
    }
}
