using OpenQA.Selenium;

namespace OnlineRocketShop.Pages.OrdersPage
{
    public partial class OrdersPage
    {
        public IWebElement OrdersMyAccountLink(int numOfElements)
        {
            return WaitAndFindElement(By.XPath($"//tbody//tr[{numOfElements}]//td[@data-title='Order']/a"));
        }

        public IWebElement NextButton => WaitAndFindElement(By.XPath("//a[contains(@class,'woocommerce-Button--next button')]"));
        public IWebElement ProductQuantityOrdersLabel => WaitAndFindElement(By.XPath("//strong[@class='product-quantity']"));
        public IWebElement orderNumber => WaitAndFindElement(By.XPath("//li[contains(@class,'woocommerce-order-overview__order order')]//strong"));
    }
}
