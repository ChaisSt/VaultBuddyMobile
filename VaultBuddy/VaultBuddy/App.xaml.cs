using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using VaultBuddy.Views;
using VaultBuddy.Accessors;
using System.IO;
using static VaultBuddy.Services.FavoritesService;

namespace VaultBuddy
{
    public partial class App : Application
    {
        static Database database;

        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "favoritesdb.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
