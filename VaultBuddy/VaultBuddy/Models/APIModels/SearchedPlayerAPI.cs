using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
//53 lines
namespace VaultBuddy.Models
{
    public class SearchedPlayerAPI
    {
        [JsonProperty("Response")]
        public Response[] Response { get; set; }

        [JsonProperty("ErrorCode")]
        public long ErrorCode { get; set; }

        [JsonProperty("ErrorStatus")]
        public string ErrorStatus { get; set; }
    }

    public partial class Response
    {
        [JsonProperty("iconPath")]
        public string IconPath { get; set; }

        [JsonProperty("crossSaveOverride")]
        public long CrossSaveOverride { get; set; }

        [JsonProperty("isPublic")]
        public bool IsPublic { get; set; }

        [JsonProperty("membershipType")]
        public long MembershipType { get; set; }

        [JsonProperty("membershipId")]
        public string MembershipId { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
    }
}
