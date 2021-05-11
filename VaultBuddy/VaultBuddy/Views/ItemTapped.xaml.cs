using System;
using VaultBuddy.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//45 lines
namespace VaultBuddy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemTapped : ContentPage
    {
        public static ItemTapped itemTapped { get; set; }
        ItemTappedVM vm = new ItemTappedVM();
        public ItemTapped()
        {
            InitializeComponent();
            this.BindingContext = vm;
            itemTapped = this;
        }

        private async void TransferButton_ClickedAsync(object sender, EventArgs e)
        {
            if (vm.Item.InventoryType == "Vault")
            {
                await Navigation.PushAsync(new CharacterSelectPage());
            }
        }

        public void ResetItemLocation()
        {
            inventoryType.Text = "";
            inventoryType.Text = "Location: " + vm.Item.InventoryType;
        }

        private async void FavoriteButton_ClickedAsync(object sender, EventArgs e)
        {
            heartImg.Source = "";
            await vm.FavoriteItemAsync();
            heartImg.Source = vm.Item.Favorite;
        }
    }
}