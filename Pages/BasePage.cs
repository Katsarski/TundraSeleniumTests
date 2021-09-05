using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;

namespace TundraSeleniumTests.Pages
{
    public class BasePage
    {
        private IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "img[title='Tundra']")]
        [CacheLookup]
        private IWebElement tundraLogo;

        [FindsBy(How = How.LinkText, Using = "Sign up")]
        [CacheLookup]
        private IWebElement signUp;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Log in')]")]
        [CacheLookup]
        private IWebElement login;

        [FindsBy(How = How.CssSelector, Using = "symbol[id='ico-cart']")]
        [CacheLookup]
        private IWebElement shoppingCart;

        [FindsBy(How = How.CssSelector, Using = "span[data-cy=d-cart-badge]")]
        [CacheLookup]
        private IWebElement shoppingCartAmountOfItems;

        [FindsBy(How = How.CssSelector, Using = "input[placeholder='Search products and brands']")]
        [CacheLookup]
        private IWebElement searchField;

        [FindsBy(How = How.Id, Using = "ico-search")]
        [CacheLookup]
        private IWebElement searchButton;

        public void ClickLogin()
        {
            login.Click();
        }

        public void VerifyPageElementsArePresent()
        {
            if (tundraLogo.Displayed == true)
            {
                Console.WriteLine("Logo is here");
            }
        }

        public bool VerifyAmountOfCartItemsIsCorrect(int expectedAmount)
        {
            if (int.Parse(shoppingCartAmountOfItems.Text) != expectedAmount)
            {
                return false;
            }
            return true;
        }
    }
}
