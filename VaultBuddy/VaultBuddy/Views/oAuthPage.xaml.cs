using VaultBuddy.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//25 lines
namespace VaultBuddy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class oAuthPage : ContentPage
    {
        public oAuthPage()
        {
            InitializeComponent();
            oAuthVM vm = new oAuthVM();
            this.BindingContext = vm;
            Shell.SetTabBarIsVisible(this, false);
        }
    }
}