using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using VaultBuddy.Models;
using VaultBuddy.Services;
using VaultBuddy.Views;
//67 lines
namespace VaultBuddy.ViewModels
{
    public class CharacterSelectVM
    {
        private ItemModel _item { get; set; }
        public ItemModel Item
        {
            get { return _item; }
            set
            {
                _item = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<CharacterModel> Characters { get; set; }
        public CharacterSelectVM()
        {
            var list = ItemTappedVM.Characters;
            Characters = new ObservableCollection<CharacterModel>(list);
        
            Item = MainVM.Item;
        }
        
        public async Task TransferToCharacterAsync(long id)
        {
            TransferService transfer = new TransferService();
            MemberModel member = MainVM.Member;
            await transfer.TransferItemAsync(Item, member, id);

            Item.InventoryType = "Equipped";
            var tappedview = ItemTapped.itemTapped;
            tappedview.ResetItemLocation();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
