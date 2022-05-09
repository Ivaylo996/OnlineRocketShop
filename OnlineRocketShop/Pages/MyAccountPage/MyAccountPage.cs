using OpenQA.Selenium;

namespace OnlineRocketShop.Pages.MyAccountPage
{
    public partial class MyAccountPage : WebPage
    {
        public MyAccountPage(IWebDriver _driver) : base(_driver)
        {
        }

        protected override string Url => "http://demos.bellatrix.solutions/my-account/?password-reset=true";

        public void LoginWithExistingAccount(string uName, string password)
        {
            GoTo();

            try
            {
                Driver.FindElement(By.XPath("//input[@id='username']")).SendKeys(uName);
                Driver.FindElement(By.XPath("//input[@id='password']")).SendKeys(password);

                LoginButton.Click();
            }
            catch
            {
            }
        }

        public void GoToHomePage()
        {
            HomeButton.Click();
        }

        public void CheckOrders()
        {
            ScrollToElement(OrdersButton);

            OrdersButton.Click();
        }
    }
}
