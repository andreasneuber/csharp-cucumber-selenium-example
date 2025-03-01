using OpenQA.Selenium;

// https://blog.testproject.io/2020/11/09/page-object-model-in-selenium-using-c-sharp-nunit-reporting/

namespace csharp_cucumber_selenium_framework.Pages
{
    public class ProvideYourDetailsPage : BasePage
    {
        private readonly IWebDriver driver;

        public string URL = "/index.php?action=form1";

        private readonly string inputFirstName = "//input[@id='fname']";
        private readonly string inputLastName = "//input[@id='lname']";
        private readonly string inputStreet = "//input[@id='street']";
        private readonly string inputCity = "//input[@id='city']";
        private readonly string inputZip = "//input[@id='zip']";
        private readonly string inputState = "//input[@id='state']";
        private readonly string inputCountry = "//input[@id='country']";
        private readonly string inputMobilePhoneNumber = "//input[@id='mobile']";
        private readonly string inputHomePhoneNumber = "//input[@id='home']";
        private readonly string inputEmail = "//input[@id='email']";
        private readonly string btnSubmit = "//input[@id='submit-info']";
        // private readonly string titleForm = "//h2[contains(text(),'Form 1 - Information about yourself')]";


        public ProvideYourDetailsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetUrl()
        {
            return this.GetBaseUrl() + this.URL;
        }


        public void ProvideFirstname(string firstName)
        {
            FillField(driver, inputFirstName, firstName);
        }

        public void ProvideLastname(string lastName)
        {
            FillField(driver, inputLastName, lastName);
        }

        public void ProvideStreet(string street)
        {
            FillField(driver, inputStreet, street);
        }

        public void ProvideCity(string city)
        {
            FillField(driver, inputCity, city);
        }

        public void ProvideZip(string zipCode)
        {
            FillField(driver, inputZip, zipCode);
        }

        public void ProvideState(string state)
        {
            FillField(driver, inputState, state);
        }

        public void ProvideCountry(string country)
        {
            FillField(driver, inputCountry, country);
        }

        public void ProvideMobilePhoneNumber(string number)
        {
            FillField(driver, inputMobilePhoneNumber, number);
        }

        public void ProvideHomePhoneNumber(string number)
        {
            FillField(driver, inputHomePhoneNumber, number);
        }

        public void ProvideEmail(string email)
        {
            FillField(driver, inputEmail, email);
        }

        public void ClickSubmitYourInformation()
        {
            ClickOn(driver, btnSubmit);
        }
    }
}
