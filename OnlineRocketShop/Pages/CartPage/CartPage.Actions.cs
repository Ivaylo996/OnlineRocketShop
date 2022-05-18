using OpenQA.Selenium;

namespace OnlineRocketShop.Pages.CartPage
{
    public partial class CartPage : WebPage
    {
        private string currentSubUrl = "cart/";

        public CartPage(IWebDriver _driver) : base(_driver)
        {
        }

        protected override string Url
        {
            get
            {
                return base.Url + currentSubUrl;
            }
        }

        public void ProceedToCheckoutFromCartPage()
        {
            ScrollToElement(CartPageTotalPriceLabel);
            WaitForElementToBeClickable(CartPageProceedToCheckoutButton);
            WaitForAjax();

            CartPageProceedToCheckoutButton.Click();
            WaitForAjax();
        }

        public void ApplyCouponByCouponName(string couponName)
        {
            CartPageCouponCodeTextBox.SendKeys(couponName);

            CartPageApplyCouponButton.Click();
            WaitForAjax();
        }

        public void IncreaseProductQuantityInCartByNumber(int quantityNumber)
        {
            for (int i = 0; i < quantityNumber; i++)
            {
                CartPageQuantityTextBox.SendKeys(Keys.ArrowUp);
            }

            UpdateCartButton.Click();
            WaitForAjax();
        }
    }
}
