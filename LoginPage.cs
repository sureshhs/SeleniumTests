using OpenQA.Selenium;

namespace SeleniumProject
{
    class LoginPage 
    {
        private IWebDriver driver;

        // Page fatcory is obsolete from selenium 3.11, since selenium uses methods supported by .NET page creation
        //public LoginPage(IWebDriver driver)
        //{
        //    PageFactory.InitElements(driver, this);
        //    this.driver = driver; 
        //}

        //[FindsBy(How = How.Id, Using = "inputEmailHandle")]
        //public IWebElement userName { get; set;}

        //[FindsBy(How = How.Id, Using = "inputPassword")]
        //public IWebElement password { get; set;}

        //[FindsBy(How = How.ClassName, Using = "accountform-btn")]
        //public IWebElement loginButton { get; set; }

        public LoginPage(IWebDriver _driver) => this.driver = _driver;

        IWebElement userName => driver.FindElement(By.Id("inputEmailHandle"));
        IWebElement password => driver.FindElement(By.Id("inputPassword"));
        IWebElement loginButton => driver.FindElement(By.ClassName("accountform-btn"));

        public LandingPage Login(string user, string pass)
        {
            //userName.SendKeys(user);
            userName.EnterText(user);
            //password.SendKeys(pass);
            password.EnterText(pass);
            loginButton.Submit();

            return new LandingPage(driver);
        }
    }
}
