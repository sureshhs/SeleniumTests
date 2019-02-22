using OpenQA.Selenium;

namespace SeleniumProject
{
    class BasePage
    {
        IWebDriver driver;
        public BasePage(IWebDriver _driver) => this.driver = _driver;

    }
}
