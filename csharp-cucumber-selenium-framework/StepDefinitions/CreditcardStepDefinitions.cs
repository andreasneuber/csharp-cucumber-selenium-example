using csharp_cucumber_selenium_framework.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Reqnroll;

namespace csharp_cucumber_selenium_framework.StepDefinitions
{
    [Binding]
    public class CreditcardStepDefinitions
    {
        private readonly IWebDriver chromeDriver;
        private readonly CreditCardEntryPage creditCardEntryPage;
        private readonly CreditCardResponsePage creditCardResponsePage;


        public CreditcardStepDefinitions(IWebDriver driver)
        {
            this.chromeDriver = driver;

            this.creditCardEntryPage = new CreditCardEntryPage(driver);
            this.creditCardResponsePage = new CreditCardResponsePage(driver);
        }


        [Given(@"User is on card card entry page")]
        public void GivenUserIsOnCardCardEntryPage()
        {
            string url = creditCardEntryPage.GetUrl();
            chromeDriver.Navigate().GoToUrl(url);
        }

        [When(@"User (.*) enters card number (.*) together with expiry date (.*) and cvv (.*)")]
        public void WhenUserEntersCardNumberTogetherWithExpiryDateAndCvv(
            string name, string ccnumber, string expiryDate, string cvv)
        {
            creditCardEntryPage.EnterCardInformation(name, ccnumber, expiryDate, cvv);
            creditCardEntryPage.SubmitPayment();
        }

        [Then(@"the page will respond with (.*) and provide as reason (.*)")]
        public void ThenThePageWillRespondAndProvideAsReasonForIt(
            string expectedResponse,
            string expectedReason)
        {
            Assert.IsTrue(creditCardResponsePage.GetAlertMessageBox(), "Message alert box is not displayed");

            string response = creditCardResponsePage.GrabResponseFromAlertBox();
            Assert.IsTrue(response.Contains(expectedResponse), "Expected response '" + response + "' to contain '"
                    + expectedResponse + "' but string could not be found.");

            string reason = creditCardResponsePage.GrabMoreInfoFromAlertBox();
            Assert.IsTrue(reason.Contains(expectedReason), "Expected reason '" + reason + "' to contain '"
                    + expectedReason + "' but string could not be found.");
        }
    }
}
