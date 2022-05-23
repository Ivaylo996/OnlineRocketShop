using OpenQA.Selenium;

namespace OnlineRocketShop.Pages.MyOrdersPage
{
    public partial class MyOrdersPage
    {
        public IWebElement CurrentOrderProductQuantityLabel => WaitAndFindElement(By.XPath("//strong[@class='product-quantity']"));
        public IWebElement OrderLink => WaitAndFindElement(By.XPath($"//tr[1]//*[contains(@href,'view-order/') and not(contains(@class,'button'))]"));
    }
}
