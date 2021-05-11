using System.ComponentModel;
using System.Runtime.CompilerServices;
using VaultBuddy.Accessors;
using VaultBuddy.Views;
using Xamarin.Forms;
//36 lines
namespace VaultBuddy.ViewModels
{
    public class HelpVM //: INotifyPropertyChanged
    {
        public Command btnLogout { get; set; }

        public HelpVM()
        {
            btnLogout = new Command(Logout);
        }

        private void Logout()
        {
            Routing.RegisterRoute(nameof(oAuthPage), typeof(oAuthPage));

            APIAccessor accessor = new APIAccessor();
            accessor.RemoveAuthorization();

            Shell.Current.GoToAsync(nameof(oAuthPage));
        }

        //public event PropertyChangedEventHandler PropertyChanged;
        //private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
