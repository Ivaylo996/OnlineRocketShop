﻿using System;
using System.Text.RegularExpressions;
using OpenQA.Selenium;

namespace OnlineRocketShop.Pages.CheckoutPage
{
    public partial class CheckoutPage : WebPage
    {
        public CheckoutPage(IWebDriver _driver) : base(_driver)
        {
        }

        protected override string Url => "https://demos.bellatrix.solutions/checkout/";

        public void FillingBillingDetails(BillingInfo billingInfo)
        {
            FirstNameTextBox.SendKeys(billingInfo.FirstName);
            LastNameTextBox.SendKeys(billingInfo.LastName);
            CompanyNameTextBox.SendKeys(billingInfo.CompanyName);

            SelectCountryArrowButton.Click();
            SelectCountryFromDropDown(billingInfo.CountryName);
            SelectCountryTextBox.SendKeys(Keys.Enter);

            StreetAddressTextBox.SendKeys(billingInfo.Address1); 
            ApartmentNumberTextBox.SendKeys(billingInfo.Address2); 
            TownTextBox.SendKeys(billingInfo.CityName); 

            SelectStateArrowButton.Click();
            SelectStateFromDropDown(billingInfo.CityName);
            SelectStateTextBox.SendKeys(Keys.Enter);

            ZipCodeTextBox.SendKeys(billingInfo.ZipCode); 
            PhoneNumberTextBox.SendKeys(billingInfo.PhoneNumber); 
            EmailAddressTextBox.SendKeys(billingInfo.Email); 

            CreateAccountCheckBox.Click();
            WaitForAjax();
        }

        public void PlaceOrder()
        {
            PlaceOrderButton.Click();
            WaitForAjax();
        }

        private int ParseCheckoutQuantityLabelToString()
        {
            return Int32.Parse(Regex.Replace(ProductQuantityCheckOutLabel.Text, @"[^\d]+", "").Trim());
        }
    }
}
 