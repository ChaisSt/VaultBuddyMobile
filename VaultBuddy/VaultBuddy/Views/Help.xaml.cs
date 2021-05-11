using VaultBuddy.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//22 lines
namespace VaultBuddy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Help : ContentPage
    {
        public Help()
        {
            InitializeComponent();
            HelpVM vm = new HelpVM();
            this.BindingContext = vm;
        }
    }
}