using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using TundraSeleniumTests.Pages;

namespace TundraSeleniumTests
{
    public class Tests
    {
        IWebDriver driver;


        [SetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();
            driver.Url = "https://www.tundra.com/search?q=*&c=USA";
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login("test@tundra.com", "test@tundra.com");
        }

        [Test]
        public void Navigate_To_Products_Page_Verify_15_Initial_Products_Are_Loaded_And_30_More_On_Each_Load()
        {
            BasePage basePage = new BasePage(driver);
            ProductsPage productsPage = new ProductsPage(driver);
            Assert.AreEqual(15, productsPage.GetTotalAmountOfProductsOnPage());
            basePage.VerifyPageElementsArePresent();
            Helpers.Helpers.ScrollToBottomOfPage(driver);
            productsPage.WaitForLoadingSpinnerToDisappear();
            Assert.AreEqual(30, productsPage.GetTotalAmountOfProductsOnPage());
            Helpers.Helpers.ScrollToBottomOfPage(driver);
            productsPage.WaitForLoadingSpinnerToDisappear();
            Assert.AreEqual(45, productsPage.GetTotalAmountOfProductsOnPage());
        }
        [Test]
        public void Navigate_To_Products_Page_Verify_Each_Loaded_Product_Has_Name()
        {
            BasePage basePage = new BasePage(driver);
            ProductsPage productsPage = new ProductsPage(driver);
            Assert.IsTrue(productsPage.VerifyEachProductHasProductName());
        }

        [Test]
        public void Navigate_To_Products_Page_Select_Product_Verify_Product_Details_Has_Same_Product_Name()
        {
            BasePage basePage = new BasePage(driver);
            ProductsPage productsPage = new ProductsPage(driver);
            string productName = productsPage.SelectFirstProduct();
            ProductDetailsPage productDetailsPage = new ProductDetailsPage(driver);
            Assert.AreEqual(productDetailsPage.GetProductName(), productName);
        }

        [Test]
        public void Navigate_To_Products_Page_Select_Product_Add_Product_To_Cart_Verify_Product_Added_To_Cart()
        {
            BasePage basePage = new BasePage(driver);
            ProductsPage productsPage = new ProductsPage(driver);
            productsPage.SelectFirstProduct();
            ProductDetailsPage productDetailsPage = new ProductDetailsPage(driver);
            productDetailsPage.AddProductToCart();
            basePage.VerifyAmountOfCartItemsIsCorrect(1);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}