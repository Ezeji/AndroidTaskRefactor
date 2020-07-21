using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShellLoginSample.Model
{
    [Table("RegisterUsers")]
    public class RegisterUser : INotifyPropertyChanged
    {
        private int id;
        [PrimaryKey, AutoIncrement]
        public int ID
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
                OnPropertyChanged(nameof(ID));
            }
        }

        private string username;
        [Required, System.ComponentModel.DataAnnotations.MaxLength(40)]
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged(nameof(Username));
            }

        }

        private string email;
        [Required, EmailAddress]
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }

        }

        private string password;
        [Required]
        [Ignore]
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }

        }

        private string encryptedPassword;
        public string EncryptedPassword
        {
            get
            {
                return encryptedPassword;
            }
            set
            {
                encryptedPassword = value;
                OnPropertyChanged(nameof(EncryptedPassword));
            }

        }

        private string phoneNumber;
        [Required, Phone]
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }

        }

        private string clientID;
        [Required]
        public string ClientID
        {
            get
            {
                return clientID;
            }
            set
            {
                clientID = value;
                OnPropertyChanged(nameof(ClientID));
            }

        }

        private string company;
        [Required]
        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
                OnPropertyChanged(nameof(Company));
            }

        }

        private string userID;
        public string UserID
        {
            get
            {
                return userID;
            }
            set
            {
                userID = value;
                OnPropertyChanged(nameof(UserID));
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this,
              new PropertyChangedEventArgs(propertyName));
        }
    }
}
