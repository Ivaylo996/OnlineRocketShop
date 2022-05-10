using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;

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
        public string OrderNumberLabel { get; set; }

        public void GoTo()
        {
            Driver.Navigate().GoToUrl(Url);
            WaitForPageToLoad();
        }

        protected virtual void WaitForPageToLoad()
        {
        }

        public void HoverOverElement(IWebElement elementToBeHovered)
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(elementToBeHovered).Perform();
        }

        public void WaitForElementToBeClickable(IWebElement elementToClick)
        {
            WebDriverWait.Until(ExpectedConditions.ElementToBeClickable(elementToClick));
        }

        public void WaitForElementToBeVisible(By by)
        {
            WebDriverWait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        public void ScrollToElement(IWebElement elementToScrollTo)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", elementToScrollTo);
        }

        protected IWebElement WaitAndFindElement(By by)
        {
            return WebDriverWait.Until(ExpectedConditions.ElementExists(by));
        }

        public void WaitForAjax()
        {
            var js = (IJavaScriptExecutor)Driver;

            WebDriverWait.Until(wd => js.ExecuteScript("return jQuery.active").ToString() == "0");
        }
    }
}