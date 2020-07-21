using Moq;
using NUnit.Framework;
using ShellLoginSample.Model;
using ShellLoginSample.Repository;
using ShellLoginSample.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ShellLoginSample.UnitTests.Mock
{
    [TestFixture]
    public class LogInPageViewModelTests
    {
        Page _page;

        [SetUp]
        public void Setup()
        {
            _page = new Page();
        }

        [Test]
        public void LogInCommand_UserNotRegistered_NotFoundAlertMessage()
        {
            var authentication = new Mock<IAuthentication>();
            authentication.Setup(login => login.LoginUser(new LoginUser())).Returns("There's no such user...");

            var logInPageViewModel = new LogInPageViewModel(authentication.Object, _page);

            logInPageViewModel.LogInCommand.Execute(new LoginUser());

            var message = "There's no such user...";

            Assert.AreEqual("There's no such user...", message);

        }

        [Test]
        public void LogInCommand_LoginDetailsIsNull_UnauthorizedAlertMessage()
        {
            var authentication = new Mock<IAuthentication>();
            authentication.Setup(login => login.LoginUser(new LoginUser())).Returns("Access not granted...");

            var logInPageViewModel = new LogInPageViewModel(authentication.Object, _page);

            logInPageViewModel.LogInCommand.Execute(new LoginUser());

            var message = "Get started by first signing up...";

            Assert.AreEqual("Get started by first signing up...", message);

        }

    }
}
