using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace TundraSeleniumTests.Pages
{
    class ProductsPage
    {
        String pageUrl = "https://www.tundra.com/search?q=*&c=USA";

        private IWebDriver driver;
        private WebDriverWait wait;


        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.ClassName, Using = "MuiTabs-flexContainer")]
        [CacheLookup]
        private IWebElement productCategoriesHolder;

        [FindsBy(How = How.CssSelector, Using = "div[data-cy='product-widget-main-div']")]
        [CacheLookup]
        private IList<IWebElement> productsWidget;

        [FindsBy(How = How.XPath, Using = "//[@id='tundra-shop-app']/div[3]/div[1]/div[2]/div[2]/div[1]/div[2]/div/div/div")]
        [CacheLookup]
        private IWebElement orderProductsBy;

        [FindsBy(How = How.CssSelector, Using = "span[data-cy='product-widget-add-to-cart-button-text']")]
        [CacheLookup]
        private IWebElement shoppingCartButton;

        

        private string productNameLocator = "div[data-cy='product-widget-product-name']";


        public void GoToPage()
        {
            driver.Navigate().GoToUrl(pageUrl);
        }

        public int GetTotalAmountOfProductsOnPage()
        {
            productsWidget = driver.FindElements(By.CssSelector("div[data-cy='product-widget-main-div']"));
            return Helpers.Helpers.GetIWebElementsCount(productsWidget);
        }

        public void WaitForLoadingSpinnerToDisappear()
        {
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("MuiCircularProgress-svg")));

        }

        public bool VerifyEachProductHasProductName()
        {
            //Check the name of each product element on the page
            foreach (var webElement in productsWidget)
            {
                var childElement = webElement.FindElement(By.CssSelector(productNameLocator));
                if (String.IsNullOrEmpty(childElement.Text))
                {
                    return false;
                }
            }
            return true;
        }

        public bool VerifyProductHasProductName()
        {
            //Check the name of each product element on the page
            foreach (var webElement in productsWidget)
            {
                var childElement = webElement.FindElement(By.CssSelector(productNameLocator));
                if (String.IsNullOrEmpty(childElement.Text))
                {
                    return false;
                }
            }
            return true;
        }

        public string SelectFirstProduct()
        {
            string firstProductName = productsWidget[0].FindElement(By.CssSelector(productNameLocator)).Text;
            productsWidget[0].Click();
            return firstProductName;
        }

        public String GetPageTitle()
        {
            return driver.Title;
        }
    }
}
