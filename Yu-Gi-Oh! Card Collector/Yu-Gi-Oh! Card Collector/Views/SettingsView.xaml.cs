using Yu_Gi_Oh__Card_Collector.ViewModels;

namespace Yu_Gi_Oh__Card_Collector.Views;

public partial class SettingsView : ContentPage
{
	public SettingsView(SettingsViewModel vm)
	{
		InitializeComponent();

		BindingContext= vm;
	}
}