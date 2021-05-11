using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace VaultBuddy.Models
{
    public partial class DamageModel
    {
        [JsonProperty("blacklisted")]
        public bool Blacklisted { get; set; }

        [JsonProperty("displayProperties")]
        public DisplayProperties DisplayProperties { get; set; }

        [JsonProperty("enumValue")]
        public long EnumValue { get; set; }

        [JsonProperty("hash")]
        public long Hash { get; set; }

        [JsonProperty("index")]
        public long Index { get; set; }

        [JsonProperty("redacted")]
        public bool Redacted { get; set; }

        [JsonProperty("showIcon")]
        public bool ShowIcon { get; set; }

        [JsonProperty("transparentIconPath")]
        public string TransparentIconPath { get; set; }
    }
}