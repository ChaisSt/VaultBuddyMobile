using System;
using VaultBuddy.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//30 lines
namespace VaultBuddy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Search : ContentPage
    {
        SearchVM vm = new SearchVM();
        public Search()
        {
            InitializeComponent();
            this.BindingContext = vm;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            PlayerSearch.ItemsSource = "";
            await vm.SearchPlayerAsync(SearchInput.Text);
            PlayerSearch.ItemsSource = vm.PlayerItems;
        }
    }
}