using OpenQA.Selenium;

namespace OnlineRocketShop.Pages.MyAccountPage
{
    public partial class MyAccountPage : WebPage
    {
        private string currentSubUrl = "my-account/";

        public MyAccountPage(IWebDriver _driver) : base(_driver)
        {
        }

        protected override string Url
        {
            get
            {
                return base.Url + currentSubUrl;
            }
        }

        public void LoginWithExistingUsernameAndPassword(string userName, string userPassword)
        {
            GoTo();

            WaitForAjax();

            if (MyAccountPageUsernameTextBox.Displayed)
            {
                MyAccountPageUsernameTextBox.SendKeys(userName);
                MyAccountPagePasswordTextBox.SendKeys(userPassword);

                MyAccountLoginButton.Click();
            }
        }

        public void GoToHomePageFromMyAccountPage()
        {
            MyAccountHomeButton.Click();
            WaitForAjax();
        }

        public void CheckOrdersInMyAccount()
        {
            MyAccountOrdersButton.Click();
            WaitForAjax();
        }
    }
}
