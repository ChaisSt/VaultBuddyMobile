using System;
using System.Collections.Generic;
using System.Text;
//14 lines
namespace VaultBuddy.Models
{
    public class MemberModel
    {
        public string MemberID { get; set; }
        public Int32 MemberType { get; set; }
        public List<CharacterModel> CharactersList { get; set; }
        public List<ItemModel> VaultItems { get; set; }
    }
}
