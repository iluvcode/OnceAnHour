using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using App3.Data;
using App3.iOS.Data;
using Foundation;
using SQLite.Net;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_IOS))]

namespace App3.iOS.Data
{
    public class SQLite_IOS : ISQLite
    {

        public SQLiteConnection GetConnection()
        {
            var filename = "Onceanhour.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
            var path = Path.Combine(libraryPath, filename);

            // This is where we copy in the prepopulated database
            Console.WriteLine(path);
            if (!File.Exists(path))
            {
                File.Create(path);
            }

            var plat = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            var conn = new SQLite.Net.SQLiteConnection(plat, path);

            // Return the database connection 
            return conn;
        }
    }
}