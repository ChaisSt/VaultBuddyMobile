using SQLite;
using System;
//16 lines
namespace VaultBuddy.Models
{
    public class FavoriteModel
    {
        [PrimaryKey, AutoIncrement]
        public Int32 id { get; set; }
        public long itemInstance { get; set; }
        public long itemHash { get; set; }
    }
}
