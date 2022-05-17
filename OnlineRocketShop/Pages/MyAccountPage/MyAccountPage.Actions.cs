using OpenQA.Selenium;

namespace OnlineRocketShop.Pages.MyAccountPage
{
    public partial class MyAccountPage : WebPage
    {
        public MyAccountPage(IWebDriver _driver) : base(_driver)
        {
        }

        protected override string Url => "https://demos.bellatrix.solutions/my-account/";

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
