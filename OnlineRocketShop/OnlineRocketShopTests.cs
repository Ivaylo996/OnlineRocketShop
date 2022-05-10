using NUnit.Framework;
using OnlineRocketShop.Pages.CartPage;
using OnlineRocketShop.Pages.CheckoutPage;
using OnlineRocketShop.Pages.MainPage;
using OnlineRocketShop.Pages.MyAccountPage;
using OnlineRocketShop.Pages.MyOrdersPage;
using OnlineRocketShop.Pages.OrderRecievedPage;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace OnlineRocketShop
{
    public class OnlineRocketShopTests : IDisposable
    {
        private static IWebDriver _driver;
        private static MainPage _mainPage;
        private static CartPage _cartPage;
        private static CheckoutPage _checkoutPage;
        private static MyAccountPage _myAccountPage;
        private static MyOrdersPage _myOrdersPage;
        private static OrderRecievedPage _orderRecievedPage;

        public OnlineRocketShopTests()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            _driver = new ChromeDriver();
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

        [Test]
        [TestCase("proton-rocket")]
        public void NewAccountCreated_When_OrderPlacedByNewUser(string rocketName)
        {
            _mainPage.AddItemToCart(rocketName);
            _cartPage.ProceedToCheckout();
            _checkoutPage.AssertionCheckOutLabelDisplayed();
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
                Email = "ivaylo4o.dimg@gmail.com"
            });
            _checkoutPage.PlaceOrder();

            _orderRecievedPage.AssertionOrderRecieved("ivaylo4o.dimg@gmail.com");
        }

        [Test]
        [TestCase("ivaylo.dimg@gmail.com", "Qwerty12345678987654321!", "proton-rocket", "Ivaylo", "Dimitrov", "ATP")]
        public void BillingInfoPrefilled_When_ProceedingToCheckoutWithExistingAccount(string userEmail, string password, string rocketName, string userFirstName, string userLastName, string userCompany)
        {
            _myAccountPage.LoginWithExistingAccount(userEmail, password);
            _myAccountPage.GoToHomePage();
            _mainPage.AddRocketToCart(rocketName);
            _cartPage.ProceedToCheckout();

            _checkoutPage.AssertionCheckOutLabelDisplayed();
            _checkoutPage.AssertionBillingFilled(userFirstName, userLastName, userCompany, userEmail);
        }

        [Test]
        [TestCase("proton-rocket")]
        public void OrdersShownInMyAccount_When_PurchasingItem_And_ComparingOrders(string rocketName)
        {
            _mainPage.AddItemToCart(rocketName);
            _cartPage.ProceedToCheckout();
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
                Email = "ivso13.dimg@gmail.com"
            });
            _checkoutPage.PlaceOrder();

            _orderRecievedPage.AssertionOrderRecieved("ivso13.dimg@gmail.com");

            _myOrdersPage.GetOrderTextFromOrderRecieved(_orderRecievedPage.AddValueToOrderNumberLabel());
            _orderRecievedPage.GoToMyAccount();
            _myAccountPage.CheckOrders();

            _myOrdersPage.AssertionOrdersShownInMyAccount();
        }

        [Test]
        [TestCase("falcon-9", "happybirthday")]
        public void CouponUsed_When_ApplyingHappyBirthdayCoupon(string rocketName, string couponName)
        {
            _mainPage.AddItemToCart(rocketName);
            _cartPage.AddCoupon(couponName);

            _cartPage.AssertionCouponAdded("Coupon code applied successfully.");
        }

        [Test]
        [TestCase("falcon-9")]
        public void QuantityIncreasedToThree_When_AddingItemToCart_And_IncreasingQuantity(string rocketName)
        {
            _mainPage.AddItemToCart(rocketName);
            _cartPage.IncreaseQuantity(3);
            _cartPage.AssertionQuantityIncreasedInCartPage("3 items");
            _cartPage.ProceedToCheckout();
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

            _checkoutPage.AssertionQuantityIncreasedInCheckoutPage();

            _checkoutPage.PlaceOrder();

            _myOrdersPage.AssertionQuantityIncreasedInOrdersPage(3);
        }

        public void Dispose()
        {
            _driver.Quit();
        }
    }
}