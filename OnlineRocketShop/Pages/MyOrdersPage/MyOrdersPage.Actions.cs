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

        private int GetMyOrdersPageQuantityLabelTextParsedToInteger()
        {
            return Int32.Parse(Regex.Replace(MyOrdersCurrentOrderProductQuantityLabel.Text, @"[^\d]+", "").Trim());
        }
    }
}
