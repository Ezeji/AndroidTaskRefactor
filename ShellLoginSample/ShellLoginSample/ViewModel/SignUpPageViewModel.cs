using ShellLoginSample.Model;
using ShellLoginSample.Repository;
using ShellLoginSample.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ShellLoginSample.ViewModel
{
    public class SignUpPageViewModel
    {
        private IAuthentication _authenticationService;
        public RegisterUser RegisterUser { get; set; } = new RegisterUser();
        public ICommand SignUpCommand { get; }
        private Page _page;

        public SignUpPageViewModel(IAuthentication authenticationService, Page page)
        {
            SignUpCommand = new Command(async () => await SignUpAysnc());
            _authenticationService = authenticationService;
            _page = page;
        }

        private async Task SignUpAysnc()
        {
            if (!ValidationHelper.IsFormValid(RegisterUser, _page))
            {
                return;
            }
            else
            {
                if (_authenticationService.SignupUser(RegisterUser) == "Data saved...")
                {
                    string email = RegisterUser.Email.ToString();
                    string password = RegisterUser.Password.ToString();
                    await Shell.Current.GoToAsync($"//login?email={email}&password={password}");
                }
            }
        }


    }
}
