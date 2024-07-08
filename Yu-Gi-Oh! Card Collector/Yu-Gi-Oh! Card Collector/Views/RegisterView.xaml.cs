using Yu_Gi_Oh__Card_Collector.ViewModels;

namespace Yu_Gi_Oh__Card_Collector.Views;

public partial class RegisterView : ContentPage
{
	public RegisterView(RegisterViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}