using CommunityToolkit.Maui;
using SkiaSharp.Views.Maui.Controls.Hosting;
using Yu_Gi_Oh__Card_Collector.Converters;
using Yu_Gi_Oh__Card_Collector.Services;
using Yu_Gi_Oh__Card_Collector.ViewModels;
using Yu_Gi_Oh__Card_Collector.Views;
using SkiaSharp.Views.Maui.Controls.Hosting;
namespace Yu_Gi_Oh__Card_Collector;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().UseMauiCommunityToolkit();


        builder
            .UseMauiApp<App>()
            .UseSkiaSharp()
            .ConfigureFonts(fonts =>
			{
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("PaladinFLF.ttf", "Paladin");
                fonts.AddFont("Begok v15_2015___free.ttf", "Begok");
                fonts.AddFont("Epilogue-VariableFont_wght.ttf", "Epilogue");
			});

		builder.Services.AddTransient<CardsService>();
        builder.Services.AddTransient<LoginService>();
        builder.Services.AddTransient<DeckDetailsService>();
        builder.Services.AddTransient<WishListService>();
        builder.Services.AddTransient<SetsService>();


        builder.Services.AddTransient<CardsViewModel>();
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<RegisterViewModel>();
        builder.Services.AddTransient<DecksViewModel>();
        builder.Services.AddTransient<DeckDetailsViewModel>();
        builder.Services.AddTransient<WishListViewModel>();
        builder.Services.AddTransient<SetsViewModel>();
        builder.Services.AddTransient<SettingsViewModel>();

        builder.Services.AddTransient<MainView>();
        builder.Services.AddTransient<CardsView>();
        builder.Services.AddTransient<LoginView>();
        builder.Services.AddTransient<RegisterView>();
        builder.Services.AddTransient<DecksView>();
        builder.Services.AddTransient<DeckDetailsView>();
        builder.Services.AddTransient<WishListView>();
        builder.Services.AddTransient<SetsView>();
        builder.Services.AddTransient<SettingsView>();

        



        return builder.Build();
	}
}
