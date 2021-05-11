using Newtonsoft.Json;
using System;
using System.Collections.Generic;
namespace VaultBuddy.Models
{//123 lines
    public partial class CharacterInfoModel
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
        [JsonProperty("character")]
        public Character Character { get; set; }
    }

    public partial class Character
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("membershipId")]
        public string MembershipId { get; set; }

        [JsonProperty("membershipType")]
        public long MembershipType { get; set; }

        [JsonProperty("characterId")]
        public string CharacterId { get; set; }

        [JsonProperty("minutesPlayedThisSession")]
        public long MinutesPlayedThisSession { get; set; }

        [JsonProperty("minutesPlayedTotal")]
        public long MinutesPlayedTotal { get; set; }

        [JsonProperty("light")]
        public long Light { get; set; }

        [JsonProperty("stats")]
        public Dictionary<string, long> Stats { get; set; }

        [JsonProperty("raceHash")]
        public long RaceHash { get; set; }

        [JsonProperty("genderHash")]
        public long GenderHash { get; set; }

        [JsonProperty("classHash")]
        public long ClassHash { get; set; }

        [JsonProperty("raceType")]
        public long RaceType { get; set; }

        [JsonProperty("classType")]
        public long ClassType { get; set; }

        [JsonProperty("genderType")]
        public long GenderType { get; set; }

        [JsonProperty("emblemPath")]
        public string EmblemPath { get; set; }

        [JsonProperty("emblemBackgroundPath")]
        public string EmblemBackgroundPath { get; set; }

        [JsonProperty("emblemHash")]
        public long EmblemHash { get; set; }

        [JsonProperty("emblemColor")]
        public EmblemColor EmblemColor { get; set; }

        [JsonProperty("levelProgression")]
        public Dictionary<string, long> LevelProgression { get; set; }

        [JsonProperty("baseCharacterLevel")]
        public long BaseCharacterLevel { get; set; }

        [JsonProperty("percentToNextLevel")]
        public long PercentToNextLevel { get; set; }
    }

    public partial class EmblemColor
    {
        [JsonProperty("red")]
        public long Red { get; set; }

        [JsonProperty("green")]
        public long Green { get; set; }

        [JsonProperty("blue")]
        public long Blue { get; set; }

        [JsonProperty("alpha")]
        public long Alpha { get; set; }
    }
}
