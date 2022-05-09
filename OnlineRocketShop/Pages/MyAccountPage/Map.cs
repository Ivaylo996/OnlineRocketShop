using OpenQA.Selenium;

namespace OnlineRocketShop.Pages.MyAccountPage
{
    public partial class MyAccountPage
    {
        public IWebElement MyAccountButton => WaitAndFindElement(By.XPath("//ul[@class='nav-menu']//li//a[contains(text(),'My account')]"));
        public IWebElement UsernameTextBox => WaitAndFindElement(By.XPath("//input[@id='username']"));
        public IWebElement PasswordTextBox => WaitAndFindElement(By.XPath("//input[@id='password']"));
        public IWebElement LoginButton => WaitAndFindElement(By.XPath("//button[@name='login']"));
        public IWebElement HomeButton => WaitAndFindElement(By.XPath("//ul[@class='nav-menu']//a[contains(text(), 'Home')]"));
        public IWebElement OrdersButton => WaitAndFindElement(By.XPath("//li[contains(@class, 'orders')]//a"));

        public IWebElement orderNumberLabel(string orderNumber)
        {
            return WaitAndFindElement(By.XPath($"//a[contains(@href,'https://demos.bellatrix.solutions/my-account/view-order/{orderNumber}/') and not(@class)]"));
        }
    }
}
