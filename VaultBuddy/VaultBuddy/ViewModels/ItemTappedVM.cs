using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using VaultBuddy.Models;
using VaultBuddy.Services;
using VaultBuddy.Views;
using Xamarin.Forms;
//106 lines
namespace VaultBuddy.ViewModels
{
    public class ItemTappedVM
    {
        MainPage main { get; set; }
        Favorites favoritesPage { get; set; }
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

        public Command TransferCommand { get; set; }
        public Command FavoriteCommand { get; set; }

        public ItemTappedVM()
        {
            Item = MainVM.Item;
            TransferCommand = new Command(async () => await GetTransferInfoAsync());
            FavoriteCommand = new Command(async () => await FavoriteItemAsync());
        }

        public async Task FavoriteItemAsync()
        {
            List<FavoriteModel> favorites = await App.Database.GetFavoritesDBAsync();
            var exists = favorites.Find(e => e.itemInstance == Item.ItemInstance);
            if(exists == null)
            {
                Item.Favorite = "heartRed.png";
                await App.Database.SaveFavoritesDBAsync(new FavoriteModel
                {
                    itemHash = Item.ItemHashId,
                    itemInstance = Item.ItemInstance
                });
            }
            else
            {
                Item.Favorite = "";
                await App.Database.DeleteFavoritesDBAsync(exists.id);
            }

            favoritesPage = Favorites.favoritePage;
            favoritesPage.FavoriteChanged();

            main = MainPage.main;
            main.ItemsChanged();
        }

        public static List<CharacterModel> Characters;
        MemberModel member = new MemberModel();
        public async Task GetTransferInfoAsync()
        {
            member = MainVM.Member;
            if (Item.InventoryType == "Vault")
            {
                Characters = member.CharactersList;   
            }
            else
            {
                await TransferToVaultAsync();
            }
        }

        public async Task TransferToVaultAsync()
        {
            TransferService transfer = new TransferService();
            CharacterModel character = new CharacterModel();
            foreach (var memberCharacter in member.CharactersList)
            {
                foreach (var item in memberCharacter.InventoryList)
                {
                    if (item.ItemInstance == Item.ItemInstance)
                    {
                        character = memberCharacter;
                        break;
                    }
                }
            }
            await transfer.TransferItemAsync(Item, member, character.Id);
            Item.InventoryType = "Vault";
            var itemtappedView = ItemTapped.itemTapped;
            itemtappedView.ResetItemLocation();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
