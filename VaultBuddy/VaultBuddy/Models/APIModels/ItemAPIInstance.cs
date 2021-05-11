using Newtonsoft.Json;
//94 lines
namespace VaultBuddy.Models.APIModels
{
    public partial class ItemAPIInstance
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
        [JsonProperty("characterId")]
        public string CharacterId { get; set; }

        [JsonProperty("instance")]
        public Instance Instance { get; set; }
    }

    public partial class Instance
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("damageType")]
        public long DamageType { get; set; }

        [JsonProperty("damageTypeHash")]
        public long DamageTypeHash { get; set; }

        [JsonProperty("primaryStat")]
        public PrimaryStat PrimaryStat { get; set; }

        [JsonProperty("itemLevel")]
        public long ItemLevel { get; set; }

        [JsonProperty("quality")]
        public long Quality { get; set; }

        [JsonProperty("isEquipped")]
        public bool IsEquipped { get; set; }

        [JsonProperty("canEquip")]
        public bool CanEquip { get; set; }

        [JsonProperty("equipRequiredLevel")]
        public long EquipRequiredLevel { get; set; }

        [JsonProperty("unlockHashesRequiredToEquip")]
        public long[] UnlockHashesRequiredToEquip { get; set; }

        [JsonProperty("cannotEquipReason")]
        public long CannotEquipReason { get; set; }
    }

    public partial class PrimaryStat
    {
        [JsonProperty("statHash")]
        public long StatHash { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }
    }
}