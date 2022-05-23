using OpenQA.Selenium;

namespace OnlineRocketShop.Pages.MyOrdersPage
{
    public partial class MyOrdersPage : WebPage
    {
        public MyOrdersPage(IWebDriver _driver) 
            : base(_driver)
        {
        }

        protected override string Url => base.Url + "orders/";
    }
}
