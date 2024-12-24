using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace csharp_cucumber_selenium_framework
{
    public class BrowserFactory
    {
        public IWebDriver browser;

        // This gets the Chromedriver from the Nuget package
        private readonly string LocationNuGetChromeDriver = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public BrowserFactory(string browserName) {

            switch (browserName)
            {
                case "chrome":
                    this.browser = this.SetChrome();
                    break;
                case "chrome_headless":
                    this.browser = this.SetChromeHeadless();
                    break;
                case "firefox":
                    this.browser = this.SetFirefox();
                    break;
                case "edge":
                    this.browser = this.SetEdge();
                    break;
                case "safari":
                    this.browser = this.SetSafari();
                    break;
                default:
                    this.browser = null;
                    break;
            }
        }


        private ChromeDriver SetChrome()
        {
            var options = new ChromeOptions();
            options.AddArguments(new List<string>()
            {

            });
            return new ChromeDriver(LocationNuGetChromeDriver, options);
        }

        private ChromeDriver SetChromeHeadless()
        {
            var options = new ChromeOptions();
            options.AddArguments(new List<string>()
            {
                "--no-sandbox",
                "--headless=new",
            });
            return new ChromeDriver(LocationNuGetChromeDriver, options);
        }

        private FirefoxDriver SetFirefox()
        {
            var options = new FirefoxOptions();
            options.AddArguments(new List<string>() { });
            return new FirefoxDriver(options);
        }

        private EdgeDriver SetEdge()
        {
            var options = new EdgeOptions();
            options.AddArguments(new List<string>() { });
            return new EdgeDriver(options);
        }

        private SafariDriver SetSafari()
        {
            var options = new SafariOptions();
            return new SafariDriver(options);
        }
    }
}
