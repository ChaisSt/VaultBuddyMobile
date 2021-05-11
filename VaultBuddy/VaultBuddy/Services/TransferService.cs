using System.Threading.Tasks;
using VaultBuddy.Accessors;
using VaultBuddy.Models;
//45 lines
namespace VaultBuddy.Services
{
    public class TransferService
    {
        public bool GetLocation(ItemModel item)
        {
            bool location = false;
            if (item.InventoryType == "Equipped")
                location = true;

            return location;
        }

        public async Task TransferItemAsync(ItemModel item, MemberModel member, long characterId)
        {
            bool location = GetLocation(item);
            TransferModel postBody = new TransferModel
            {
                itemReferenceHash = (uint)item.ItemHashId,
                stackSize = 1,
                transferToVault = location,
                itemId = item.ItemInstance,
                characterId = characterId,
                membershipType = (int)member.MemberType
            };

            await RequestTransferAsync(postBody);
        }

        public async Task RequestTransferAsync(TransferModel postBody)
        {
            string uri = "https://www.bungie.net/Platform/Destiny2/Actions/Items/TransferItem/";
            await APIAccessor.TransferAsync<TransferModel>(uri, postBody);
        }
    }
}
