using OpenQA.Selenium;

namespace OnlineRocketShop.Pages.MyAccountPage
{
    public partial class MyAccountPage : WebPage
    {
        public MyAccountPage(IWebDriver _driver) : base(_driver)
        {
        }

        protected override string Url => "https://demos.bellatrix.solutions/my-account/";

        public void LoginWithExistingAccount(string userName, string userPassword)
        {
            GoTo();

            WaitForAjax();

            if (UsernameTextBox.Displayed)
            {
                UsernameTextBox.SendKeys(userName);
                PasswordTextBox.SendKeys(userPassword);

                LoginButton.Click();
            }
        }

        public void GoToHomePage()
        {
            HomeButton.Click();
            WaitForAjax();
        }

        public void CheckOrders()
        {
            OrdersButton.Click();
            WaitForAjax();
        }
    }
}
