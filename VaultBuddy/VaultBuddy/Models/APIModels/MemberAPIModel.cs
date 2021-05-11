using Newtonsoft.Json;
using System;
//159 lines
namespace VaultBuddy.Models
{
    public partial class MemberAPIModel
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
        [JsonProperty("destinyMemberships")]
        public DestinyMembership[] DestinyMemberships { get; set; }

        [JsonProperty("bungieNetUser")]
        public BungieNetUser BungieNetUser { get; set; }
    }

    public partial class BungieNetUser
    {
        [JsonProperty("membershipId")]
        public long MembershipId { get; set; }

        [JsonProperty("uniqueName")]
        public long UniqueName { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("profilePicture")]
        public long ProfilePicture { get; set; }

        [JsonProperty("profileTheme")]
        public long ProfileTheme { get; set; }

        [JsonProperty("userTitle")]
        public long UserTitle { get; set; }

        [JsonProperty("successMessageFlags")]
        public long SuccessMessageFlags { get; set; }

        [JsonProperty("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty("about")]
        public string About { get; set; }

        [JsonProperty("firstAccess")]
        public DateTimeOffset FirstAccess { get; set; }

        [JsonProperty("lastUpdate")]
        public DateTimeOffset LastUpdate { get; set; }

        [JsonProperty("context")]
        public Context Context { get; set; }

        [JsonProperty("xboxDisplayName")]
        public string XboxDisplayName { get; set; }

        [JsonProperty("showActivity")]
        public bool ShowActivity { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("localeInheritDefault")]
        public bool LocaleInheritDefault { get; set; }

        [JsonProperty("showGroupMessaging")]
        public bool ShowGroupMessaging { get; set; }

        [JsonProperty("profilePicturePath")]
        public string ProfilePicturePath { get; set; }

        [JsonProperty("profileThemeName")]
        public string ProfileThemeName { get; set; }

        [JsonProperty("userTitleDisplay")]
        public string UserTitleDisplay { get; set; }

        [JsonProperty("statusText")]
        public string StatusText { get; set; }

        [JsonProperty("statusDate")]
        public DateTimeOffset StatusDate { get; set; }
    }

    public partial class Context
    {
        [JsonProperty("isFollowing")]
        public bool IsFollowing { get; set; }

        [JsonProperty("ignoreStatus")]
        public IgnoreStatus IgnoreStatus { get; set; }
    }

    public partial class IgnoreStatus
    {
        [JsonProperty("isIgnored")]
        public bool IsIgnored { get; set; }

        [JsonProperty("ignoreFlags")]
        public long IgnoreFlags { get; set; }
    }

    public partial class DestinyMembership
    {
        [JsonProperty("LastSeenDisplayName")]
        public string LastSeenDisplayName { get; set; }

        [JsonProperty("LastSeenDisplayNameType")]
        public long LastSeenDisplayNameType { get; set; }

        [JsonProperty("iconPath")]
        public string IconPath { get; set; }

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
