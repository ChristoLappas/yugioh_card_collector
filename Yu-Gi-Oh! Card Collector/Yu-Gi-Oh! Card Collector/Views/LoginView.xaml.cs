using Yu_Gi_Oh__Card_Collector.Services;
using Yu_Gi_Oh__Card_Collector.ViewModels;

namespace Yu_Gi_Oh__Card_Collector.Views;

public partial class LoginView : ContentPage
{
	public LoginView(LoginViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
		
	}
	
}