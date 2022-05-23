using OpenQA.Selenium;

namespace OnlineRocketShop.Pages.MyAccountPage
{
    public partial class MyAccountPage : WebPage
    {
        public MyAccountPage(IWebDriver _driver) 
            : base(_driver)
        {
        }

        protected override string Url => base.Url + "my-account/";

        public void LoginWithExistingUsernameAndPassword(string userName, string userPassword)
        {
            GoTo();
            WaitForAjax();

            if (PageUsernameTextBox.Displayed)
            {
                PageUsernameTextBox.SendKeys(userName);
                PagePasswordTextBox.SendKeys(userPassword);
                LoginButton.Click();
            }
        }

        public void GoToHomePage()
        {
            HomeButton.Click();
            WaitForAjax();
        }

        public void CheckOrdersInMyAccount()
        {
            OrdersButton.Click();
            WaitForAjax();
        }
    }
}
