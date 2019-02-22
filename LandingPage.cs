using OpenQA.Selenium;

namespace SeleniumProject
{
    class LandingPage
    {
        private IWebDriver driver;

        //[FindsBy(How = How.LinkText, Using = "craigslist")]
        //IWebElement homeLink;

        //public LandingPage(IWebDriver driver)
        //{
        //    this.driver = driver;
        //    PageFactory.InitElements(driver, this);
        //}
        public LandingPage(IWebDriver _driver) => this.driver = _driver;
        IWebElement homeLink => driver.FindElement(By.LinkText("craigslist"));

        public HomePage NavigateToHomePage()
        {
            homeLink.Click();
            return new HomePage(this.driver);
        }
    }
}
