using OpenQA.Selenium;

namespace OnlineRocketShop.Pages.CartPage
{
    public partial class CartPage : WebPage
    {
        public CartPage(IWebDriver _driver) 
            : base(_driver)
        {
        }

        protected override string Url => base.Url + "cart/";

        public void ProceedToCheckout()
        {
            ScrollToElement(TotalPriceLabel);
            WaitForElementToBeClickable(ProceedToCheckoutButton);
            WaitForAjax();
            ProceedToCheckoutButton.Click();
            WaitForAjax();
        }

        public void ApplyCouponByCouponName(string couponName)
        {
            CouponCodeTextBox.SendKeys(couponName);
            ApplyCouponButton.Click();
            WaitForAjax();
        }

        public void IncreaseProductQuantityInCartByNumber(int quantityNumber)
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
