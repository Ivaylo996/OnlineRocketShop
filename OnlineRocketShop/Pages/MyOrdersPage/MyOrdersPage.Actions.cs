using System;
using System.Text.RegularExpressions;
using OpenQA.Selenium;

namespace OnlineRocketShop.Pages.MyOrdersPage
{
    public partial class MyOrdersPage : WebPage
    {
        private string currentSubUrl = "orders/";

        public MyOrdersPage(IWebDriver _driver) : base(_driver)
        {
        }

        protected override string Url
        {
            get
            {
                return base.Url + currentSubUrl;
            }
        }

        private int GetMyOrdersPageQuantityLabelTextParsedToInteger()
        {
            return Int32.Parse(Regex.Replace(MyOrdersCurrentOrderProductQuantityLabel.Text, @"[^\d]+", "").Trim());
        }
    }
}
