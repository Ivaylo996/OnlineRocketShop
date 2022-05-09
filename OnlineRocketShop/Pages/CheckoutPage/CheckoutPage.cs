using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace OnlineRocketShop.Pages.CheckoutPage
{
    public partial class CheckoutPage : WebPage
    {
        public CheckoutPage(IWebDriver _driver) : base(_driver)
        {
        }

        protected override string Url => throw new NotImplementedException();

        public void FillingBillingDetails(string fName, string lName, string cName, string countrySelectOption, string streetAddress, string apartment, string town, string stateSelectOption, string zipCode, string phone, string emal)
        {
            FirstNameTextBox.SendKeys(fName);
            LastNameTextBox.SendKeys(lName);
            CompanyNameTextBox.SendKeys(cName);

            var selectCountry = new SelectElement(CountrySelect);
            selectCountry.SelectByText(countrySelectOption);

            StreetAddressTextBox.SendKeys(streetAddress);
            ApartmentNumberTextBox.SendKeys(apartment);
            TownTextBox.SendKeys(town);

            var selectState = new SelectElement(StateSelect);
            selectState.SelectByText(stateSelectOption);

            ZipCodeTextBox.SendKeys(zipCode);
            PhoneNumberTextBox.SendKeys(phone);
            EmailAddressTextBox.SendKeys(emal);
            CreateAccountCheckBox.Click();

            WaitAndFindElement(By.XPath("//button[@id='place_order']"));

            try
            {
                PlaceOrderButton.Click();
            }
            catch
            {
                WebDriverWait.Until(ExpectedConditions.ElementToBeClickable(PlaceOrderButton));
                PlaceOrderButton.Click();
            }
        }

        public void PlaceOrder()
        {
            WaitAndFindElement(By.XPath("//button[@id='place_order']"));

            try
            {
                PlaceOrderButton.Click();
            }
            catch 
            {
                WebDriverWait.Until(ExpectedConditions.ElementToBeClickable(PlaceOrderButton));
                PlaceOrderButton.Click();
            }
        }

        public int ParseCheckoutQuantityLabelToString()
        {
            return Int32.Parse(Regex.Replace(ProductQuantityCheckOutLabel.Text, @"[^\d]+", "").Trim());
        }
    }
}
 
