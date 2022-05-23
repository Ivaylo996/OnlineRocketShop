using OpenQA.Selenium;

namespace OnlineRocketShop.Pages.CheckoutPage
{
    public partial class CheckoutPage
    {
        public IWebElement BillingFirstNameTextBox => WaitAndFindElement(By.Id("billing_first_name"));
        public IWebElement BillingLastNameTextBox => WaitAndFindElement(By.Id("billing_last_name"));
        public IWebElement BillingCompanyNameTextBox => WaitAndFindElement(By.Id("billing_company"));
        public IWebElement BillingStreetAddressTextBox => WaitAndFindElement(By.Id("billing_address_1"));
        public IWebElement BillingApartmentNumberTextBox => WaitAndFindElement(By.Id("billing_address_2"));
        public IWebElement BillingTownTextBox => WaitAndFindElement(By.Id("billing_city"));
        public IWebElement BillingZipCodeTextBox => WaitAndFindElement(By.Id("billing_postcode"));
        public IWebElement BillingPhoneNumberTextBox => WaitAndFindElement(By.Id("billing_phone"));
        public IWebElement BillingEmailAddressTextBox => WaitAndFindElement(By.Id("billing_email"));
        public IWebElement CreateAccountCheckBox => WaitAndFindElement(By.Id("createaccount"));
        public IWebElement PlaceOrderButton => WaitAndFindElement(By.Id("place_order"));
        public IWebElement CheckoutPageHeader => WaitAndFindElement(By.XPath("//h1[@class='entry-title']"));
        public IWebElement ProductQuantityLabel => WaitAndFindElement(By.XPath("//strong[@class= 'product-quantity']"));
        public IWebElement BillingCountryArrowButton => WaitAndFindElement(By.XPath("//span[contains(@id,'billing_country')]//following-sibling::span"));
        public IWebElement BillingCountryTextBox => WaitAndFindElement(By.XPath("//*[@class='select2-search__field' and contains(@aria-owns, 'country')]"));
        public IWebElement BillingStateArrowButton => WaitAndFindElement(By.XPath("//span[contains(@id,'billing_state')]//following-sibling::span"));
        public IWebElement BillingStateTextBox => WaitAndFindElement(By.XPath("//*[@class='select2-search__field' and contains(@aria-owns, 'state')]"));
        public IWebElement OrderLabel => WaitAndFindElement(By.XPath("//li[contains(@class, ' order')]//strong"));
        public IWebElement MyAccountButton => WaitAndFindElement(By.XPath("//*[contains(@class,'focus')]"));

        public IWebElement GetBillingCountryByCountryNameFromDropDown(string countryName)
        {
            return WaitAndFindElement(By.XPath($"//select[@name='billing_country']/option[contains(text(), '{countryName}')]"));
        }

        public IWebElement GetBillingStateByStateNameFromDropDown(string stateName)
        {
            return WaitAndFindElement(By.XPath($"//select[@name='billing_state']/option[contains(text(), '{stateName}')]"));
        }
    }
}