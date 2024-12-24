using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Configuration;

namespace csharp_cucumber_selenium_framework.Pages
{
    public class BasePage
    {
        private string baseUrl = ConfigurationManager.AppSettings["BaseUrl"];
        protected WebDriverWait wait;

        public string GetBaseUrl()
        {
            return baseUrl;
        }

        public bool IsDisplayed(IWebDriver driver, string xPathLocator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            bool isDisplayed = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPathLocator))).Displayed;
            return isDisplayed;
        }

        public void FillField(IWebDriver driver, string xPathLocator, string value)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPathLocator))).SendKeys(value);
        }

        public void ClearAndFillField(IWebDriver driver, string xPathLocator, string value)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement field = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPathLocator)));

            field.Clear();
            field.SendKeys(value);
        }

        public void ClickOn(IWebDriver driver, string xPathLocator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xPathLocator))).Click();
        }

        public string GrabTextFromElement(IWebDriver driver, string xPathLocator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPathLocator)));
            return element.Text;
        }

        public string GrabValueFromAttribute(IWebDriver driver, string xPathLocator, string attributeName)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPathLocator)));
            return element.GetDomAttribute(attributeName);
        }
    }
}
