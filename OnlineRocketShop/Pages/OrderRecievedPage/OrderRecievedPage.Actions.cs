using OpenQA.Selenium;

namespace OnlineRocketShop.Pages.OrderRecievedPage
{
    public partial class OrderRecievedPage : WebPage
    {
        private string currentSubUrl = "checkout/order-received/";

        public OrderRecievedPage(IWebDriver _driver) : base(_driver)
        {
        }

        protected override string Url
        {
            get
            {
                return base.Url + currentSubUrl;
            }
        }

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
