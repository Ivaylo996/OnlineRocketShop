using OpenQA.Selenium;

namespace OnlineRocketShop.Pages.MyAccountPage
{
    public partial class MyAccountPage
    {
        public IWebElement MyAccountButton => WaitAndFindElement(By.XPath("//ul[@class='nav-menu']//li//a[contains(text(),'My account')]"));
        public IWebElement MyAccountPageUsernameTextBox => WaitAndFindElement(By.Id("username"));
        public IWebElement MyAccountPagePasswordTextBox => WaitAndFindElement(By.Id("password"));
        public IWebElement MyAccountLoginButton => WaitAndFindElement(By.XPath("//button[@name='login']"));
        public IWebElement MyAccountHomeButton => WaitAndFindElement(By.XPath("//ul[@class='nav-menu']//a[contains(text(), 'Home')]"));
        public IWebElement MyAccountOrdersButton => WaitAndFindElement(By.XPath("//li[contains(@class, 'orders')]//a"));

    }
}
