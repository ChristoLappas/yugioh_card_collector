using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yu_Gi_Oh__Card_Collector.Models
{
    public class User
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Username { get; set; }
        [Unique,MaxLength(100)]
        public string Email { get; set; }
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
