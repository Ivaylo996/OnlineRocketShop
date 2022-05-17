using OpenQA.Selenium;

namespace OnlineRocketShop.Pages.MyOrdersPage
{
    public partial class MyOrdersPage
    {
        public IWebElement MyOrdersCurrentOrderProductQuantityLabel => WaitAndFindElement(By.XPath("//strong[@class='product-quantity']"));
        public IWebElement MyOrdersOrderLink => WaitAndFindElement(By.XPath($"//tr[1]//*[contains(@href,'view-order/') and not(contains(@class,'button'))]"));
    }
}
