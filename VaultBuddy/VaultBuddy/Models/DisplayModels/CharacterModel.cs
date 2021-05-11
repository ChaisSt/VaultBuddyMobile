using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
//46 lines
namespace VaultBuddy.Models
{
    public partial class CharacterModel
    {
        public Int64 Id { get; set; }

        public string Light { get; set; }

        public string Race { get; set; }

        public string Class { get; set; }

        public string Emblem { get; set; }

        public string EmblemBG { get; set; }

        public List<ItemModel> EquippedList { get; set; }

        public List<ItemModel> InventoryList { get; set; }
    }

    
    public class CharacterModelGroup : ObservableCollection<CharacterModel>
    {
        public CharacterModel Character { get; private set; }
        public CharacterModelGroup(CharacterModel character)
        {
            Character = character;
        }
    }

    public class SearchedCharacterItems : ObservableCollection<ItemModel>
    {
        public CharacterModel Character { get; set; }
        public SearchedCharacterItems(CharacterModel character, List<ItemModel> equipped) : base(equipped)
        {
            Character = character;
        }
    }
}
