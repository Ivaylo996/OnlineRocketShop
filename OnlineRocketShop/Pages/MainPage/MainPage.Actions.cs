using OpenQA.Selenium;

namespace OnlineRocketShop.Pages.MainPage
{
    public partial class MainPage : WebPage
    {
        public MainPage(IWebDriver _driver) : base(_driver)
        {
        }

        public void AddItemToCartWithoutAccount(string rocketName)
        {
            GoTo();
            AddRocketToCart(rocketName);
        }

        public void AddRocketToCart(string rocketName)
        {
            GetAddToCartButtonByRocketName(rocketName).Click();
            WaitForElementToBeClickable(GetViewCartButtonByRocketName(rocketName));

            WaitForAjax();
            GetViewCartButtonByRocketName(rocketName).Click();
        }
    }
}
