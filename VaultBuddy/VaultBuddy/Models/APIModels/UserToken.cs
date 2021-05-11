using Newtonsoft.Json;
//24 lines
namespace VaultBuddy.Models
{
    public class UserToken
    {
        public bool AddedToAPI { get; set; }

        [JsonProperty("member_id")]
        public string MemberId { get; set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }
    }
}
