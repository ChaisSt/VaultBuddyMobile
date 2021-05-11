using System;
using System.Linq;
using VaultBuddy.Models;
using VaultBuddy.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//32 lines
namespace VaultBuddy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterSelectPage : ContentPage
    {
        public CharacterSelectPage()
        {
            InitializeComponent();
            CharacterSelectVM vm = new CharacterSelectVM();
            this.BindingContext = vm;
        }

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CharacterSelectVM vm = new CharacterSelectVM();
            long characterId = Convert.ToInt64((e.CurrentSelection.FirstOrDefault() as CharacterModel)?.Id);
            await vm.TransferToCharacterAsync(characterId);

            await Navigation.PopAsync();
        }
    }
}