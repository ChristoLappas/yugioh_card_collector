using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yu_Gi_Oh__Card_Collector.Models
{
    public class CardImage : ObservableObject
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("image_url")]
        public string ImageUrl {
            get => imageUrl;
            set => SetProperty(ref imageUrl, value);
                     
        }
        private string imageUrl;        
        [JsonProperty("image_url_small")]

        public string ImageUrlSmall { get; set; }
        
        

    }

    public class CardPrice : ObservableObject
    {
        [JsonProperty("cardmarket_price")]
        public string CardmarketPrice { get; set; }
        [JsonProperty("tcgplayer_price")]
        public string TcgplayerPrice { get; set; }
        [JsonProperty("ebay_price")]
        public string EbayPrice { get; set; }
        [JsonProperty("amazon_price")]
        public string AmazonPrice { get; set; }
        [JsonProperty("coolstuffinc_price")]
        public string CoolstuffincPrice { get; set; }
    }

    public class CardSet : ObservableObject
    {
        [JsonProperty("set_name")]
        public string SetName { get; set; }
        [JsonProperty("set_code")]
        public string SetCode { get; set; }
        [JsonProperty("set_rarity")]
        public string SetRarity { get; set; }
        [JsonProperty("set_rarity_code")]
        public string SetRarityCode { get; set; }
        [JsonProperty("set_price")]
        public string SetPrice { get; set; }
    }

    public class Card : ObservableObject
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
            
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("desc")]
        public string Description { get; set; }
        [JsonProperty("atk")]
        public int Attack { get; set; }
        [JsonProperty("def")]
        public int Defense { get; set; }
        [JsonProperty("level")]
        public int Level { get; set; }
        [JsonProperty("race")]
        public string Race { get; set; }
        [JsonProperty("attribute")]
        public string Attribute { get; set; }
        [JsonProperty("card_sets")]
        public List<CardSet> CardSets { get; set; }
        [JsonProperty("card_images")]
        public List<CardImage> CardImages { get; set; }
        [JsonProperty("card_prices")]
        public List<CardPrice> CardPrices { get; set; }
    }
    public class Root : ObservableObject
    {
        [JsonProperty("data")]
        public List<Card> Data { get; set; }
    }
}
