using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;

namespace TundraSeleniumTests.Pages
{
    class LoginPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;


        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "username")]
        [CacheLookup]
        private IWebElement username;


        [FindsBy(How = How.Name, Using = "password")]
        [CacheLookup]
        private IWebElement password;

        [FindsBy(How = How.CssSelector, Using = "button[type='submit']")]
        [CacheLookup]
        private IWebElement signIn;

        public void Login(string usernameValue, string passwordValue)
        {
            BasePage basePage = new BasePage(driver);
            basePage.ClickLogin();
            username.SendKeys(usernameValue);
            password.SendKeys(passwordValue);
            signIn.Click();
        }
    }
}
