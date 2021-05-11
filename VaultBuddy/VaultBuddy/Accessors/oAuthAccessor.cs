using IdentityModel.Client;
using System;
using System.Threading.Tasks;
using VaultBuddy.Models;
using Xamarin.Essentials;
//39 lines
namespace VaultBuddy.Accessors
{
    public class oAuthAccessor
    {
        public async Task AuthenticateAsync()
        {
            APIAccessor accessor = new APIAccessor();
            string client_id = "35241";
            string url = $"https://www.bungie.net/en/OAuth/Authorize?client_id={client_id}&response_type=code";
            string redirect = "myapp://";

            var authResult = await WebAuthenticator.AuthenticateAsync(new Uri(url), new Uri(redirect));
            string code = authResult?.Properties["code"];

            string raw = $"{redirect}#client_id={client_id}&grant_type=authorization_code&code={code}";
            var authorizeResponse = new AuthorizeResponse(raw);
            UserToken userToken = await GetTokenAsync(authorizeResponse.Code, accessor);

            APIAccessor.Authorized(userToken);
        }

        public async Task<UserToken> GetTokenAsync(string code, APIAccessor accessor)
        {
            string tokenUri = "https://www.bungie.net/platform/app/oauth/token/";
            string client_id = "35241";
            string data = string.Format("client_id={0}&grant_type=authorization_code&code={1}", client_id, code);
            var token = await accessor.PostAsync<UserToken>(tokenUri, data);
            return token;
        }
    }
}
