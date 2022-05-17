using OpenQA.Selenium;

namespace OnlineRocketShop.Pages.OrderRecievedPage
{
    public partial class OrderRecievedPage
    {
        public IWebElement OrderRecievedPageOrderLabel => WaitAndFindElement(By.XPath("//li[contains(@class, ' order')]//strong"));
        public IWebElement OrderRecievedPageMyAccountButton => WaitAndFindElement(By.XPath("//nav[@id='site-navigation']//*[contains(@class,'nav-menu')]//a[contains(text(), 'My account')]"));
        public IWebElement OrderRecievedPageEmailLabel => WaitAndFindElement(By.XPath("//li[contains(@class, 'email')]//*"));
    }
}
