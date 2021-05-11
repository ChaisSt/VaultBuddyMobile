using Newtonsoft.Json;
//90 lines
namespace VaultBuddy.Models
{
    public class SearchItemAPI
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
        [JsonProperty("suggestedWords")]
        public string[] SuggestedWords { get; set; }

        [JsonProperty("results")]
        public Results Results { get; set; }
    }

    public partial class Results
    {
        [JsonProperty("results")]
        public Result[] ResultsResults { get; set; }

        [JsonProperty("totalResults")]
        public long TotalResults { get; set; }

        [JsonProperty("hasMore")]
        public bool HasMore { get; set; }

        [JsonProperty("query")]
        public Query Query { get; set; }

        [JsonProperty("useTotalResults")]
        public bool UseTotalResults { get; set; }
    }

    public partial class Query
    {
        [JsonProperty("itemsPerPage")]
        public long ItemsPerPage { get; set; }

        [JsonProperty("currentPage")]
        public long CurrentPage { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("hash")]
        public long Hash { get; set; }

        [JsonProperty("entityType")]
        public string EntityType { get; set; }

        [JsonProperty("displayProperties")]
        public DisplayProperties DisplayProperties { get; set; }

        [JsonProperty("weight")]
        public double Weight { get; set; }
    }

    public partial class DisplayProperties
    {
        [JsonProperty("iconSequences", NullValueHandling = NullValueHandling.Ignore)]
        public IconSequence[] IconSequences { get; set; }
    }

    public partial class IconSequence
    {
        [JsonProperty("frames")]
        public string[] Frames { get; set; }
    }
}
