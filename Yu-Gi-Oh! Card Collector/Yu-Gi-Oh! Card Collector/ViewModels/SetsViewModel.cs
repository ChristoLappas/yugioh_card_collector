using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yu_Gi_Oh__Card_Collector.Models;
using Yu_Gi_Oh__Card_Collector.Services;
using Yu_Gi_Oh__Card_Collector.Views;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;


namespace Yu_Gi_Oh__Card_Collector.ViewModels
{
    [INotifyPropertyChanged]
    public partial class SetsViewModel
    {
        private SetsService setsService;
        [ObservableProperty]
        private string setName;
        [ObservableProperty]
        private List<Card> cardList;
        [ObservableProperty]
        private List<Deck> deckList;
        [ObservableProperty]
        private string errorMessage;
        [ObservableProperty]
        private Deck pickerItem;
        [ObservableProperty]
        private string attribute;
        [ObservableProperty]
        private string race;
        [ObservableProperty]
        private string sort;
        [ObservableProperty]
        private string currency;


        public SetsViewModel(SetsService ss)
        {
            setsService = ss;
        }

        [RelayCommand]
        public async Task LoadCards()
        {
            if (!string.IsNullOrWhiteSpace(attribute))
                setName += $"&attribute={attribute}";

            if (!string.IsNullOrWhiteSpace(race))
                setName += $"&race={race}";

            if (!string.IsNullOrWhiteSpace(sort))
                setName += $"&sort={sort}";

            CardList = await setsService.GetSets(setName);

            await GetCurrency();

            if (CardList == null)
            {
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                string text = "No sets found!";
                ToastDuration duration = ToastDuration.Short;
                double fontSize = 17;
                var toast = Toast.Make(text, duration, fontSize);
                await toast.Show(cancellationTokenSource.Token);
            }

        }

        [RelayCommand]
        public async Task AddToWishList(Card card)
        {
            await YuGiOhDatabase.AddWishListCards(LoginDetails.Id, card.Name);

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            string text = "Card successfully added to wishlist!";
            ToastDuration duration = ToastDuration.Short;
            double fontSize = 17;
            var toast = Toast.Make(text, duration, fontSize);
            await toast.Show(cancellationTokenSource.Token);
        }

        [RelayCommand]
        public async Task LoadDecks()
        {
            var userDecks = await YuGiOhDatabase.GetUserDecks(LoginDetails.Id);

            DeckList = userDecks;
        }

        [RelayCommand]
        public async Task AddToDeck(Card card)
        {

            await YuGiOhDatabase.AddPlayerCards(PickerItem.Id, card.Name);

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            string text = $"Card added to {PickerItem.Name}!";
            ToastDuration duration = ToastDuration.Short;
            double fontSize = 17;
            var toast = Toast.Make(text, duration, fontSize);
            await toast.Show(cancellationTokenSource.Token);
        }
        [RelayCommand]
        public async Task GetCurrency()
        {
            if (Preferences.Default.Get("euro", true))
                Currency = "Price: €";
            else
                Currency = "Price: $";
        }
    }
}
