using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using VaultBuddy.Models;
//38 lines
namespace VaultBuddy.Services
{
    public class FavoritesService
    {
        public class Database
        {
            readonly SQLiteAsyncConnection _database;

            public Database(string dbPath)
            {
                _database = new SQLiteAsyncConnection(dbPath);
                _database.CreateTableAsync<FavoriteModel>().Wait();
            }

            public Task<List<FavoriteModel>> GetFavoritesDBAsync()
            {
                return _database.Table<FavoriteModel>().ToListAsync();
            }

            public Task<int> SaveFavoritesDBAsync(FavoriteModel favoritesDB)
            {
                return _database.InsertAsync(favoritesDB);
            }

            public Task<int> DeleteFavoritesDBAsync(int id)
            {
                return _database.ExecuteAsync("DELETE FROM FavoriteModel WHERE id = " + id);
            }
        }
    }
}
