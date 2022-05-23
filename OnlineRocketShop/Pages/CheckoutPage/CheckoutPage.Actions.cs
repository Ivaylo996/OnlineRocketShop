using OpenQA.Selenium;

namespace OnlineRocketShop.Pages.CheckoutPage
{
    public partial class CheckoutPage : WebPage
    {
        public CheckoutPage(IWebDriver _driver) 
            : base(_driver)
        {
        }

        protected override string Url => base.Url + "checkout/";

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
            CreateAccountCheckBox.Click();
            WaitForAjax();
        }

        public void PlaceOrder()
        {
            PlaceOrderButton.Click();
            WaitForAjax();
        }
    }
}
 
