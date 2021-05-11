using Newtonsoft.Json;
using System;
//120 lines
namespace VaultBuddy.Models
{
    public partial class ItemAPIModel
    {
        [JsonProperty("Response")]
        public Response Response { get; set; }

        [JsonProperty("ErrorCode")]
        public long ErrorCode { get; set; }

        [JsonProperty("ErrorStatus")]
        public string ErrorStatus { get; set; }
    }

    public partial class Response
    {
        [JsonProperty("profileInventory")]
        public ProfileInventory ProfileInventory { get; set; }

        [JsonProperty("inventory")]
        public Inventory Inventory { get; set; }

        [JsonProperty("equipment")]
        public Equipment Equipment { get; set; }
    }

    public partial class Inventory
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public partial class Equipment
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public partial class ProfileInventory
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("items")]
        public Item[] Items { get; set; }
    }

    public partial class Item
    {
        [JsonProperty("itemHash")]
        public long ItemHash { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("bindStatus")]
        public long BindStatus { get; set; }

        [JsonProperty("location")]
        public long Location { get; set; }

        [JsonProperty("bucketHash")]
        public long BucketHash { get; set; }

        [JsonProperty("transferStatus")]
        public long TransferStatus { get; set; }

        [JsonProperty("lockable")]
        public bool Lockable { get; set; }

        [JsonProperty("state")]
        public long State { get; set; }

        [JsonProperty("dismantlePermission")]
        public long DismantlePermission { get; set; }

        [JsonProperty("isWrapper")]
        public bool IsWrapper { get; set; }

        [JsonProperty("tooltipNotificationIndexes")]
        public object[] TooltipNotificationIndexes { get; set; }

        [JsonProperty("itemInstanceId", NullValueHandling = NullValueHandling.Ignore)]
        public string ItemInstanceId { get; set; }

        [JsonProperty("versionNumber", NullValueHandling = NullValueHandling.Ignore)]
        public long? VersionNumber { get; set; }

        [JsonProperty("overrideStyleItemHash", NullValueHandling = NullValueHandling.Ignore)]
        public long? OverrideStyleItemHash { get; set; }

        [JsonProperty("expirationDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? ExpirationDate { get; set; }

    }
}
