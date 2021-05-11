using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using VaultBuddy.Accessors;
using VaultBuddy.Models;
using VaultBuddy.Views;
using Xamarin.Forms;
//96 lines
namespace VaultBuddy.ViewModels
{
    public class oAuthVM : INotifyPropertyChanged
    {
        private bool _loading { get; set; }
        public bool Loading
        {
            get { return _loading; }
            set
            {
                _loading = value;
                OnPropertyChanged();
            }
        }

        private bool _loadingOther { get; set; }
        public bool LoadingOther
        {
            get { return _loadingOther; }
            set
            {
                _loadingOther = value;
                OnPropertyChanged();
            }
        }

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

        private oAuthAccessor authAccess = new oAuthAccessor();

        public Command btnAuthorize { get; set; }

        public oAuthVM()
        {
            Loading = false;
            LoadingOther = true;
            btnAuthorize = new Command(async() => await AuthenticateAsync());
        }

        public async Task AuthenticateAsync()
        {
            try
            {
                Routing.RegisterRoute(nameof(Nav), typeof(Nav));
                LoadingOther = false;
                Loading = true;
                await authAccess.AuthenticateAsync();
                await Shell.Current.GoToAsync(nameof(Nav));
                lblInfo = "";
            }
            catch (Exception e)
            {
                LoadingOther = true;
                Loading = false;
                lblInfo = e.Message.ToString() + "Please restart the app.";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
