using OpenQA.Selenium;

// https://blog.testproject.io/2020/11/09/page-object-model-in-selenium-using-c-sharp-nunit-reporting/

namespace csharp_cucumber_selenium_framework.Pages
{
    public class CelsiusToFahrenheitPage : BasePage
    {
        private readonly IWebDriver driver;

        public string URL = "/index.php?action=form6";

        private readonly string inputCelsius = "//input[@name='celsius']";
        private readonly string inputFahrenheit = "//input[@name='fahrenheit']";
        private readonly string btnCelsius = "//input[@id='btnCelsius']";



        public CelsiusToFahrenheitPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetUrl()
        {
            return this.GetBaseUrl() + this.URL;
        }


        public void ProvideCelsius(string celsiusDegrees)
        {
            ClearAndFillField(driver, inputCelsius, celsiusDegrees);
        }

        public void ClickConvert()
        {
            ClickOn(driver, btnCelsius);
        }

        public string ReadFahrenheitField()
        {
            return GrabValueFromAttribute(driver, inputFahrenheit, "value");
        }
    }
}
