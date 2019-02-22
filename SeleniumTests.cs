using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SeleniumProject
{
    [TestClass]
    public class SeleniumTests
    {
        [TestMethod]
        public void SeleniumControls()
        {
            using (var driver = new ChromeDriver())
            {
                //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
                //driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(5));
                driver.Navigate().GoToUrl("http://toolsqa.wpengine.com/automation-practice-form/");
                driver.Manage().Window.Maximize();

                IWebElement fullLink = driver.FindElement(By.LinkText("Link Test"));
                fullLink.Click();
                Console.WriteLine("Link test is successfull ");
                Thread.Sleep(2000);
                driver.Navigate().Back();

                IWebElement partialLink = driver.FindElement(By.PartialLinkText("Partial"));
                partialLink.Click();
                Console.WriteLine("Partial link test is successfull");

                var firstName = driver.FindElementByName("firstname");
                firstName.SendKeys("Suresh");
                Thread.Sleep(2000);

                // To find radio button (for male or female), search for element name "sex"
                IList<IWebElement> radioButtons = driver.FindElements(By.Name("sex"));
                bool selectedFlag = radioButtons.ElementAt(0).Selected;
                Console.WriteLine("select the radio button : male or female");
                // If first radio button is not selected, then select it otherwiese select second radio button
                if (selectedFlag)
                {
                    radioButtons.ElementAt(1).Click(); // select second radion button "female"
                }
                else
                {
                    radioButtons.ElementAt(0).Click(); // select radio button "male"
                }
                Thread.Sleep(2000);

                Console.WriteLine("Select the radio button for No of years of experience - 4");
                IList<IWebElement> radioButtonsExperience = driver.FindElements(By.Name("exp"));
                radioButtonsExperience.ElementAt(3).Click();
                Thread.Sleep(2000);

                IList<IWebElement> checkBoxesProfession = driver.FindElements(By.Name("profession"));
                for (int i = 0; i < checkBoxesProfession.Count; i++)
                {
                    string value = checkBoxesProfession.ElementAt(i).GetAttribute("value");
                    Console.WriteLine("Check box value - {0}", value);

                    if (value == "Automation Tester")
                    {
                        checkBoxesProfession.ElementAt(i).Click();
                        break;
                    }
                }
                Thread.Sleep(2000);

                SelectElement continetsDropdown = new SelectElement(driver.FindElement(By.Id("continents")));
                continetsDropdown.SelectByText("Africa");
                Thread.Sleep(3000);
                continetsDropdown.SelectByIndex(5);
                Thread.Sleep(2000);
                //IList<IWebElement> webElements = dropdown.Options;

                Console.WriteLine("Print combo box selections");
                foreach (var option in continetsDropdown.Options)
                {
                    Console.WriteLine(option.Text);
                }

                SelectElement multipleSelections = new SelectElement(driver.FindElementById("selenium_commands"));
                Console.WriteLine("Print combo box selections(multiple)");
                foreach (var sel in multipleSelections.Options)
                {
                    Console.WriteLine(sel.Text);
                    multipleSelections.SelectByText(sel.Text);
                }
                Thread.Sleep(3000);
                multipleSelections.DeselectAll(); ;
                Thread.Sleep(2000);
               
                driver.Quit();
            }
        }

        [TestMethod]
        public void CraigsListTest()
        {
            using (var driver = new ChromeDriver())
            {
                driver.Manage().Window.Maximize();
                //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5)); // OBSOLETE
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                //driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(5)); // OBSOLETE
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);

                driver.Navigate().GoToUrl("https://accounts.craigslist.org/login");
                LoginPage loginPage = new LoginPage(driver);
                LandingPage landingPage = loginPage.Login("sureshhs@yahoo.com", "Howtobuy@12");

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                //Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver webDriver) =>
                //{
                //    Console.WriteLine("Trying to wait for element");
                //    webDriver.FindElement(By.LinkText("craigslist"));
                //    return true;
                //});
                //wait.Until(waitForElement);
                // one liner code for above func delegate
                //wait.Until(d => d.FindElement(By.LinkText("craigslist")));

                // ExpectedConditions is OBSOLETE IN SELENIUM 3.11
                // wait.Until(ExpectedConditions.ElementExists(By.LinkText("craigslist")));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.LinkText("craigslist")));
                HomePage homePage = landingPage.NavigateToHomePage();
                Thread.Sleep(2000);
                //homePage.SelectLanguage("italiano");
                //Thread.Sleep(2000);
                //homePage.SelectLanguage("english");
                //Thread.Sleep(2000);
                driver.Quit();
            }
        }
    }
}
