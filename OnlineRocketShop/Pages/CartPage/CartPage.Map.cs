using OpenQA.Selenium;

namespace OnlineRocketShop.Pages.CartPage
{
    public partial class CartPage
    {
        public IWebElement CartPageTotalPriceLabel => WaitAndFindElement(By.XPath("//th[contains(text(),'Total')]"));
        public IWebElement CartPageProceedToCheckoutButton => WaitAndFindElement(By.XPath("//a[contains(@href,'checkout/') and contains(@class,'checkout-button')]"));
        public IWebElement CartPageCouponCodeTextBox => WaitAndFindElement(By.Id("coupon_code"));
        public IWebElement CartPageApplyCouponButton => WaitAndFindElement(By.XPath("//button[@name='apply_coupon']"));
        public IWebElement CartTotalsLabel => WaitAndFindElement(By.XPath("//h2[text()='Cart totals']"));
        public IWebElement CartPageQuantityTextBox => WaitAndFindElement(By.XPath("//div[@class='quantity']/input"));
        public IWebElement NumberOfItemsInCartLabel => WaitAndFindElement(By.XPath("//a[@title='View your shopping cart']//span[@class='count']"));
        public IWebElement UpdateCartButton => WaitAndFindElement(By.XPath("//button[@name= 'update_cart']"));
        public IWebElement CouponCartLabel => WaitAndFindElement(By.XPath("//td[contains(@data-title,'Coupon:')]"));
        public IWebElement CartPageAlertBanner => WaitAndFindElement(By.XPath("//div[@role='alert']"));
    }
}
