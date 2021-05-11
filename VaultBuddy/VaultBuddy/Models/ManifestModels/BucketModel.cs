using Newtonsoft.Json;
//49 lines
namespace VaultBuddy.Models
{
    public partial class BucketModel
    {
        [JsonProperty("displayProperties")]
        public DisplayProperties DisplayProperties { get; set; }

        [JsonProperty("scope")]
        public long Scope { get; set; }

        [JsonProperty("category")]
        public long Category { get; set; }

        [JsonProperty("bucketOrder")]
        public long BucketOrder { get; set; }

        [JsonProperty("itemCount")]
        public long ItemCount { get; set; }

        [JsonProperty("location")]
        public long Location { get; set; }

        [JsonProperty("hasTransferDestination")]
        public bool HasTransferDestination { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("fifo")]
        public bool Fifo { get; set; }

        [JsonProperty("hash")]
        public long Hash { get; set; }

        [JsonProperty("index")]
        public long Index { get; set; }

        [JsonProperty("redacted")]
        public bool Redacted { get; set; }

        [JsonProperty("blacklisted")]
        public bool Blacklisted { get; set; }
    }
}
