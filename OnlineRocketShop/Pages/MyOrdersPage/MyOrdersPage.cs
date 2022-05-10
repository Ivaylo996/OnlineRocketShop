using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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

        public void GetOrderTextFromOrderRecieved(string orderText)
        {
            expectedOrder = "#" + orderText;
        }
    }
}
