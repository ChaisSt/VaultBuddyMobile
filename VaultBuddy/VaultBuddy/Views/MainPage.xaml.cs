using System;
using System.Linq;
using VaultBuddy.Models;
using VaultBuddy.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//142 lines
namespace VaultBuddy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        MainVM vm = new MainVM();
        public static MainPage main { get; set; }
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = vm;
            main = this;
        }

        private void FilterButton_Clicked(object sender, EventArgs e)
        {
            itemsCollection.ItemsSource = "";
            itemsCollection.ItemsSource = vm.FilteredItems;
            
            RareSwitch.IsToggled = true;
            LegendSwitch.IsToggled = true;
            ExoticSwitch.IsToggled = true;
            Legend = true;
            Exotic = true;
            Rare = true;
            Uncommon = true;
        }

        private void TopFilterButton_Clicked(object sender, EventArgs e)
        {
            SwipeMenuTop.Open(OpenSwipeItem.TopItems);
        }

        private void LeftFilterButton_Clicked(object sender, EventArgs e)
        {
            SwipeMenu.Open(OpenSwipeItem.LeftItems);
        }

        private bool Legend = true;
        private void LegendSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value == false)
            {
                Legend = false;
                itemsCollection.ItemsSource = "";
                vm.Toggled("LegendaryOff");
                itemsCollection.ItemsSource = vm.FilteredItems;
            }
            else if (Legend == false)
            {
                Legend = true;
                itemsCollection.ItemsSource = "";
                vm.Toggled("LegendaryOn");
                itemsCollection.ItemsSource = vm.FilteredItems;
            }
        }

        private bool Exotic = true;
        private void ExoticSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value == false)
            {
                Exotic = false;
                itemsCollection.ItemsSource = "";
                vm.Toggled("ExoticOff");
                itemsCollection.ItemsSource = vm.FilteredItems;
            }
            else if (Exotic == false)
            {
                Exotic = true;
                itemsCollection.ItemsSource = "";
                vm.Toggled("ExoticOn");
                itemsCollection.ItemsSource = vm.FilteredItems;
            }
        }

        private bool Rare = true;
        private void RareSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value == false)
            {
                Rare = false;
                itemsCollection.ItemsSource = "";
                vm.Toggled("RareOff");
                itemsCollection.ItemsSource = vm.FilteredItems;
            }
            else if (Rare == false)
            {
                Rare = true;
                itemsCollection.ItemsSource = "";
                vm.Toggled("RareOn");
                itemsCollection.ItemsSource = vm.FilteredItems;
            }
        }

        private bool Uncommon = true;
        private void UncommonSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value == false)
            {
                Uncommon = false;
                itemsCollection.ItemsSource = "";
                vm.Toggled("UncommonOff");
                itemsCollection.ItemsSource = vm.FilteredItems;
            }
            else if (Uncommon == false)
            {
                Uncommon = true;
                itemsCollection.ItemsSource = "";
                vm.Toggled("UncommonOn");
                itemsCollection.ItemsSource = vm.FilteredItems;
            }
        }

        private async void itemsCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            itemsCollection.ItemsSource = "";
            long itemInstance = Convert.ToInt64((e.CurrentSelection.FirstOrDefault() as ItemModel)?.ItemInstance);
            await vm.TappedAsync(itemInstance);
            itemsCollection.ItemsSource = vm.FilteredItems;
        }

        public void ItemsChanged()
        {
            itemsCollection.ItemsSource = "";
            vm.RefreshItems();
            itemsCollection.ItemsSource = vm.FilteredItems;
        }
    }
}