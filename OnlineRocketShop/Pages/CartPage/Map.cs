using OpenQA.Selenium;

namespace OnlineRocketShop.Pages.CartPage
{
    public partial class CartPage
    {
        public IWebElement TotalPriceLabel => WaitAndFindElement(By.XPath("//th[contains(text(),'Total')]"));
        public IWebElement ProceedToCheckoutButton => WaitAndFindElement(RelativeBy.WithLocator(By.XPath("//a[@href='http://demos.bellatrix.solutions/checkout/']")).Below(By.XPath("//th[contains(text(),'Total')]")));
        public IWebElement CouponCodeTextBox => WaitAndFindElement(By.XPath("//input[@id='coupon_code']"));
        public IWebElement ApplyCouponButton => WaitAndFindElement(By.XPath("//button[@name='apply_coupon']"));
        public IWebElement CartTotalsLabel => WaitAndFindElement(By.XPath("//h2[text()='Cart totals']"));
        public IWebElement QuantityTextBox => WaitAndFindElement(By.XPath("//div[@class='quantity']/input"));
        public IWebElement NumberOFItemsLabel => WaitAndFindElement(By.XPath("//a[@title='View your shopping cart']//span[@class='count']"));
        public IWebElement UpdateCartButton => WaitAndFindElement(By.XPath("//button[@name= 'update_cart']"));
    }
}
