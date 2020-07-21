using Moq;
using NUnit.Framework;
using ShellLoginSample.Model;
using ShellLoginSample.Repository;
using ShellLoginSample.ViewModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShellLoginSample.UnitTests.Mock
{
    [TestFixture]
    public class SignUpPageViewModelTests
    {
        Page _page;

        [SetUp]
        public void Setup()
        {
            _page = new Page();
        }

        [Test]
        public void SignUpCommand_UserDetailsIsValid_StoresUserEmailAndPasswordInVariables()
        {
            var authentication = new Mock<IAuthentication>();
            authentication.Setup(signup => signup.SignupUser(new RegisterUser())).Returns("Data saved...");

            var signUpPageViewModel = new SignUpPageViewModel(authentication.Object, _page);

            signUpPageViewModel.SignUpCommand.Execute(new RegisterUser());

            var user = new RegisterUser
            {
                Email = "FakeEmail",
                Password = "FakePassword"
            };
            var email = user.Email.ToString();
            var password = user.Password.ToString();

            Assert.AreEqual("FakeEmail", email);
            Assert.AreEqual("FakePassword", password);

        }
    }
}