using OpenQA.Selenium;

namespace OnlineRocketShop.Pages.MyAccountPage
{
    public partial class MyAccountPage
    {
        public IWebElement MyAccountButton => WaitAndFindElement(By.XPath("//ul[@class='nav-menu']//li//a[contains(text(),'My account')]"));
        public IWebElement PageUsernameTextBox => WaitAndFindElement(By.Id("username"));
        public IWebElement PagePasswordTextBox => WaitAndFindElement(By.Id("password"));
        public IWebElement LoginButton => WaitAndFindElement(By.XPath("//button[@name='login']"));
        public IWebElement HomeButton => WaitAndFindElement(By.XPath("//ul[@class='nav-menu']//a[contains(text(), 'Home')]"));
        public IWebElement OrdersButton => WaitAndFindElement(By.XPath("//li[contains(@class, 'orders')]//a"));
    }
}
