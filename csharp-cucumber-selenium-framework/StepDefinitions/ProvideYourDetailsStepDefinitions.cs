using csharp_cucumber_selenium_framework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
// using TechTalk.SpecFlow.Assist;

namespace csharp_cucumber_selenium_framework.StepDefinitions
{
    [Binding]
    public class ProvideYourDetailsStepDefinitions
    {
        private readonly IWebDriver chromeDriver;
        private readonly ProvideYourDetailsPage provideYourDetailsPage;
        private readonly ThankYouPage thankYouPage;



        public ProvideYourDetailsStepDefinitions(IWebDriver driver)
        {
            this.chromeDriver = driver;

            this.provideYourDetailsPage = new ProvideYourDetailsPage(driver);
            this.thankYouPage = new ThankYouPage(driver);
        }


        [Given(@"I navigate to Information about yourself page")]
        public void GivenINavigateToInformationAboutYourselfPage()
        {
            string url = provideYourDetailsPage.GetUrl();
            chromeDriver.Navigate().GoToUrl(url);
        }

        [When(@"I provide the following details")]
        public void WhenIProvideTheFollowingDetails(Table table)
        {
            var specValues = table.CreateInstance<YourDetailsValues>();

            provideYourDetailsPage.ProvideFirstname(specValues.Firstname);
            provideYourDetailsPage.ProvideLastname(specValues.Lastname);
            provideYourDetailsPage.ProvideStreet(specValues.Street);
            provideYourDetailsPage.ProvideCity(specValues.City);
            provideYourDetailsPage.ProvideZip(specValues.Zip);
            provideYourDetailsPage.ProvideState(specValues.State);
            provideYourDetailsPage.ProvideCountry(specValues.Country);
            provideYourDetailsPage.ProvideMobilePhoneNumber(specValues.MobilePhone);
            provideYourDetailsPage.ProvideHomePhoneNumber(specValues.HomePhone);
            provideYourDetailsPage.ProvideEmail(specValues.Email);

            provideYourDetailsPage.ClickSubmitYourInformation();
        }

        [Then(@"I will see message ""([^""]*)""")]
        public void ThenIWillSeeMessage(string expectedMessage)
        {
            string actualMessage = thankYouPage.GrabThankYouMessage();
            Assert.That(expectedMessage, Is.EqualTo(actualMessage),"Expected thank you message does not appear.");
        }


        private class YourDetailsValues
        {
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            public string Street { get; set; }
            public string City { get; set; }
            public string Zip { get; set; }
            public string State { get; set; }
            public string Country { get; set; }
            public string MobilePhone { get; set; }
            public string HomePhone { get; set; }
            public string Email { get; set; }
        }
    }
}
