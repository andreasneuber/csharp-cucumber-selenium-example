using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.BoDi;
using System.Configuration;

// Example of filtering hooks using tags
// See https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html?highlight=hooks#tag-scoping
// Example of ordering the execution of hooks
// See https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html?highlight=order#hook-execution-order

// See also https://stackoverflow.com/questions/58409700/using-chromedriver-across-specflow-tests


namespace csharp_cucumber_selenium_framework
{
    [Binding]
    public sealed class Hooks
    {
        private readonly IObjectContainer container;

        public Hooks(IObjectContainer container)
        {
            this.container = container;
        }


        [BeforeScenario]
        public void CreateWebDriver()
        {
            BrowserFactory factory = new BrowserFactory(ConfigurationManager.AppSettings["Browser"]);

            // Make 'driver' available for DI (Dependency Injection)
            container.RegisterInstanceAs<IWebDriver>(factory.browser);
        }


        [AfterScenario]
        public void DestroyWebDriver()
        {
            var driver = container.Resolve<IWebDriver>();

            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}
