using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//16 lines
namespace VaultBuddy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Nav : TabbedPage
    {
        public Nav()
        {
            InitializeComponent();
            Shell.SetTabBarIsVisible(this, false);
        }
    }
}