using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yu_Gi_Oh__Card_Collector.Models;
using Yu_Gi_Oh__Card_Collector.Services;
using Yu_Gi_Oh__Card_Collector.Views;

namespace Yu_Gi_Oh__Card_Collector.ViewModels
{
    [INotifyPropertyChanged]
    public partial class DecksViewModel
    {
        
        [ObservableProperty]
        private string name;
        [ObservableProperty]
        private int id;
        [ObservableProperty]
        private List<Deck> decks;
        


        [RelayCommand]
        public async Task CreateDeck()
        {
            if (!string.IsNullOrWhiteSpace(Name))
            {
                await YuGiOhDatabase.AddDeck(LoginDetails.Id, Name);
                await ShowDecks();
            }
           
        }

        [RelayCommand]
        public async Task ShowDecks()
        {
            Decks = await FilterDecks();            
            
        }
        //Get the decks that belong to the user
        [RelayCommand]
        public async Task<List<Deck>> FilterDecks()
        {
            List<Deck> allDecks = await YuGiOhDatabase.GetDecks();

            List<Deck> filteredDecks = new List<Deck>();

            foreach (Deck d in allDecks)
            {
                if (d.UserId == LoginDetails.Id)
                    filteredDecks.Add(d);
            }

            return filteredDecks;

        }
        //Show the cards that belong to this deck
        [RelayCommand]
        public async Task GoToDeckDetails(Deck deck)
        {
            await Shell.Current.GoToAsync($"{nameof(DeckDetailsView)}",true,new Dictionary<string, object>
            {
                { "Deck", deck }
            });
        }
    }
}
