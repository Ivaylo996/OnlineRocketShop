using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;

namespace OnlineRocketShop.Pages.CartPage
{
    public partial class CartPage : WebPage
    {
        public CartPage(IWebDriver _driver) : base(_driver)
        {
        }

        protected override string Url => "https://demos.bellatrix.solutions/cart/";

        protected bool isLabelDisplayed;

        public void ProceedToCheckout()
        {
            ScrollToElement(TotalPriceLabel);
            WaitForElementToBeClickable(ProceedToCheckoutButton);
            WaitForAjax();

            ProceedToCheckoutButton.Click();
            WaitForAjax();
        }

        public void AddCoupon(string couponName)
        {
            CouponCodeTextBox.SendKeys(couponName);

            ApplyCouponButton.Click();
            WaitForAjax();
        }

        public void IncreaseQuantity(int quantityNumber)
        {
            for (int i = 0; i < quantityNumber; i++)
            {
                QuantityTextBox.SendKeys(Keys.ArrowUp);
            }

            UpdateCartButton.Click();
            WaitForAjax();
        }
    }
}
