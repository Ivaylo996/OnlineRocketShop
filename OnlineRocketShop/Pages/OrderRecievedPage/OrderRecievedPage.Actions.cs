using OpenQA.Selenium;

namespace OnlineRocketShop.Pages.OrderRecievedPage
{
    public partial class OrderRecievedPage : WebPage
    {
        public OrderRecievedPage(IWebDriver _driver) 
            : base(_driver)
        {
        }

        protected override string Url => base.Url + "checkout/order-received/";

        public void GoToMyAccountPage()
        {
            MyAccountButton.Click();
            WaitForAjax();
        }
    }
}
