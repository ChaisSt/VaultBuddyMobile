using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using VaultBuddy.Accessors;
using VaultBuddy.Models;
//60 lines
namespace VaultBuddy.Services
{
    public class CharacterService
    {
        public async Task<List<CharacterModel>> GetCharacterAsync(MemberModel member, APIAccessor accessor)
        {
            var characterList = new List<CharacterModel>();
            CharacterAPIModel characterAPI = await ApiGetCharactersAsync(member, accessor);

            foreach (var characterId in characterAPI.Response.Profile.Data.CharacterIds)
            {
                string path = "Destiny2/" + member.MemberType.ToString() + "/Profile/" + member.MemberID;
                string query = "/Character/" + characterId + "/?components=200";
                accessor.CreateUri(path, query);

                string response = await APIAccessor.RequestAsync(APIAccessor.ApiClient);
                var characterInfoData = JsonConvert.DeserializeObject<CharacterInfoModel>(response);

                if (characterInfoData != null)
                    characterList.Add(Character(characterId, characterInfoData));
            }
            return characterList;
        }

        private async Task<CharacterAPIModel> ApiGetCharactersAsync(MemberModel member, APIAccessor accessor)
        {
            string path = "Destiny2/" + member.MemberType.ToString() + "/Profile/";
            string query = member.MemberID + "/?components=100";
            accessor.CreateUri(path, query);

            string response = await APIAccessor.RequestAsync(APIAccessor.ApiClient);
            var characterAPI = JsonConvert.DeserializeObject<CharacterAPIModel>(response);

            return characterAPI;
        }

        private CharacterModel Character(string characterId, CharacterInfoModel characterInfo)
        {
            var characterPath = characterInfo.Response.Character.Data;

            CharacterModel character = new CharacterModel
            {
                Id = long.Parse(characterId),
                Light = characterPath.Light.ToString(),
                Class = characterPath.ClassType == 0 ? "Titan" : characterPath.ClassType == 1 ? "Hunter" : "Warlock",
                Race = characterPath.RaceType == 0 ? "Human" : characterPath.RaceType == 1 ? "Awoken" : "Exo",
                Emblem = "https://www.bungie.net" + characterPath.EmblemPath,
                EmblemBG = "https://www.bungie.net" + characterPath.EmblemBackgroundPath
            };

            return character;
        }
    }
}


