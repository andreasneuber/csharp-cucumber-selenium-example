using OpenQA.Selenium;

// https://blog.testproject.io/2020/11/09/page-object-model-in-selenium-using-c-sharp-nunit-reporting/

namespace csharp_cucumber_selenium_framework.Pages
{
    public class CreditCardEntryPage : BasePage
    {
        private readonly IWebDriver driver;

        public string URL = "/index.php?action=form3";

        private readonly string formCreditCardInfoEntry = "//input[@id='ccentry']";
        private readonly string inputCardname = "//input[@id='cname']";
        private readonly string inputCcnumber = "//input[@id='ccnum']";
        private readonly string inputExpirydate = "//input[@id='expdate']";
        private readonly string inputCvv = "//input[@id='cvv']";
        private readonly string btnPayNow = "//input[@id='btnPaynow']";


        public CreditCardEntryPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetUrl()
        {
            return this.GetBaseUrl() + this.URL;
        }


        public void EnterCardInformation(
        string cardname,
        string ccnumber,
        string expiryDate,
        string cvv)
        {
            FillField(driver, inputCardname, cardname);
            FillField(driver, inputCcnumber, ccnumber);
            FillField(driver, inputExpirydate, expiryDate);
            FillField(driver, inputCvv, cvv);
        }

        public void SubmitPayment()
        {
            ClickOn(driver, btnPayNow);
        }

        public bool GetCreditCardInfoEntryForm()
        {
            return IsDisplayed(driver, formCreditCardInfoEntry);
        }
    }
}
