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

        protected override string Url => throw new NotImplementedException();

        protected bool isLabelDisplayed;

        public void ProceedToCheckout()
        {
            ScrollToElement(TotalPriceLabel);
            WaitAndFindElement(RelativeBy.WithLocator(By.XPath("//a[@href='http://demos.bellatrix.solutions/checkout/']")).Below(By.XPath("//th[contains(text(),'Total')]")));
            WebDriverWait.Until(ExpectedConditions.ElementToBeClickable(ProceedToCheckoutButton));
            Thread.Sleep(3000);
            try
            {
                ProceedToCheckoutButton.Click();
            }
            catch
            {
                throw new Exception("Proceed to Checkout button not clickable!");
            }
        }

        public void AddCoupon(string couponName)
        {
            CouponCodeTextBox.SendKeys(couponName);

            ApplyCouponButton.Click();

            try
            {
                WaitAndFindElement(By.XPath("//div[@role='alert']"));
            }
            catch
            {

                throw new Exception("Coupon banner not shown");
            }

            ScrollToElement(CartTotalsLabel);

            try
            {
                var couponCartLabel = WaitAndFindElement(By.XPath("//td[contains(@data-title,'Coupon:')]"));
                isLabelDisplayed = couponCartLabel.Displayed;
            }
            catch
            {
                isLabelDisplayed = false;
            }
        }

        public void IncreaseQuantitybyThree()
        {
            QuantityTextBox.Clear();
            QuantityTextBox.SendKeys("3");

            try
            {
                WebDriverWait.Until(ExpectedConditions.ElementToBeClickable(UpdateCartButton));
                UpdateCartButton.Click();

                WebDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@role='alert']")));
                //WebDriverWait.Until(ExpectedConditions.TextToBePresentInElement(NumberOFItemsLabel, "3 items"));
                Thread.Sleep(2000);
            }
            catch
            {
                throw new Exception("Nothing to update in the cart!");
            }
        }
    }
}
