using OpenQA.Selenium;

namespace OnlineRocketShop.Pages.OrderRecievedPage
{
    public partial class OrderRecievedPage
    {
        public IWebElement OrderLabel => WaitAndFindElement(By.XPath("//li[contains(@class, ' order')]//strong"));
        public IWebElement MyAccountButton => WaitAndFindElement(By.XPath("//nav[@id='site-navigation']//*[contains(@class,'nav-menu')]//a[contains(text(), 'My account')]"));
        public IWebElement OrderRecievedEmailLabel => WaitAndFindElement(By.XPath("//li[contains(@class, 'email')]//*"));
    }
}
