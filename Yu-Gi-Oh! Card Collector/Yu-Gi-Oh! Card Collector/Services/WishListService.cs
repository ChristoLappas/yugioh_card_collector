using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yu_Gi_Oh__Card_Collector.Models;

namespace Yu_Gi_Oh__Card_Collector.Services
{
    public class WishListService
    {
        public HttpClient Client { get; set; }
        private const string url = "https://db.ygoprodeck.com/api/v7/cardinfo.php?name=";

        public async Task<List<Card>> GetCards(List<WishListCard> wishListCards)
        {
            Client = new HttpClient();
            List<Card> cards = new List<Card>();

            foreach (WishListCard c in wishListCards)
            {
                var response = await Client.GetAsync(url + c.Name);

                string responseString = await response.Content.ReadAsStringAsync();

                Root card = JsonConvert.DeserializeObject<Root>(responseString);

                cards.Add(card.Data[0]);
            }

            return cards;

        }
    }
}
