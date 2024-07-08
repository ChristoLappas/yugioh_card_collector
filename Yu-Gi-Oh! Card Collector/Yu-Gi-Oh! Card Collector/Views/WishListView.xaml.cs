using Yu_Gi_Oh__Card_Collector.ViewModels;

namespace Yu_Gi_Oh__Card_Collector.Views;

public partial class WishListView : ContentPage
{
	public WishListView(WishListViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}