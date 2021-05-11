using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VaultBuddy.Accessors;
using VaultBuddy.Models;
//124 lines
namespace VaultBuddy.Services
{
    public class SearchService
    {
        APIAccessor accessor = new APIAccessor();

        ItemsManifestService manifestService = new ItemsManifestService();

        public async Task<MemberModel> SearchPlayerAsync(string input, MemberModel member)
        {
            string path = "/Destiny2/SearchDestinyPlayer/-1/";
            string query = input + "/";
            accessor.CreateUri(path, query);

            var res = await APIAccessor.RequestAsync(APIAccessor.ApiClient);
            var result = JsonConvert.DeserializeObject<SearchedPlayerAPI>(res);

            member.MemberID = result.Response[0].MembershipId;
            member.MemberType = Convert.ToInt32(result.Response[0].MembershipType);

            return member;
        }

        public async Task<MemberModel> GetSearchedCharactersAsync(MemberModel member)
        {
            CharacterService service = new CharacterService();
            member.CharactersList = await service.GetCharacterAsync(member, accessor);
            return member;
        }

        public async Task<List<ItemModel>> GetCharacterEquippedAsync(MemberModel member, CharacterModel character)
        {
            string path = "Destiny2/" + member.MemberType.ToString() + "/Profile/" + member.MemberID;
            string query = "/Character/" + character.Id + "/?components=205";
            accessor.CreateUri(path, query);

            string response = await APIAccessor.RequestAsync(APIAccessor.ApiClient);
            var result = JsonConvert.DeserializeObject<ItemAPIModel>(response);

            List<ItemModel> itemList = new List<ItemModel>();
            var itemPath = result.Response.Equipment.Data.Items;
            itemList = await GetItemInfoAsync(itemPath, member, itemList);
            return itemList;
        }

        private async Task<List<ItemModel>> GetItemInfoAsync(Item[] items, MemberModel member, List<ItemModel> itemList)
        {
            ItemService service = new ItemService();
            itemList = await service.AddItemsListAsync("Searched", items, member, manifestService, accessor);

            return itemList;
        }
        //public ItemModel PopulateSearchedItem(ItemModel item, ItemManifestModel inventoryData)
        //{
        //    item.TierType = inventoryData.Inventory.TierTypeName;
        //    item.ItemType = inventoryData.ItemTypeDisplayName;
        //    item.ScreenShot = "https://www.bungie.net" + inventoryData.Screenshot;
        //    item.IconWM = "https://www.bungie.net" + inventoryData.IconWatermark;
        //    item.IconWMShelved = "https://www.bungie.net" + inventoryData.IconWatermarkShelved;

        //    return item;
        //}
        //public ItemModel GetItemData(ItemModel searchedItem)
        //{
        //    var inventoryData = manifestService.GetManifestSearchItem(searchedItem);
        //    if (inventoryData != null)
        //    {
        //        manifestService.GetManifestSearchBucket(inventoryData, searchedItem);

        //        searchedItem = PopulateSearchedItem(searchedItem, inventoryData);
        //    }
        //    return searchedItem;
        //}
        //public async Task<SearchItemAPI> SearchItemAsync(string input)
        //{
        //    string path = "/Destiny2/Armory/Search/DestinyInventoryItemDefinition/";
        //    string query = input + "/";
        //    accessor.CreateUri(path, query);

        //    string response = await APIAccessor.RequestAsync(APIAccessor.ApiClient);
        //    SearchItemAPI result = JsonConvert.DeserializeObject<SearchItemAPI>(response);

        //    return result;
        //}
        //public ItemModel FoundItem(SearchItemAPI result, List<ItemModel> itemList)
        //{
        //    //var hash = result.Response.Results.ResultsResults[1].Hash;
        //    ItemModel searchedItem = new ItemModel
        //    {
        //        ItemHashId = result.Response.Results.ResultsResults[1].Hash,
        //        ItemDesc = result.Response.Results.ResultsResults[0].DisplayProperties.Description,
        //        ItemIcon = "https://www.bungie.net" + result.Response.Results.ResultsResults[1].DisplayProperties.Icon,
        //        ItemName = result.Response.Results.ResultsResults[1].DisplayProperties.Name
        //    };

        //    bool match = false;
        //    foreach (var item in itemList)
        //    {
        //        if (item.ItemHashId == searchedItem.ItemHashId)
        //        {
        //            searchedItem = item;
        //            match = true;
        //            break;
        //        }
        //    }

        //    if (!match)
        //        searchedItem = GetItemData(searchedItem);

        //    return searchedItem;
        //}
    }
}
