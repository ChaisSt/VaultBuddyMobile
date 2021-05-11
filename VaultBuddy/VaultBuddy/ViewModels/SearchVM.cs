using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using VaultBuddy.Models;
using VaultBuddy.Services;
using Xamarin.Forms;
//141 lines
namespace VaultBuddy.ViewModels
{
    public class SearchVM
    {
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


        public ObservableCollection<SearchedCharacterItems> PlayerItems { get; set; } 
        public async Task SearchPlayerAsync(string input)
        {
            SearchService search = new SearchService();
            PlayerItems = new ObservableCollection<SearchedCharacterItems>();
            List<ItemModel> characterItems;
            MemberModel member = new MemberModel();
            try
            {
                member = await search.SearchPlayerAsync(input, member);
                if (member != null)
                {
                    member = await search.GetSearchedCharactersAsync(member);
                    foreach (var character in member.CharactersList)
                    {
                        characterItems = await search.GetCharacterEquippedAsync(member, character);
                        PlayerItems.Add(new SearchedCharacterItems(character, characterItems));
                    }
                }
                else { lblInfo = "Player not found."; }
            }
            catch (Exception e) { lblInfo = "Player not found" + e.Message.ToString(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
