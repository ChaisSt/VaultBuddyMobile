using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VaultBuddy.Accessors;
using VaultBuddy.Models;
using VaultBuddy.Models.APIModels;
//119 lines
namespace VaultBuddy.Services
{
    public class ItemService
    {
        public async Task<Item[]> GetVaultItemHashesAsync(MemberModel member, APIAccessor aPIAccessor)
        {
            string path = "Destiny2/" + member.MemberType.ToString() + "/Profile/" + member.MemberID;
            string query = "/?components=102";
            aPIAccessor.CreateUri(path, query);

            string res = await APIAccessor.RequestAsync(APIAccessor.ApiClient);
            var items = JsonConvert.DeserializeObject<ItemAPIModel>(res);
            var itemPath = items.Response.ProfileInventory.Data.Items;

            return itemPath;
        }

        public async Task<Item[]> GetEquippedItemHashesAsync(MemberModel member, string charId, APIAccessor accessor)
        {
            string path = "Destiny2/" + member.MemberType.ToString() + "/Profile/" + member.MemberID;
            string query = "/Character/" + charId + "/?components=205";
            accessor.CreateUri(path, query);

            string res = await APIAccessor.RequestAsync(APIAccessor.ApiClient);
            var items = JsonConvert.DeserializeObject<ItemAPIModel>(res);
            var modelPath = items.Response.Equipment.Data.Items;

            return modelPath;
        }

        public async Task<Item[]> GetInventoryItemHashesAsync(MemberModel member, string charId, APIAccessor accessor)
        {
            string path = "Destiny2/" + member.MemberType.ToString() + "/Profile/" + member.MemberID;
            string query = "/Character/" + charId + "/?components=201";
            accessor.CreateUri(path, query);

            string res = await APIAccessor.RequestAsync(APIAccessor.ApiClient);
            var items = JsonConvert.DeserializeObject<ItemAPIModel>(res);
            var inventoryPath = items.Response.Inventory.Data.Items;

            return inventoryPath;
        }

        public async Task<PrimaryStat> GetInstanceAsync(Item item, MemberModel member, APIAccessor accessor)
        {
            string path = "Destiny2/" + member.MemberType.ToString() + "/Profile/" + member.MemberID;
            string query = "/Item/" + item.ItemInstanceId + "/?components=300";
            accessor.CreateUri(path, query);

            string res = await APIAccessor.RequestAsync(APIAccessor.ApiClient);
            var items = JsonConvert.DeserializeObject<ItemAPIInstance>(res);
            var instancePath = items.Response.Instance.Data.PrimaryStat;

            return instancePath;
        }
        
        public async Task<List<ItemModel>> AddItemsListAsync(string inventoryType, Item[] items, MemberModel member, 
                                                                     ItemsManifestService manifest, APIAccessor accessor)
        {
            var itemList = new List<ItemModel>();
            foreach (var item in items)
            {
                try
                {
                    ItemManifestModel info = manifest.GetManifestItemData(item);
                    BucketModel type = info != null ? manifest.GetManifestBucketData(info, item) : null;
                    PrimaryStat instance = item.ItemInstanceId != null && type != null ? await GetInstanceAsync(item, member, accessor) : null;
                    //DamageModel damage = new DamageModel();
                    //if (info != null && type.DisplayProperties.Name == "Energy Weapons")
                    //{
                    //    damage = manifest.GetDamageTypeData(info);
                    //}
                    //DamageModel damage = info != null && type.DisplayProperties.Name == "Energy Weapons" ? manifest.GetDamageTypeData(info) : null;

                    if (info != null && type != null)
                    {
                        itemList.Add(AddModelItem(inventoryType, item, type, info, instance)); 
                    }
                }
                catch (Exception e) { }
            }
            return itemList;
        }

        public ItemModel AddModelItem(string inventoryType, Item item, BucketModel type, ItemManifestModel info, PrimaryStat instancePath)
        {
            ItemModel Item = new ItemModel
            {
                ItemHashId = item.ItemHash,
                BucketHash = item.BucketHash,
                BucketType = type.DisplayProperties.Name,
                ItemDesc = info.DisplayProperties.Description,
                ItemIcon = "https://www.bungie.net" + info.DisplayProperties.Icon,
                ItemName = info.DisplayProperties.Name,
                ItemType = info.ItemTypeDisplayName,
                IconWM = "https://www.bungie.net",
                TierType = info.Inventory.TierTypeName,
                ScreenShot = "https://www.bungie.net" + info.Screenshot,
                InventoryType = inventoryType
            };
            //Item.DamageType = damage != null ? "https://www.bungie.net" + damage.DisplayProperties.Icon : "";
            Item.IconWM += info.IconWatermark == null ? info.IconWatermarkShelved : info.IconWatermark; 
            Item.ItemLight = instancePath != null && instancePath.Value > 200 ? instancePath.Value.ToString() : ""; 
            Item.ItemInstance = item.ItemInstanceId != null ? Convert.ToInt64(item.ItemInstanceId) : 0;
                        
            return Item;
        }

        public List<ItemModel> AddEmptyItem()
        {
            List<ItemModel> itemModel = new List<ItemModel>();
            itemModel.Add(new ItemModel());
            return itemModel;
        }
    }
}
