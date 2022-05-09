using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace OnlineRocketShop.Pages
{
    public abstract class WebPage
    {
        private const int WAIT_FOR_ELEMENT_TIMEOUT = 60;

        public WebPage(IWebDriver _driver)
        {
            Driver = _driver;
            WebDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(WAIT_FOR_ELEMENT_TIMEOUT));
        }

        public IWebDriver Driver { get; set; }
        public WebDriverWait WebDriverWait { get; set; }
        protected abstract string Url { get; }

        public void GoTo()
        {
            Driver.Navigate().GoToUrl(Url);
            WaitForPageToLoad();
        }

        protected virtual void WaitForPageToLoad()
        {
        }

        public void ScrollToElement(IWebElement iWebElement)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", iWebElement);
        }

        protected IWebElement WaitAndFindElement(By by)
        {
            return WebDriverWait.Until(ExpectedConditions.ElementExists(by));
        }
    }
}
