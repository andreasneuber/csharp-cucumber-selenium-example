using csharp_cucumber_selenium_framework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace csharp_cucumber_selenium_framework.StepDefinitions
{
    [Binding]
    public class ConvertCelsiusStepDefinitions
    {
        private readonly IWebDriver chromeDriver;
        private readonly CelsiusToFahrenheitPage convertCelsiusPage;


        public ConvertCelsiusStepDefinitions(IWebDriver driver)
        {
            this.chromeDriver = driver;
            this.convertCelsiusPage = new CelsiusToFahrenheitPage(driver);
        }


        [Given(@"I provide ""([^""]*)"" degree Celsius")]
        public void GivenIProvideDegreeCelsius(string celsius)
        {
            string url = convertCelsiusPage.GetUrl();
            chromeDriver.Navigate().GoToUrl(url);
            convertCelsiusPage.ProvideCelsius(celsius);
        }

        [When(@"I click the convert button")]
        public void WhenIClickTheConvertButton()
        {
            convertCelsiusPage.ClickConvert();
        }

        [Then(@"I should see as result ""([^""]*)"" Fahrenheit")]
        public void ThenIShouldSeeAsResultFahrenheit(string expectedFahrenheit)
        {
            string actualFahrenheit = convertCelsiusPage.ReadFahrenheitField();
            Assert.That(expectedFahrenheit, Is.EqualTo(actualFahrenheit));
        }
    }
}
