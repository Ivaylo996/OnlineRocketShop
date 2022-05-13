using System;
using System.Text.RegularExpressions;
using OpenQA.Selenium;

namespace OnlineRocketShop.Pages.MyOrdersPage
{
    public partial class MyOrdersPage : WebPage
    {
        public MyOrdersPage(IWebDriver _driver) : base(_driver)
        {
        }

        protected override string Url => "https://demos.bellatrix.solutions/my-account/orders/";
        public string expectedOrder;

        private int ParseOrdersQuantityLabelToString()
        {
            return Int32.Parse(Regex.Replace(ProductQuantityOrdersLabel.Text, @"[^\d]+", "").Trim());
        }

        public void ExtractOrderTextFromOrderRecieved(string orderText)
        {
            expectedOrder = "#" + orderText;
        }
    }
}
