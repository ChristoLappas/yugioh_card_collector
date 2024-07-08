using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yu_Gi_Oh__Card_Collector.Models;

namespace Yu_Gi_Oh__Card_Collector.Services
{
    public class CardsService
    {
        public HttpClient Client { get; set; }
        private const string url = "https://db.ygoprodeck.com/api/v7/cardinfo.php?fname=";

        public async Task<List<Card>> GetCards(string name)
        {
            Client = new HttpClient();

            var response = await Client.GetAsync(url + name);

            string responseString = await response.Content.ReadAsStringAsync();

            Root card = JsonConvert.DeserializeObject<Root>(responseString);

            List<Card> card2 = card.Data;

            return card2;

        }
    }
}
