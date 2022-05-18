using System;
using System.Text.RegularExpressions;
using OpenQA.Selenium;

namespace OnlineRocketShop.Pages.CheckoutPage
{
    public partial class CheckoutPage : WebPage
    {
        private string currentSubUrl = "checkout/";

        public CheckoutPage(IWebDriver _driver) : base(_driver)
        {
        }

        protected override string Url
        {
            get
            {
                return base.Url + currentSubUrl;
            }
        }

        public void FillingBillingDetails(BillingInfo billingInfo)
        {
            BillingFirstNameTextBox.SendKeys(billingInfo.FirstName);
            BillingLastNameTextBox.SendKeys(billingInfo.LastName);
            BillingCompanyNameTextBox.SendKeys(billingInfo.CompanyName);

            BillingCountryArrowButton.Click();
            GetBillingCountryByCountryNameFromDropDown(billingInfo.CountryName);
            BillingCountryTextBox.SendKeys(Keys.Enter);

            BillingStreetAddressTextBox.SendKeys(billingInfo.Address1); 
            BillingApartmentNumberTextBox.SendKeys(billingInfo.Address2); 
            BillingTownTextBox.SendKeys(billingInfo.CityName); 

            BillingStateArrowButton.Click();
            GetBillingStateByStateNameFromDropDown(billingInfo.CityName);
            BillingStateTextBox.SendKeys(Keys.Enter);

            BillingZipCodeTextBox.SendKeys(billingInfo.ZipCode); 
            BillingPhoneNumberTextBox.SendKeys(billingInfo.PhoneNumber); 
            BillingEmailAddressTextBox.SendKeys(billingInfo.Email); 

            CheckoutPageCreateAccountCheckBox.Click();
            WaitForAjax();
        }

        public void PlaceOrder()
        {
            CheckoutPagePlaceOrderButton.Click();
            WaitForAjax();
        }

        private int GetCheckoutPageQuantityLabelTextParsedToInteger()
        {
            return Int32.Parse(Regex.Replace(CheckoutPageProductQuantityLabel.Text, @"[^\d]+", "").Trim());
        }
    }
}
 
