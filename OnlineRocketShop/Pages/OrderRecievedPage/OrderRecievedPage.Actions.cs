using OpenQA.Selenium;

namespace OnlineRocketShop.Pages.OrderRecievedPage
{
    public partial class OrderRecievedPage : WebPage
    {
        public OrderRecievedPage(IWebDriver _driver) : base(_driver)
        {
        }

        protected override string Url => "http://demos.bellatrix.solutions/checkout/order-received/";

        public void GoToMyAccountPage()
        {
            OrderRecievedPageMyAccountButton.Click();
            WaitForAjax();
        }

        public string GetOrderNumberByOrderRecievedPageOrderLabel()
        {
            return OrderRecievedPageOrderLabel.Text.Trim();
        }
    }
}
