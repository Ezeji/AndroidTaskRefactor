using ShellLoginSample.Repository;
using ShellLoginSample.Service;
using ShellLoginSample.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShellLoginSample.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        private IAuthentication _authenticationService;

        public SignUpPage()
        {
            InitializeComponent();

            _authenticationService = DIContainer.AuthenticationService;
            BindingContext = new SignUpPageViewModel(_authenticationService, this);
        }

        
    }
}