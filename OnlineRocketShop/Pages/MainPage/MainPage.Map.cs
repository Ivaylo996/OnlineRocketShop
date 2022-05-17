using OpenQA.Selenium;

namespace OnlineRocketShop.Pages.MainPage
{
    public partial class MainPage
    {
        public IWebElement GetAddToCartButtonByRocketName(string rocketName)
        {
            return WaitAndFindElement(By.XPath($"//a[contains(@href, '{rocketName}/')]//following-sibling::a"));
        }

        public IWebElement GetViewCartButtonByRocketName(string rocketName)
        {
            return WaitAndFindElement(By.XPath($"//a[contains(@href, '{rocketName}/')]//following-sibling::a[@title='View cart']"));
        }
    }
}
