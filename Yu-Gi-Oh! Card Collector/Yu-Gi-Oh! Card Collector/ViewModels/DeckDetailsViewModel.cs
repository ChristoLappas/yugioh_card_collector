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
    [QueryProperty("Deck","Deck")]
    public partial class DeckDetailsViewModel : DecksViewModel
    {
        private DeckDetailsService deckDetailsService;
        [ObservableProperty]
        Deck deck;        
        [ObservableProperty]
        List<Card> deckListAPI;
        [ObservableProperty]
        private string currency;

        public DeckDetailsViewModel(DeckDetailsService dds)
        {
            deckDetailsService = dds;
        }

        [RelayCommand]
        async Task GetAllDeckCards()
        {
            var deckCardList = await YuGiOhDatabase.GetDeckCards(deck.Id);            

            var deckCardListAPi = await deckDetailsService.GetCards(deckCardList);

            DeckListAPI = deckCardListAPi;

            await GetCurrency();
        }

        [RelayCommand]
        async Task DeleteFromDeck(string name)
        {
            var allDeckList = await YuGiOhDatabase.GetDeckCards(deck.Id);

            for (int i = 0; i < allDeckList.Count; i++)
            {
                if (allDeckList[i].Name == name)
                    await YuGiOhDatabase.DeleteDeckCard(allDeckList[i].Id);
            }

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            string text = "Card successfully deleted!";
            ToastDuration duration = ToastDuration.Short;
            double fontSize = 17;
            var toast = Toast.Make(text, duration, fontSize);
            await toast.Show(cancellationTokenSource.Token);


            await GetAllDeckCards();
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
