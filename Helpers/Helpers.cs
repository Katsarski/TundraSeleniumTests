using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace TundraSeleniumTests.Helpers
{
    public static class Helpers
    {

        
        public static int GetIWebElementsCount(IList<IWebElement> webElements)
        {
            int count = 0;
            foreach (var webElement in webElements)
            {
                count++;
            }
            return count;
        }

        public static void ScrollToBottomOfPage(IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        }

        public static void WaitForPageToLoad(IWebDriver driver)
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }



    }
}
