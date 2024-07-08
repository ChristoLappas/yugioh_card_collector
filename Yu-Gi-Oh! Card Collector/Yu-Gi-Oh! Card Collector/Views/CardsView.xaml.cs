using Yu_Gi_Oh__Card_Collector.ViewModels;

namespace Yu_Gi_Oh__Card_Collector.Views;

public partial class CardsView : ContentPage
{
	Picker picker = new Picker();
	public CardsView(CardsViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;   
        

    }   
}
