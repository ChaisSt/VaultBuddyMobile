using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using VaultBuddy.Accessors;
using VaultBuddy.Models;
//38 lines
namespace VaultBuddy.Services
{
    public class MemberService
    {
        public async Task<MemberModel> GetMemberModelAsync(APIAccessor accessor)
        {
            MemberModel member = new MemberModel();

            MemberAPIModel memberAPI = await GetPlayerAsync(accessor);

            member.MemberID = memberAPI.Response.DestinyMemberships[0].MembershipId;
            member.MemberType = Convert.ToInt32(memberAPI.Response.DestinyMemberships[0].MembershipType);

            return member;
        }

        public async Task<MemberAPIModel> GetPlayerAsync(APIAccessor accessor)
        {
            var path = "/User/GetMembershipsForCurrentUser";
            var query = "/";
            accessor.CreateUri(path, query);

            var res = await APIAccessor.RequestAsync(APIAccessor.ApiClient);
            var memberAPI = JsonConvert.DeserializeObject<MemberAPIModel>(res);

            return memberAPI;
        }
    }
}
