using NUnit.Framework;
using OnlineRocketShop.Pages.CartPage;
using OnlineRocketShop.Pages.CheckoutPage;
using OnlineRocketShop.Pages.MainPage;
using OnlineRocketShop.Pages.MyAccountPage;
using OnlineRocketShop.Pages.OrdersPage;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace OnlineRocketShop
{
    public class Tests : IDisposable
    {
        private static IWebDriver _driver;
        private static MainPage _mainPage;
        private static CartPage _cartPage;
        private static CheckoutPage _checkoutPage;
        private static MyAccountPage _myAccountPage;
        private static OrdersPage _ordersPage;

        public Tests()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            _driver = new ChromeDriver();
            _mainPage = new MainPage(_driver);
            _cartPage = new CartPage(_driver);
            _checkoutPage = new CheckoutPage(_driver);
            _myAccountPage = new MyAccountPage(_driver);
            _ordersPage = new OrdersPage(_driver);
        }

        [SetUp]
        public void Setup()
        {
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void NewAccountCreated_When_OrderPlacedByNewUser([Values("falcon-9")] string rocketName)
        {
            _mainPage.AddItemToCart(rocketName);
            _cartPage.ProceedToCheckout();
            _checkoutPage.AssertionCheckOutLabelDisplayed_When_ProceedingWithOrder();
            _checkoutPage.FillingBillingDetails("asdf", "Dimitrov", "ATP", "Bulgaria", "Spatnik", "12", "Stara Zagora", "Stara Zagora", "asdf", "08888888888", "asdf.asdf@asdf.asdf");
            _ordersPage.AddOrderNumberToFile("Ivaylo");
            _checkoutPage.AssertionOrderRecieved_With_InitializeBillingInfoEmail("asdf.asdf@asdf.asdf");
        }

        [Test]
        public void BillingInfoPrefilled_When_PurchaseRocketWithCreatedAccount([Values("ivaylo.dimg@gmail.com")] string uEmail, [Values("Qwerty12345678987654321!")] string password, [Values("proton-rocket")] string rocketName, [Values("Ivaylo")] string uFirstName, [Values("Dimitrov")] string uLastName, [Values("ATP")] string uCompany)
        {
            _myAccountPage.LoginWithExistingAccount(uEmail, password);
            _myAccountPage.GoToHomePage();
            _mainPage.AddRocketToCart(rocketName);
            _cartPage.ProceedToCheckout();
            _checkoutPage.AssertionCheckOutLabelDisplayed_When_ProceedingWithOrder();
            _checkoutPage.AssertionBillingFilled_When_LoggingInWithExistingAccount(uFirstName, uLastName, uCompany, uEmail);
            _checkoutPage.PlaceOrder();
            _ordersPage.AddOrderNumberToFile(uFirstName);
        }

        [Test]
        public void PresentOrdersShown_When_LogingInWithExistingAccount([Values("ivaylo.dimg@gmail.com")] string uEmail, [Values("Qwerty12345678987654321!")] string password)
        {
            _myAccountPage.LoginWithExistingAccount(uEmail, password);
            _myAccountPage.CheckOrders();
            _ordersPage.AddOrderNumberToList("Ivaylo");
            _ordersPage.AssertionOrdersListCount();
        }

        [Test]
        public void IsCouponUsed_When_ApplyingHappyBirthdayCoupon([Values("falcon-9")] string rocketName, [Values("happybirthday")] string couponName)
        {
            _mainPage.AddItemToCart(rocketName);
            _cartPage.AddCoupon(couponName);
            _cartPage.AssertionCouponAdded_When_UsesHappyBirthdayCoupon();
        }

        [Test]
        public void IsQuantityIncreasedToThree_When_AddingItemToCart_And_IncreasingQuantity([Values("falcon-9")]string rocketName)
        {
            _mainPage.AddItemToCart(rocketName);
            _cartPage.IncreaseQuantitybyThree();
            _cartPage.AssertionQuantityIncreasedInCartPage_When_IncreasingQuantityByThree();
            _cartPage.ProceedToCheckout();
            _checkoutPage.FillingBillingDetails("asdtsf", "Dimitrov", "ATP", "Bulgaria", "Spatnik", "12", "Stara Zagora", "Stara Zagora", "asdf", "08888888888", "asdtsf.asdf@asdf.asdf");
            _checkoutPage.AssertionQuantityIncreasedInCheckoutPage_With_IncreasingQuantityByThree();
            _ordersPage.AddOrderNumberToFile("asdtsf");
            _ordersPage.AssertionQuantityIncreasedInOrdersPage_When_IncreasesQuantityByThree();
        }

        public void Dispose()
        {
            _driver.Quit();
        }
    }
}