using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumProject
{
    class HomePage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Name, Using = "lang")]
        private IWebElement languageSelection;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        //public HomePage(IWebDriver _driver) => driver = _driver;

        //IWebElement languageSelection => driver.FindElement(By.Name("lang"));

        public void SelectLanguage(string newLanguage)
        {
            languageSelection.SelectOption(newLanguage);
        }
    }
}
