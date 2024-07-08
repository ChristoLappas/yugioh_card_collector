using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
//using Windows.System;
using Yu_Gi_Oh__Card_Collector.Models;


namespace Yu_Gi_Oh__Card_Collector.Services
{
    public static class YuGiOhDatabase
    {
        static SQLiteAsyncConnection Database;

        static async Task Init()
        {
            if (Database != null)
                return;

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");

            Database = new SQLiteAsyncConnection(databasePath);

            await Database.CreateTableAsync<User>();
            await Database.CreateTableAsync<Deck>();
            await Database.CreateTableAsync<PlayerCard>();
            await Database.CreateTableAsync<WishListCard>();

        }

        public static async Task AddUser(string name, string email, string password)
        {
            await Init();

            var user = new Models.User
            {
                Username = name,
                Email = email,
                Password = password
            };

            await Database.InsertAsync(user);

        }

        public static async Task<List<Models.User>> GetUsers()
        {
            await Init();

            var users = await Database.Table<Models.User>().ToListAsync();

            return users;
        }

        public static async Task UpdateUser(int id, string name, string? password)
        {
            await Init();

            var user = await Database.Table<Models.User>().Where(x => x.Id == id).FirstOrDefaultAsync();

            user.Username = name;
            
            if(password != null)
                user.Password = password;

            await Database.UpdateAsync(user);
        }

        public static async Task AddDeck(int userId, string name)
        {
            await Init();

            var deck = new Deck
            {
                UserId = userId,
                Name = name                
            };

            await Database.InsertAsync(deck);

        }

        public static async Task<List<Deck>> GetDecks()
        {
            await Init();

            var decks = await Database.Table<Deck>().ToListAsync();

            return decks;
        }

        public static async Task<List<Deck>> GetUserDecks(int userId)
        {
            await Init();

            var deck = from d in Database.Table<Deck>()
                       where d.UserId == userId
                       select d;

            var userDecks = await deck.ToListAsync();

            return userDecks;
        }

        public static async Task AddPlayerCards(int deckId, string name)
        {
            await Init();

            var playerCard = new PlayerCard
            {
                DeckId = deckId,
                Name = name
            };

            await Database.InsertAsync(playerCard);

        }       


        public static async Task<List<PlayerCard>> GetDeckCards(int deckId)
        {
            await Init();

            var card = from c in Database.Table<PlayerCard>()
                       where c.DeckId == deckId
                       select c;

            var playerCards = await card.ToListAsync();

            return playerCards;
        }

        public static async Task AddWishListCards(int userId, string name)
        {
            await Init();

            var wishListCard = new WishListCard
            {
                UserId= userId,
                Name = name
            };

            await Database.InsertAsync(wishListCard);

        }

        public static async Task<List<WishListCard>> GetWishListCards(int userId)
        {
            await Init();

            var wish = from w in Database.Table<WishListCard>()
                       where w.UserId == userId
                       select w;

            var wishListCards = await wish.ToListAsync();

            return wishListCards;
        }

        public static async Task DeleteWishlistCard(int id)
        {
            await Database.DeleteAsync<WishListCard>(id);
        }

        public static async Task DeleteDeckCard(int id)
        {
            await Database.DeleteAsync<PlayerCard>(id);
        }
    }
}
