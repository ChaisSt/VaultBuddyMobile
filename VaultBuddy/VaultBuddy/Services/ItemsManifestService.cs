using Newtonsoft.Json;
using VaultBuddy.Accessors;
using VaultBuddy.Models;
//81 lines
namespace VaultBuddy.Services
{
    public class ItemsManifestService
    {
        ManifestAccess access = new ManifestAccess();

        public ItemManifestModel GetManifestItemData(Item item)
        {
            var id = unchecked((int)item.ItemHash);
            var itemData = access.GetItemDefTable(id.ToString());
            var data = itemData.Json;
            if (data != null)
            {
                var jsonData = JsonConvert.DeserializeObject<ItemManifestModel>(data);
                if (jsonData.DisplayProperties.Name != "Weekly Clan Engrams")
                {
                    return jsonData;
                }
            }
            return null;
        }

        //public DamageModel GetDamageTypeData(ItemManifestModel info)
        //{
        //    if (info.DamageTypeHashes[0] != 0)
        //    {
        //        var id = info.DamageTypeHashes[0];
        //        var damageType = access.GetDamageDefTable(id.ToString());
        //        var json = JsonConvert.DeserializeObject<DamageModel>(damageType.Json);
        //        return json;
        //    }
        //    return null;
        //}

        public BucketModel GetManifestBucketData(ItemManifestModel info, Item item)
        {
            int id;
            if (info == null) 
                id = unchecked((int)item.BucketHash); 
            else 
                id = unchecked((int)info.Inventory.BucketTypeHash);
            var bucketData = access.GetBucketDefTable(id.ToString());
            var data = bucketData.Json;
            if (data != null)
            {
                return BucketData(data);
            }
            return null;
        }
        
        public BucketModel BucketData(string data)
        {
            var jsonData = JsonConvert.DeserializeObject<BucketModel>(data);
            var type = jsonData.DisplayProperties.Name;
            if (type != "Quests" && type != null && type != "Consumables" && type != "Modifications" && type != "Shaders" &&
                type != "Subclass" && type != "Emblems" && type != "Finishers" && type != "Emotes")
            {
                return jsonData;
            }
            return null;
        }

    
        //public ItemManifestModel GetManifestSearchItem(ItemModel item)
        //{
        //    var id = unchecked((int)item.ItemHashId);
        //    var itemData = access.GetItemDefTable(id.ToString());
        //    var data = itemData.Json;
        //    if (data != null)
        //    {
        //        var jsonData = JsonConvert.DeserializeObject<ItemManifestModel>(data);
        //        return jsonData;
        //    }
        //    return null;
        //}
        //public BucketModel GetManifestSearchBucket(ItemManifestModel info, ItemModel item)
        //{
        //    var id = unchecked((int)info.Inventory.BucketTypeHash);
        //    var bucket = access.GetBucketDefTable(id.ToString());
        //    var data = bucket.Json;
        //    if (data != null)
        //    {
        //        return BucketData(data);
        //    }
        //    return null;
        //}
    }
}
