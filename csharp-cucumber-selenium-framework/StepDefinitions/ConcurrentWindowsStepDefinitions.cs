using csharp_cucumber_selenium_framework.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using System.Diagnostics;

namespace csharp_cucumber_selenium_framework.StepDefinitions
{
    [Binding]
    public class ConcurrentWindowsStepDefinitions
    {
        //private readonly IWebDriver chromeDriver;
        private readonly string baseUrl;
        private readonly IWebDriver orangeFriend;
        private ChromeDriver greenFriend;
        private ChromeDriver brownFriend;

        public ConcurrentWindowsStepDefinitions(IWebDriver driver)
        {
            this.orangeFriend = driver;

            BasePage basePage = new BasePage();
            this.baseUrl = basePage.GetBaseUrl();
        }

        [Given(@"different people went to different sites")]
        public void GivenDifferentPeopleWentToDifferentSites()
        {
            string url = baseUrl + "/index.php?action=orangePage";
            orangeFriend.Navigate().GoToUrl(url);

            greenFriend = HaveFriend();
            url = baseUrl + "/index.php?action=greenPage";
            greenFriend.Navigate().GoToUrl(url);

            brownFriend = HaveFriend();
            url = baseUrl + "/index.php?action=brownPage";
            brownFriend.Navigate().GoToUrl(url);
        }

        [When(@"they realize that they forgot what they actually wanted to do there")]
        public void WhenTheyRealizeThatTheyForgotWhatTheyActuallyWantedToDoThere()
        {
            Debug.Write("Wait a minute ...");

            brownFriend.Navigate().Refresh();
            brownFriend.Navigate().Refresh();
            greenFriend.Navigate().Refresh();
            greenFriend.Navigate().Refresh();
            orangeFriend.Navigate().Refresh();
            orangeFriend.Navigate().Refresh();

            Debug.Write("We forgot that we are so forgetful.");
        }

        [Then(@"they leave the sites again")]
        public void ThenTheyLeaveTheSitesAgain()
        {
            Debug.WriteLine("Brown window stops");
            this.brownFriend.Quit();

            Debug.WriteLine("Green window stops");
            this.greenFriend.Quit();

            Debug.WriteLine("Orange window stops");
            this.orangeFriend.Quit();
        }

        private ChromeDriver HaveFriend()
        {
            return new ChromeDriver();
        }
    }
}
