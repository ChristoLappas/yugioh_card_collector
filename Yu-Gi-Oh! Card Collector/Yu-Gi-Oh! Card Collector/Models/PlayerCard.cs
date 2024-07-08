using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yu_Gi_Oh__Card_Collector.Models
{
    public class PlayerCard
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int DeckId { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
    }
}
