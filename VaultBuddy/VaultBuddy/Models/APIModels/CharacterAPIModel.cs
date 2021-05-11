using Newtonsoft.Json;
using System;
namespace VaultBuddy.Models
{//91 lines
    public partial class CharacterAPIModel
    {
        [JsonProperty("Response")]
        public Response Response { get; set; }

        [JsonProperty("ErrorCode")]
        public long ErrorCode { get; set; }

        [JsonProperty("ErrorStatus")]
        public string ErrorStatus { get; set; }

        public CharacterInfoModel Info { get; set; }
    }

    public partial class Response
    {
        [JsonProperty("profile")]
        public Profile Profile { get; set; }
    }

    public partial class Profile
    {
        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("privacy")]
        public long Privacy { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("userInfo")]
        public UserInfo UserInfo { get; set; }

        [JsonProperty("dateLastPlayed")]
        public DateTimeOffset DateLastPlayed { get; set; }

        [JsonProperty("versionsOwned")]
        public long VersionsOwned { get; set; }

        [JsonProperty("characterIds")]
        public string[] CharacterIds { get; set; }

        [JsonProperty("seasonHashes")]
        public long[] SeasonHashes { get; set; }

        [JsonProperty("currentSeasonHash")]
        public long CurrentSeasonHash { get; set; }

        [JsonProperty("currentSeasonRewardPowerCap")]
        public long CurrentSeasonRewardPowerCap { get; set; }
    }

    public partial class UserInfo
    {
        [JsonProperty("crossSaveOverride")]
        public long CrossSaveOverride { get; set; }

        [JsonProperty("applicableMembershipTypes")]
        public long[] ApplicableMembershipTypes { get; set; }

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
