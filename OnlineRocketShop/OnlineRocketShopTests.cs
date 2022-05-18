using System;
using System.Text.RegularExpressions;
using NUnit.Framework;
using OnlineRocketShop.Pages.CartPage;
using OnlineRocketShop.Pages.CheckoutPage;
using OnlineRocketShop.Pages.MainPage;
using OnlineRocketShop.Pages.MyAccountPage;
using OnlineRocketShop.Pages.MyOrdersPage;
using OnlineRocketShop.Pages.OrderRecievedPage;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace OnlineRocketShop
{
    public class OnlineRocketShopTests : IDisposable
    {
        private static EventFiringWebDriver _driver;
        private static MainPage _mainPage;
        private static CartPage _cartPage;
        private static CheckoutPage _checkoutPage;
        private static MyAccountPage _myAccountPage;
        private static MyOrdersPage _myOrdersPage;
        private static OrderRecievedPage _orderRecievedPage;

        public OnlineRocketShopTests()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            _driver = new EventFiringWebDriver(new ChromeDriver());

            _driver.Navigated += WebDriverEventHandler.FiringDriver_Navigated;
            _driver.Navigating += WebDriverEventHandler.FiringDriver_Navigating;
            _driver.ElementClicking += WebDriverEventHandler.FiringDriver_Clicking;
            _driver.ElementClicked += WebDriverEventHandler.FiringDriver_Clicked;
            _driver.ScriptExecuting += WebDriverEventHandler.FiringDriver_JavaScriptExecuting;
            _driver.ScriptExecuted += WebDriverEventHandler.FiringDriver_JavaScriptExecuted;

            _mainPage = new MainPage(_driver);
            _cartPage = new CartPage(_driver);
            _checkoutPage = new CheckoutPage(_driver);
            _myAccountPage = new MyAccountPage(_driver);
            _myOrdersPage = new MyOrdersPage(_driver);
            _orderRecievedPage = new OrderRecievedPage(_driver);
        }

        [SetUp]
        public void Setup()
        {
            _driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TestCleanup()
        {
            WebDriverEventHandler.PerformanceTimingService.GenerateReport();
        }

        [Test]
        [TestCase("proton-rocket")]
        public void NewAccountCreated_When_OrderPlacedByNewUser(string rocketName)
        {
            _mainPage.AddItemToCartWithoutAccount(rocketName);
            _cartPage.ProceedToCheckoutFromCartPage();
            _checkoutPage.AssertCheckOutLabelDisplayed("Checkout");
            _checkoutPage.FillingBillingDetails(new BillingInfo
            {
                FirstName = "Ivaylo",
                LastName = "Dimitrov",
                CompanyName = "ATP",
                CountryName = "Bulgaria",
                Address1 = "Sputnik",
                Address2 = "102",
                CityName = "Sofia",
                ZipCode = "213123",
                PhoneNumber = "088888888",
                Email = "ivaylo4201o.dimg@gmail.com"
            });
            _checkoutPage.PlaceOrder();

            _orderRecievedPage.AssertOrderRecieved("ivaylo4201o.dimg@gmail.com");
        }

        [Test]
        [TestCase("ivaylo.dimg@gmail.com", "Qwerty12345678987654321!", "proton-rocket", "Ivaylo", "Dimitrov", "ATP")]
        public void BillingInfoPrefilled_When_ProceedingToCheckoutWithExistingAccount(string userEmail, string password, string rocketName, string userFirstName, string userLastName, string userCompany)
        {
            _myAccountPage.LoginWithExistingUsernameAndPassword(userEmail, password);
            _myAccountPage.GoToHomePageFromMyAccountPage();
            _mainPage.AddRocketToCart(rocketName);
            _cartPage.ProceedToCheckoutFromCartPage();

            _checkoutPage.AssertCheckOutLabelDisplayed("Checkout");
            _checkoutPage.AssertBillingInformationPrefilledOnCheckout(userFirstName, userLastName, userCompany, userEmail);
        }

        [Test]
        [TestCase("proton-rocket")]
        public void OrdersShownInMyAccount_When_PurchasingItem_And_ComparingOrderNumber(string rocketName)
        {
            _mainPage.AddItemToCartWithoutAccount(rocketName);
            _cartPage.ProceedToCheckoutFromCartPage();
            _checkoutPage.FillingBillingDetails(new BillingInfo
            {
                FirstName = "Ivo",
                LastName = "Dimitrov",
                CompanyName = "ATP",
                CountryName = "Bulgaria",
                Address1 = "Sputnik",
                Address2 = "102",
                CityName = "Sofia",
                ZipCode = "213123",
                PhoneNumber = "088888888",
                Email = "ivso1321231231231.dimg@gmail.com"
            });
            _checkoutPage.PlaceOrder();

            _orderRecievedPage.AssertOrderRecieved("ivso1321231231231.dimg@gmail.com");

            var expectedOrderLabelFromOrderRecievedPage = "#" + Int32.Parse(Regex.Replace(_orderRecievedPage.OrderRecievedPageOrderLabel.Text, @"[^\d]+", "").Trim());
            _orderRecievedPage.GoToMyAccountPage();
            _myAccountPage.CheckOrdersInMyAccount();
            
            _myOrdersPage.AssertOrdersShownInMyAccount(expectedOrderLabelFromOrderRecievedPage);
        }

        [Test]
        [TestCase("falcon-9", "happybirthday")]
        public void CouponApplied_When_ApplyingHappyBirthdayCoupon(string rocketName, string couponName)
        {
            _mainPage.AddItemToCartWithoutAccount(rocketName);
            _cartPage.ApplyCouponByCouponName(couponName);

            _cartPage.AssertCouponApplied("Coupon code applied successfully.");
        }

        [Test]
        [TestCase("falcon-9")]
        public void QuantityIncreasedToThree_When_AddingItemToCart_And_IncreasingQuantity(string rocketName)
        {
            _mainPage.AddItemToCartWithoutAccount(rocketName);
            _cartPage.IncreaseProductQuantityInCartByNumber(3);

            _cartPage.AssertQuantityIncreasedInCartPage("3 items");

            _cartPage.ProceedToCheckoutFromCartPage();
            _checkoutPage.FillingBillingDetails(new BillingInfo
            {
                FirstName = "Ivaylo",
                LastName = "Dimitrov",
                CompanyName = "ATP",
                CountryName = "Bulgaria",
                Address1 = "Sputnik",
                Address2 = "102",
                CityName = "Sofia",
                ZipCode = "213123",
                PhoneNumber = "088888888",
                Email = "ivaylo.dimg@gmail.com"
            });

            _checkoutPage.AssertQuantityIncreasedInCheckoutPageByNumber(3);

            _checkoutPage.PlaceOrder();

            _myOrdersPage.AssertQuantityIncreasedInOrdersPageByNumber(3);
        }

        public void Dispose()
        {
            _driver.Quit();
        }
    }
}