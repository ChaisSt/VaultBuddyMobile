using System;
using System.Linq;
using VaultBuddy.Models;
using VaultBuddy.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//38 lines
namespace VaultBuddy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Favorites : ContentPage
    {
        public static Favorites favoritePage { get; set; }
        readonly MainVM vm = new MainVM();
        public Favorites()
        {
            InitializeComponent();
            this.BindingContext = vm;
            favoritePage = this;
        }

        private async void itemsCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            long itemInstance = Convert.ToInt64((e.CurrentSelection.FirstOrDefault() as ItemModel)?.ItemInstance);
            await vm.TappedAsync(itemInstance);
        }

        public async void FavoriteChanged()
        {
            favoriteCollection.ItemsSource = "";
            await vm.IsFavoriteAsync();
            favoriteCollection.ItemsSource = vm.FavoriteItems;
        }
    }
}