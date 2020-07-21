using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ShellLoginSample.Droid.Data;
using ShellLoginSample.Repository;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(RegisterUsersDB))]
namespace ShellLoginSample.Droid.Data
{
    public class RegisterUsersDB : IRegisterUsersDB
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "RegisterUsersDb.db3";
            var path = Path.Combine(System.Environment.
              GetFolderPath(System.Environment.
              SpecialFolder.Personal), dbName);
            return new SQLiteConnection(path);
        }
    }
}