using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using VaultBuddy.Models;
//179 lines
namespace VaultBuddy.Services
{
    public class FilterService
    {
        private IEnumerable<ItemModel> itemEnum;
        private List<ItemModel> itemHolder = new List<ItemModel>();
        private List<ItemModel> compareList = new List<ItemModel>();
        private List<string> categoryList;

        public void GetTypes(List<ItemModel> itemList)
        {
            categoryList = new List<string>();
            foreach (var item in itemList)
            {
                if (!categoryList.Contains(item.BucketType))
                    categoryList.Add(item.BucketType);
            } 
            categoryList = categoryList.OrderBy(t => t).ToList();
        }

        public ObservableCollection<ItemModelGroup> GetCollection(List<ItemModel> itemList, ObservableCollection<ItemModelGroup> collection)
        {
            GetTypes(itemList);
            itemList = itemList.OrderByDescending(i => i.ItemLight).ToList();
            itemHolder = itemList;

            foreach (var type in categoryList)
            {
                List<ItemModel> list = new List<ItemModel>();
                foreach (var item in itemList)
                {
                    if (type == item.BucketType)
                        list.Add(item);
                }
                IEnumerable<ItemModel> itemsByType = list;
                collection.Add(new ItemModelGroup(type, list));
            }
            return collection;
        }

        //public ObservableCollection<ItemModelCollection> SortByInventory(ObservableCollection<ItemModelGroup> group,
        //    ObservableCollection<ItemModelCollection> collection)
        //{

        //    foreach (var type in group)
        //    {

        //    }

        //    return collection;
        //}

        public ObservableCollection<ItemModelGroup> All(ObservableCollection<ItemModelGroup> collection, List<ItemModel> itemList)
        {
            compareList = itemList;
            collection = GetCollection(itemList, collection);
            return collection;
        }

        public ObservableCollection<ItemModelGroup> Vault(ObservableCollection<ItemModelGroup> collection, List<ItemModel> itemList)
        {
            compareList = itemList;
            collection = GetCollection(itemList, collection);
            return collection;
        }

        public ObservableCollection<ItemModelGroup> Equipped(ObservableCollection<ItemModelGroup> collection, MemberModel member)
        {
            List<ItemModel> itemList = new List<ItemModel>();
            foreach (var character in member.CharactersList)
            {
                foreach (var item in character.EquippedList)
                {
                    itemList.Add(item);
                }
            }
            compareList = itemList;
            collection = GetCollection(itemList, collection);
            return collection;
        }

        public ObservableCollection<ItemModelGroup> Armor(ObservableCollection<ItemModelGroup> collection, List<ItemModel> items)
        {
            compareList = new List<ItemModel>();
            foreach (var item in items)
            {
                if (item.BucketType == "Helmet" || item.BucketType == "Chest Armor"
                        || item.BucketType == "Gauntlets" || item.BucketType == "Leg Armor"
                        || item.BucketType == "Class Armor")
                    compareList.Add(item);
            }
            collection = GetCollection(compareList, collection);

            return collection;
        }

        public ObservableCollection<ItemModelGroup> ArmorType(ObservableCollection<ItemModelGroup> collection, List<ItemModel> items, string type)
        {
            foreach (var item in items)
            {
                if (type == item.BucketType)
                    compareList.Add(item);
            }
            compareList = compareList.OrderByDescending(i => i.ItemLight).ToList();
            itemHolder = compareList;
            itemEnum = compareList;
            collection.Add(new ItemModelGroup(type, itemEnum));
            return collection;
        }

        public ObservableCollection<ItemModelGroup> NotArmor(ObservableCollection<ItemModelGroup> collection, List<ItemModel> itemList, string type)
        {
            compareList = new List<ItemModel>();
            foreach (var item in itemList)
            {
                if (type == item.BucketType)
                    compareList.Add(item);
            }
            compareList = compareList.OrderByDescending(i => i.ItemLight).ToList();
            itemHolder = compareList;
            itemEnum = compareList;
            collection.Add(new ItemModelGroup(type, itemEnum));
            return collection;
        }

        public ObservableCollection<ItemModelGroup> TierToggleOff(ObservableCollection<ItemModelGroup> collection, string tier)
        {
            List<ItemModel> itemList = new List<ItemModel>();
            foreach (var item in itemHolder)
            {
                if (item.TierType != tier)
                    itemList.Add(item);
            }

            collection = GetCollection(itemList, collection);
            return collection;
        }

        public ObservableCollection<ItemModelGroup> TierToggleOn(ObservableCollection<ItemModelGroup> collection, string tier)
        {
            IEnumerable<ItemModel> compareEnum = compareList;
            IEnumerable<ItemModel> itemEnum = itemHolder;
            IEnumerable<ItemModel> itemList = compareEnum.Except(itemEnum);

            foreach (var item in itemList)
            {
                if (item.TierType == tier)
                    itemHolder.Add(item);
            }

            collection = GetCollection(itemHolder, collection);
            return collection;
        }

        public ObservableCollection<ItemModelGroup> RestoreItemList(ObservableCollection<ItemModelGroup> collection)
        {
            collection = GetCollection(itemHolder, collection);
            return collection;
        }
    }
}
