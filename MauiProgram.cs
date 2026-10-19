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

		// 1. SERVICES (Logique Métier, Données SQLite & Authentification)
		builder.Services.AddSingleton<IAuthService, AuthService>();
		builder.Services.AddSingleton<IDatabaseService, DatabaseService>();
		builder.Services.AddSingleton<IFoodService, FoodService>();
		builder.Services.AddSingleton<IShoppingService, ShoppingService>();
		builder.Services.AddSingleton<IRecipeService, RecipeService>();
		builder.Services.AddSingleton<IWasteService, WasteService>();

		// 2. VIEWMODELS (MVVM - CommunityToolkit.Mvvm)
		builder.Services.AddTransient<LoginViewModel>();
		builder.Services.AddTransient<RegisterViewModel>();
		builder.Services.AddTransient<FridgeViewModel>();
		builder.Services.AddTransient<AddEditFoodViewModel>();
		builder.Services.AddTransient<FoodDetailViewModel>();
		builder.Services.AddTransient<ShoppingListViewModel>();
		builder.Services.AddTransient<RecipesViewModel>();
		builder.Services.AddTransient<RecipeDetailViewModel>();
		builder.Services.AddTransient<WasteStatsViewModel>();
		builder.Services.AddTransient<ProfileSettingsViewModel>();

		// 3. VUES (Les 10 Interfaces de l'application)
		builder.Services.AddTransient<LoginPage>();
		builder.Services.AddTransient<RegisterPage>();
		builder.Services.AddTransient<FridgePage>();
		builder.Services.AddTransient<AddEditFoodPage>();
		builder.Services.AddTransient<FoodDetailPage>();
		builder.Services.AddTransient<ShoppingListPage>();
		builder.Services.AddTransient<RecipesPage>();
		builder.Services.AddTransient<RecipeDetailPage>();
		builder.Services.AddTransient<WasteStatsPage>();
		builder.Services.AddTransient<ProfileSettingsPage>();

		return builder.Build();
	}
}
