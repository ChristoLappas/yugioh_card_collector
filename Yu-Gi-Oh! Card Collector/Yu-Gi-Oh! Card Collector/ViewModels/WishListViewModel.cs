using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yu_Gi_Oh__Card_Collector.Models;
using Yu_Gi_Oh__Card_Collector.Services;

namespace Yu_Gi_Oh__Card_Collector.ViewModels
{
    [INotifyPropertyChanged]
    public partial class WishListViewModel
    {
        private WishListService wishListService;
        [ObservableProperty]
        private List<Card> wishListCardsAPI;
        [ObservableProperty]
        private string price;
        [ObservableProperty]
        private string currency;
        public WishListViewModel(WishListService wls)
        {
            wishListService = wls;
        }

        [RelayCommand]
        async Task GetWishList()
        {
            var wishListCards = await YuGiOhDatabase.GetWishListCards(LoginDetails.Id);

            var wishCardListAPI = await wishListService.GetCards(wishListCards);

            WishListCardsAPI = wishCardListAPI;

            await CalculatePrice(wishListCardsAPI);


        }


        [RelayCommand]
        async Task DeleteFromWishList(string name)
        {
            var allWishList = await YuGiOhDatabase.GetWishListCards(LoginDetails.Id);

            for (int i = 0; i < allWishList.Count; i++)
            {
                if (allWishList[i].Name == name)
                    await YuGiOhDatabase.DeleteWishlistCard(allWishList[i].Id);
            }

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            string text = "Card successfully deleted!";
            ToastDuration duration = ToastDuration.Short;
            double fontSize = 17;
            var toast = Toast.Make(text, duration, fontSize);
            await toast.Show(cancellationTokenSource.Token);


            await GetWishList();
        }

        [RelayCommand]
        public async Task CalculatePrice(List<Card> cards)
        {
            double sum = 0;

            foreach (Card c in cards)
            {
                sum += double.Parse(c.CardPrices[0].CardmarketPrice);

            }

            if (Preferences.Default.Get("euro", true))
            {
                Price = $"Total price: € {Math.Round((sum / 100) * 0.93, 2)}";
                Currency = "Price: €";
            }

            else
            {
                Price = $"Total price: $ {sum / 100}";
                Currency = "Price: $";
            }
               



        }
    }
}
