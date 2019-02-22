using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumProject
{
    public static class WebElementExtensionHelper
    {
        public static void EnterText(this IWebElement element, string text)
        {
            element.SendKeys(text);
        }

        public static void SelectOption(this IWebElement element, string newOption)
        {
            SelectElement dropdown = new SelectElement(element);

            foreach (IWebElement option in dropdown.Options)
            {
                string language = option.GetAttribute("text");

                if (language == newOption)
                {
                    option.Click();
                    return;
                }
            }
            throw new NoSuchElementException("Selection not found");
        }
    }
}
