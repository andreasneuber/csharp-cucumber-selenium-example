using csharp_cucumber_selenium_framework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
// using TechTalk.SpecFlow.Assist;

namespace csharp_cucumber_selenium_framework.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private readonly IWebDriver chromeDriver;
        private readonly LoginPage loginPage;
        private readonly UserAccountPage userAccountPage;


        public LoginStepDefinitions(IWebDriver driver)
        {
            this.chromeDriver = driver;

            this.loginPage = new LoginPage(driver);
            this.userAccountPage = new UserAccountPage(driver);
        }


        [Given(@"I enter following for login")]
        public void GivenIEnterFollowingForLogin(Table table)
        {
            foreach (var row in table.CreateSet<CredentialsRow>())
            {
                loginPage.ProvideUsername(row.Username);
                loginPage.ProvidePassword(row.Password);
            }
        }

        [When(@"I click login button")]
        public void WhenIClickLoginButton()
        {
            loginPage.ClickLogin();
        }

        [Then(@"I should be able to access the protected area")]
        public void ThenIShouldBeAbleToAccessTheProtectedArea()
        {
            Assert.That(userAccountPage.displayAdminDashboard(), Is.True, "Admin Dashboard Is not displayed");
        }

        [Given(@"I enter following values to login")]
        public void GivenIEnterFollowingValuesToLogin(Table table)
        {
            var specValues = table.CreateInstance<LoginSpecValues>();

            loginPage.ProvideUsername(specValues.Username);
            loginPage.ProvidePassword(specValues.Password);
        }


        private class LoginSpecValues
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        private class CredentialsRow
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
