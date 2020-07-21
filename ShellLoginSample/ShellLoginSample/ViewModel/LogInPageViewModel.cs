using ShellLoginSample.Model;
using ShellLoginSample.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ShellLoginSample.ViewModel
{
    [QueryProperty("EmailValue", "email")]
    [QueryProperty("PasswordValue", "password")]
    public class LogInPageViewModel : INotifyPropertyChanged
    {
        private IAuthentication _authenticationService;
        public LoginUser LoginUser { get; set; } = new LoginUser();
        public ICommand SignUpCommand { get; }
        public ICommand LogInCommand { get; }
        private Page _page;
        
        public string EmailValue
        {

            set
            {
                LoginUser.Email = Uri.UnescapeDataString(value);
                Email = LoginUser.Email;
                OnPropertyChanged("Email");
            }
        }

     
        public string PasswordValue
        {

            set
            {
                LoginUser.Password = Uri.UnescapeDataString(value);
                Password = LoginUser.Password;
                OnPropertyChanged("Password");
            }
        }

        public LogInPageViewModel(IAuthentication authenticationService, Page page)
        {
            SignUpCommand = new Command(async () => await SignUpAsync());
            LogInCommand = new Command(async () => await LogInAsync());
            _authenticationService = authenticationService;
            _page = page;
        }


        public string Email { get; set; }
        public string Password { get; set; }


        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        private async Task SignUpAsync()
        {
            await Shell.Current.GoToAsync("//login/signup");
        }

        private async Task LogInAsync()
        {
            if (LoginUser.Email == null || LoginUser.Password == null)
            {
                await _page.DisplayAlert("Alert", "Get started by first signing up...", "OK");
            }
            else
            {
                if (_authenticationService.LoginUser(LoginUser) == "There's no such user...")
                {
                    await _page.DisplayAlert("Alert", "There's no such user...", "OK");
                }
                else
                {
                    await Shell.Current.GoToAsync("//main");
                }
            }
        }
    }
}
