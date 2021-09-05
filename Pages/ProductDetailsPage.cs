using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;

namespace TundraSeleniumTests.Pages
{
    class ProductDetailsPage
    {

        private IWebDriver driver;
        private WebDriverWait wait;


        public ProductDetailsPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "h1[data-cy='product-details-product-name-text']")]
        [CacheLookup]
        private IWebElement productName;

        [FindsBy(How = How.CssSelector, Using = "button[data-cy='product-details-add-to-cart-button']")]
        [CacheLookup]
        private IWebElement productAddToCart;
        

        public string GetProductName()
        {
            return productName.Text;
        }

        public void AddProductToCart()
        {
            productAddToCart.Click();
        }
    }
}
