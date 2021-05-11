using System.Collections.Generic;
using System.Collections.ObjectModel;
//65 lines
namespace VaultBuddy.Models
{
    public class ItemModel
    {
        public long ItemHashId { get; set; }
        public long ItemInstance { get; set; }
        public long BucketHash { get; set; }
        public string BucketType { get; set; }

        public string ItemDesc { get; set; }
        public string ItemName { get; set; }
        public string ItemIcon { get; set; }
        public string IconWM { get; set; }
        public string ItemType { get; set; }
        public string TierType { get; set; }
        public string DamageType { get; set; }

        public string ItemLight { get; set; }
        public string InventoryType { get; set; }
        public string IconWMShelved { get; set; }
        public string ScreenShot { get; set; }
        public string Favorite { get; set; }
    }

    public class ItemModelGroup : ObservableCollection<ItemModel>
    {
        public string Type { get; private set; }
        public string TierType { get; private set; }

        public ItemModelGroup(string type, IEnumerable<ItemModel> groupItems) : base(groupItems)
        {
            Type = type;
        }
    }
    //public class ItemModelCollection : ObservableCollection<ItemModelGroup>
    //{
    //    public string InventoryType { get; private set; }

    //    public ItemModelCollection(string inventoryType, IEnumerable<ItemModelGroup> groupItems) : base(groupItems)
    //    {
    //        InventoryType = inventoryType;
    //    }
    //}
}
