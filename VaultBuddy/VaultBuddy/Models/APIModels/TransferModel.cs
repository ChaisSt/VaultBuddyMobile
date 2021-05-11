using System;
//16 lines
namespace VaultBuddy.Models
{
    public class TransferModel
    {
        public UInt32 itemReferenceHash { get; set; }
        public Int32 stackSize { get; set; }
        public Boolean transferToVault { get; set; }
        public Int64 itemId { get; set; }
        public Int64 characterId { get; set; }
        public Int32 membershipType { get; set; }
    }
}
