using System.Windows.Input;
using Yu_Gi_Oh__Card_Collector.Views;

namespace Yu_Gi_Oh__Card_Collector;

public partial class AppShell : Shell
{

    public ICommand LogoutCommand => new Command(async () =>
    {
        await GoToAsync($"//{nameof(Views.LoginView)}");
    });

    public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(MainView), typeof(MainView));
        Routing.RegisterRoute(nameof(CardsView), typeof(CardsView));
        Routing.RegisterRoute(nameof(LoginView), typeof(LoginView));
        Routing.RegisterRoute(nameof(RegisterView), typeof(RegisterView));
        Routing.RegisterRoute(nameof(DeckDetailsView), typeof(DeckDetailsView));
        Routing.RegisterRoute(nameof(WishListView), typeof(WishListView));
        Routing.RegisterRoute(nameof(SetsView), typeof(SetsView));
        Routing.RegisterRoute(nameof(SettingsView), typeof(SettingsView));

        BindingContext = this;
    }

    
}
