using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using VaultBuddy.Accessors;
using VaultBuddy.Models;
using VaultBuddy.Services;
using VaultBuddy.Views;
using Xamarin.Forms;
//275 lines
namespace VaultBuddy.ViewModels
{
    public class MainVM : INotifyPropertyChanged
    {
        private string _title { get; set; }
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        private string _lblInfo { get; set; }
        public string lblInfo
        {
            get { return _lblInfo; }
            set
            {
                _lblInfo = value;
                OnPropertyChanged();
            }
        }

        public MainVM()
        {
            oAuthVM oAuth = new oAuthVM { Loading = true };
            Task.Run(async () => await Initialize()).Wait();
        }

        public Command Filter { get; set; }
        private APIAccessor _aPIAccessor { get; set; }
        public static MemberModel Member { get; set; }
        public static List<ItemModel> AllItems { get; set; }
        public static ItemModel Item { get; set; }

        public async Task Initialize()
        {
            _aPIAccessor = new APIAccessor();

            MemberModel member = new MemberModel();
            member = await GetMemberAsync();
            member = await GetCharacterListAsync(member);
            AllItems = await GetInventoryAsync(member);
            Member = member;

            await IsFavoriteAsync();

            GetFilteredItems("All");

            Filter = new Command<string>(GetFilteredItems);
        }

        private async Task<MemberModel> GetMemberAsync()
        {
            MemberService memberService = new MemberService();
            MemberModel member = await memberService.GetMemberModelAsync(_aPIAccessor);
            return member;
        }

        public async Task<MemberModel> GetCharacterListAsync(MemberModel member)
        {
            CharacterService characterService = new CharacterService();
            member.CharactersList = await characterService.GetCharacterAsync(member, _aPIAccessor);
            return member;
        }
        
        public async Task<List<ItemModel>> GetInventoryAsync(MemberModel member)
        {
            try
            {
                ItemsManifestService manifest = new ItemsManifestService();
                ItemService service = new ItemService();
                List<ItemModel> itemList = new List<ItemModel>();

                member.VaultItems = await GetVaultItems(member, service, manifest);
                itemList = ItemsList(member.VaultItems, itemList);

                foreach (var character in member.CharactersList)
                {
                    character.EquippedList = await GetEquippedItems(member, service, manifest, character).ConfigureAwait(false);
                    itemList = ItemsList(character.EquippedList, itemList);

                    character.InventoryList = await GetCharInventory(member, service, manifest, character).ConfigureAwait(false);
                    itemList = ItemsList(character.InventoryList, itemList);
                }
                return itemList;
            }
            catch (Exception e)
            {
                lblInfo = e.Message.ToString();
            }
            return null;
        }

        public List<ItemModel> ItemsList(List<ItemModel> items, List<ItemModel> itemList)
        {
            foreach (var item in items)
            {
                itemList.Add(item);
            }
            return itemList;
        }

        public async Task<List<ItemModel>> GetVaultItems(MemberModel member, ItemService service, ItemsManifestService manifest)
        {
            var vaultPath = await service.GetVaultItemHashesAsync(member, _aPIAccessor);
            var vaultManifest = await service.AddItemsListAsync("Vault", vaultPath, member, manifest, _aPIAccessor);
            return vaultManifest;
        }

        public async Task<List<ItemModel>> GetEquippedItems(MemberModel member, ItemService service, ItemsManifestService manifest, CharacterModel character)
        {
            var equippedPath = await service.GetEquippedItemHashesAsync(member, character.Id.ToString(), _aPIAccessor);
            var equippedManifest = await service.AddItemsListAsync("Equipped", equippedPath, member, manifest, _aPIAccessor);
            return equippedManifest;
        }

        public async Task<List<ItemModel>> GetCharInventory(MemberModel member, ItemService service, ItemsManifestService manifest, CharacterModel character)
        {
            var inventoryPath = await service.GetInventoryItemHashesAsync(member, character.Id.ToString(), _aPIAccessor);
            var inventoryManifest = await service.AddItemsListAsync("Equipped", inventoryPath, member, manifest, _aPIAccessor);

            if (inventoryManifest.Count == 0)
                inventoryManifest = service.AddEmptyItem();

            return inventoryManifest;
        }

        FilterService filter = new FilterService();
        public ObservableCollection<ItemModelGroup> FilteredItems { get; set; } = new ObservableCollection<ItemModelGroup>();
        //public ObservableCollection<ItemModelCollection> ItemsByInventory { get; set; } = new ObservableCollection<ItemModelCollection>();
        public void GetFilteredItems(string type)
        {
            FilteredItems.Clear();
            switch (type)
            {
                case "All": 
                    FilteredItems = filter.All(FilteredItems, AllItems);
                    Title = "All Items";
                    //ItemsByInventory = filter.SortByInventory(FilteredItems, ItemsByInventory);
                    break;
                case "Vault": 
                    FilteredItems = filter.Vault(FilteredItems, Member.VaultItems);
                    Title = "Vault Items";
                    break;
                case "Equipped": 
                    FilteredItems = filter.Equipped(FilteredItems, Member);
                    Title = "Equipped Items";
                    break;
                case "Armor": 
                    FilteredItems = filter.Armor(FilteredItems, AllItems);
                    Title = "All Armor";
                    break;
                default: 
                    FilteredItems = filter.NotArmor(FilteredItems, AllItems, type);
                    Title = type;
                    break;
            }
        }
        
        public void Toggled(string action)
        {
            FilteredItems.Clear();
            switch (action)
            {
                case "LegendaryOff":
                    FilteredItems = filter.TierToggleOff(FilteredItems, "Legendary");
                    break;
                case "ExoticOff":
                    FilteredItems = filter.TierToggleOff(FilteredItems, "Exotic");
                    break;
                case "RareOff":
                    FilteredItems = filter.TierToggleOff(FilteredItems, "Rare");
                    break;
                case "UncommonOff":
                    FilteredItems = filter.TierToggleOff(FilteredItems, "Uncommon");
                    break;

                case "LegendaryOn":
                    FilteredItems = filter.TierToggleOn(FilteredItems, "Legendary");
                    break;
                case "ExoticOn":
                    FilteredItems = filter.TierToggleOn(FilteredItems, "Exotic");
                    break;
                case "RareOn":
                    FilteredItems = filter.TierToggleOn(FilteredItems, "Rare");
                    break;
                case "UncommonOn":
                    FilteredItems = filter.TierToggleOn(FilteredItems, "Uncommon");
                    break;
            }
        }

        public async Task TappedAsync(long itemInstance)
        {
            foreach (var item in AllItems)
            {
                if (itemInstance == item.ItemInstance)
                    Item = item;
            }
            Routing.RegisterRoute(nameof(ItemTapped), typeof(ItemTapped));

            await Shell.Current.GoToAsync(nameof(ItemTapped));
        }

        public ObservableCollection<ItemModelGroup> FavoriteItems { get; set; } = new ObservableCollection<ItemModelGroup>();
        public async Task IsFavoriteAsync()
        {
            List<ItemModel> favoriteItems = new List<ItemModel>();
            List<FavoriteModel> existingFavorites = new List<FavoriteModel>();
            List<FavoriteModel> favoriteDB = await App.Database.GetFavoritesDBAsync();

            existingFavorites = GetFavoriteList(favoriteDB, existingFavorites, favoriteItems);
            await RemoveUnownedFavorites(favoriteDB, existingFavorites);
        }

        public async Task RemoveUnownedFavorites(List<FavoriteModel> favoriteDB, List<FavoriteModel> existingFavorites)
        {
            IEnumerable<FavoriteModel> deletedFavorites = favoriteDB.Except(existingFavorites);
            foreach (var missingItem in deletedFavorites)
            {
                await App.Database.DeleteFavoritesDBAsync(missingItem.id);
            }
        }

        public List<FavoriteModel> GetFavoriteList(List<FavoriteModel> favoriteDB, List<FavoriteModel> existingItems, List<ItemModel> favoriteItems)
        {
            FavoriteItems.Clear();
            foreach (var favorite in favoriteDB)
            {
                foreach (var item in AllItems)
                {
                    if (item.ItemInstance == favorite.itemInstance)
                    {
                        existingItems.Add(favorite);
                        favoriteItems.Add(item);
                        item.Favorite = "heartRed.png";
                    }
                }
            }
            FavoriteItems = filter.GetCollection(favoriteItems, FavoriteItems);
            return existingItems;
        }

        public void RefreshItems()
        {
            FilteredItems.Clear();
            FilteredItems = filter.RestoreItemList(FilteredItems);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
