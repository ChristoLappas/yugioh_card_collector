using Yu_Gi_Oh__Card_Collector.ViewModels;

namespace Yu_Gi_Oh__Card_Collector.Views;

public partial class DecksView : ContentPage
{

	public DecksView(DecksViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;		
		
	}

}