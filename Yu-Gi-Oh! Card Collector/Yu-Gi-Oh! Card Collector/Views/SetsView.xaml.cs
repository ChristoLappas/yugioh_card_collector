using Yu_Gi_Oh__Card_Collector.ViewModels;

namespace Yu_Gi_Oh__Card_Collector.Views;

public partial class SetsView : ContentPage
{
	public SetsView(SetsViewModel vm)
	{
		InitializeComponent();

		BindingContext= vm;
        
    }
}