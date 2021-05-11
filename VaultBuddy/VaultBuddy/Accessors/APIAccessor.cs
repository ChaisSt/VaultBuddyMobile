using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using VaultBuddy.Models;
//74 lines
namespace VaultBuddy.Accessors
{
    public class APIAccessor
    {
        private static readonly string key = Secret.APIKey;
        private static string uri = "";

        public static HttpClient ApiClient { get; set; }

        private static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Add("X-API-Key", key);
        }

        public static UserToken Authorized(UserToken userToken)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(userToken.TokenType, userToken.AccessToken);
            userToken.AddedToAPI = true;
            return userToken;
        }

        public void CreateUri(string path, string input)
        {
            uri = "https://www.bungie.net/platform/" + path + input;
        }

        public static async Task<dynamic> RequestAsync(HttpClient ApiClient)
        {
            var response = await ApiClient.GetAsync(uri);
            string content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<dynamic> PostAsync<TResult>(string uri, string data)
        {
            if (ApiClient == null)
            {
                InitializeClient();
            }

            var content = new StringContent(data);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            var response = await ApiClient.PostAsync(uri, content);

            string serialized = await response.Content.ReadAsStringAsync();
            var item = JsonConvert.DeserializeObject<UserToken>(serialized);
            return item;
        }

        public static async Task<dynamic> TransferAsync<TResult>(string uri, TransferModel postBody)
        {
            string json = JsonConvert.SerializeObject(postBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await ApiClient.PostAsync(uri, content);

            string serialized = await response.Content.ReadAsStringAsync();
            return serialized;
        }

        public void RemoveAuthorization()
        {
            ApiClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
