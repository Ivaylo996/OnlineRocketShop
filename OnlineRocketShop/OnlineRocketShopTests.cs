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
    public class OnlineRocketShopTests
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
            _driver.Close();
        }

        [Test]
        public void NewAccountCreated_When_OrderPlacedByNewUser()
        {
            _mainPage.AddItemToCartWithoutAccount("proton-rocket");
            _cartPage.ProceedToCheckout();
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
                Email = "ivaylo42111o.dimg@gmail.com"
            });
            _checkoutPage.PlaceOrder();

            _orderRecievedPage.AssertOrderRecieved("ivaylo42111o.dimg@gmail.com");
        }

        [Test]
        public void BillingInfoPrefilled_When_ProceedingToCheckoutWithExistingAccount()
        {
            _myAccountPage.LoginWithExistingUsernameAndPassword("ivaylo.dimg@gmail.com", "Qwerty12345678987654321!");
            _myAccountPage.GoToHomePage();
            _mainPage.AddRocketToCart("proton-rocket");
            _cartPage.ProceedToCheckout();

            _checkoutPage.AssertCheckOutLabelDisplayed("Checkout");
            _checkoutPage.AssertBillingInformationPrefilledOnCheckout("Ivaylo", "Dimitrov", "ATP", "ivaylo.dimg@gmail.com");
        }

        [Test]
        public void OrdersShownInMyAccount_When_PurchasingItem_And_ComparingOrderNumber()
        {
            _mainPage.AddItemToCartWithoutAccount("proton-rocket");
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
                Email = "ivso1321231231231.dimg@gmail.com"
            });
            _checkoutPage.PlaceOrder();

            _orderRecievedPage.AssertOrderRecieved("ivso1321231231231.dimg@gmail.com");

            var expectedOrderLabelFromOrderRecievedPage = "#" + Int32.Parse(Regex.Replace(_orderRecievedPage.OrderLabel.Text, @"[^\d]+", "").Trim());
            _orderRecievedPage.GoToMyAccountPage();
            _myAccountPage.CheckOrdersInMyAccount();
            
            _myOrdersPage.AssertOrdersShownInMyAccount(expectedOrderLabelFromOrderRecievedPage);
        }

        [Test]
        public void CouponApplied_When_ApplyingHappyBirthdayCoupon()
        {
            _mainPage.AddItemToCartWithoutAccount("falcon-9");
            _cartPage.ApplyCouponByCouponName("happybirthday");

            _cartPage.AssertCouponApplied("Coupon code applied successfully.");
        }

        [Test]
        public void QuantityIncreasedToThree_When_AddingItemToCart_And_IncreasingQuantity()
        {
            _mainPage.AddItemToCartWithoutAccount("falcon-9");
            _cartPage.IncreaseProductQuantityInCartByNumber(3);

            _cartPage.AssertQuantityIncreased("3 items");

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

            _checkoutPage.AssertQuantityUpdatedByNumber(3);

            _checkoutPage.PlaceOrder();

            _myOrdersPage.AssertQuantityUpdatedByNumber(3);
        }
    }
}