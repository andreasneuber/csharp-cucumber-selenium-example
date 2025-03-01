using OpenQA.Selenium;

// https://blog.testproject.io/2020/11/09/page-object-model-in-selenium-using-c-sharp-nunit-reporting/

namespace csharp_cucumber_selenium_framework.Pages
{
    public class CreditCardResponsePage : BasePage
    {
        private readonly IWebDriver driver;

        public string URL = "/index.php?action=responsecc";


        private readonly string txtResponse = "//strong[@class='response']";
        private readonly string txtMoreInfo = "//span[@class='more-info']";
        private readonly string alertMessage = "//div[contains(@class, 'alert')]";


        public CreditCardResponsePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetUrl()
        {
            return this.GetBaseUrl() + this.URL;
        }



        public bool GetAlertMessageBox()
        {
            return IsDisplayed(driver, alertMessage);
        }

        public string GrabResponseFromAlertBox()
        {
            return GrabTextFromElement(driver, txtResponse);
        }

        public string GrabMoreInfoFromAlertBox()
        {
            return GrabTextFromElement(driver, txtMoreInfo);
        }
    }
}
