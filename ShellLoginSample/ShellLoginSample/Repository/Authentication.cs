using ShellLoginSample.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ShellLoginSample.Repository
{
    public class Authentication : IAuthentication
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();
        public ObservableCollection<RegisterUser> RegisterUsers { get; set; }

        public Authentication()
        {
            database =
        DependencyService.Get<IRegisterUsersDB>().
        DbConnection();
            database.CreateTable<RegisterUser>();
            RegisterUsers =
              new ObservableCollection<RegisterUser>(database.Table<RegisterUser>());
            // If the table is empty, initialize the collection
            if (!database.Table<RegisterUser>().Any())
            {
                AddNewUser();
            }
        }

        public void AddNewUser()
        {
            RegisterUsers.Add(new RegisterUser
            {
                Username = "Username...",
                Email = "Email...",
                Password = "Password...",
                EncryptedPassword = "EncryptedPassword...",
                PhoneNumber = "PhoneNumber...",
                ClientID = "ClientID...",
                Company = "Company...",
                UserID = "UserID..."
            });
        }

        public string SignupUser(RegisterUser registerUser)
        {
            // Use locks to avoid database collitions
            lock (collisionLock)
            {
                var User = new RegisterUser
                {
                    Username = registerUser.Username,
                    Email = registerUser.Email,
                    EncryptedPassword = PasswordEncryption.HashPassword(registerUser.Password.ToString()),
                    PhoneNumber = registerUser.PhoneNumber,
                    ClientID = registerUser.ClientID,
                    Company = registerUser.Company,
                    UserID = Guid.NewGuid().ToString()
                };

                database.Insert(User);

                return "Data saved...";
            }

        }

        public string LoginUser(LoginUser loginUser)
        {

            // Use locks to avoid database collitions
            lock (collisionLock) 
            { 

                var encryptedPassword = PasswordEncryption.HashPassword(loginUser.Password.ToString());

                var registeredUser = database.Table<RegisterUser>()
                                               .Where(user => user.Email == loginUser.Email && user.EncryptedPassword == encryptedPassword)
                                               .FirstOrDefault();

                if (registeredUser == null)
                {
                    return "There's no such user...";
                }
                else
                {
                    return "User exists...";
                }

            }
        }
    }
}
