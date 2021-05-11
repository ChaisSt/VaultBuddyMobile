using Android.Views;
using System;
using System.Collections.Generic;
using VaultBuddy.Droid;
using VaultBuddy.Services;
using Xamarin.Forms;
using System.Data;
using SQLite;
using System.IO;

[assembly: Dependency(typeof(ManifestAccessor))]
namespace VaultBuddy.Droid
{
    class ManifestAccessor 
    {
        public SQLiteConnection Connection()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "Destiny2Manifest.db");

            return new SQLiteConnection(path);
        }

        public string GetData()
        {
            return null;
        }
    }
}