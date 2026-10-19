using FrigoMalin.Services;
using FrigoMalin.ViewModels;
using FrigoMalin.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

namespace FrigoMalin;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		// 1. SERVICES (Logique Métier & Données SQLite)
		builder.Services.AddSingleton<IDatabaseService, DatabaseService>();
		builder.Services.AddSingleton<IFoodService, FoodService>();
		builder.Services.AddSingleton<IShoppingService, ShoppingService>();
		builder.Services.AddSingleton<IRecipeService, RecipeService>();
		builder.Services.AddSingleton<IWasteService, WasteService>();

		// 2. VIEWMODELS (CommunityToolkit.Mvvm)
		builder.Services.AddTransient<FridgeViewModel>();
		builder.Services.AddTransient<AddEditFoodViewModel>();
		builder.Services.AddTransient<ShoppingListViewModel>();
		builder.Services.AddTransient<RecipesViewModel>();
		builder.Services.AddTransient<WasteStatsViewModel>();

		// 3. VUES (Pages XAML)
		builder.Services.AddTransient<FridgePage>();
		builder.Services.AddTransient<AddEditFoodPage>();
		builder.Services.AddTransient<ShoppingListPage>();
		builder.Services.AddTransient<RecipesPage>();
		builder.Services.AddTransient<WasteStatsPage>();

		return builder.Build();
	}
}
