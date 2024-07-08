using Yu_Gi_Oh__Card_Collector.ViewModels;

namespace Yu_Gi_Oh__Card_Collector.Views;

public partial class DeckDetailsView : ContentPage
{
	public DeckDetailsView(DeckDetailsViewModel vm)
	{
		InitializeComponent();

		BindingContext= vm;
	}
}