using OpenQA.Selenium;
using System;

namespace OnlineRocketShop.Pages.MainPage
{
    public partial class MainPage : WebPage
    {
        public MainPage(IWebDriver _driver) : base(_driver)
        {
        }

        protected override string Url => "http://demos.bellatrix.solutions/";

        public void AddItemToCart(string rocketName)
        {
            GoTo();
            AddRocketToCart(rocketName);
        }

        public void AddRocketToCart(string rocketName)
        {
            AddRocketToCartByNameButton(rocketName).Click();
            if (ViewCartByRocketNameButton(rocketName).Displayed)
            {
                ViewCartByRocketNameButton(rocketName).Click();
            }
            else
            {
                throw new Exception("Item not added  to cart");
            }
        }
    }
}
