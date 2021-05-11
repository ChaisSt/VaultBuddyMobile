using SQLite;
using System;
using System.Linq;
using VaultBuddy.Models;
//36 lines
namespace VaultBuddy.Accessors
{
    public class ManifestAccess
    {
        private static string dbPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Destiny2Manifest.db");
        public DestinyInventoryItemDefinition GetItemDefTable(string id)
        {
            using (var conn = new SQLiteConnection(dbPath))
            {
                string query = "SELECT json FROM DestinyInventoryItemDefinition WHERE id = " + id;
                DestinyInventoryItemDefinition result = conn.Query<DestinyInventoryItemDefinition>(query, id).FirstOrDefault();
                conn.Close();
                return result;
            }
        }

        public DestinyInventoryBucketDefinition GetBucketDefTable(string id)
        {
            using (var conn = new SQLiteConnection(dbPath))
            {
                string query = "SELECT json FROM DestinyInventoryBucketDefinition WHERE id = " + id;
                DestinyInventoryBucketDefinition result = conn.Query<DestinyInventoryBucketDefinition>(query, id).FirstOrDefault();
                conn.Close();
                return result;
            }
        }

        public DestinyDamageTypeDefinition GetDamageDefTable(string id)
        {
            using (var conn = new SQLiteConnection(dbPath))
            {
                string query = "SELECT json FROM DestinyDamageTypeDefinition WHERE id = " + id;
                DestinyDamageTypeDefinition result = conn.Query<DestinyDamageTypeDefinition>(query, id).FirstOrDefault();
                conn.Close();
                return result;
            }
        }
    }
}
