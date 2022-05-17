using OpenQA.Selenium;

namespace OnlineRocketShop.Pages.CheckoutPage
{
    public partial class CheckoutPage
    {
        public IWebElement BillingFirstNameTextBox => WaitAndFindElement(By.XPath("//input[@id='billing_first_name']"));
        public IWebElement BillingLastNameTextBox => WaitAndFindElement(By.XPath("//input[@id='billing_last_name']"));
        public IWebElement BillingCompanyNameTextBox => WaitAndFindElement(By.XPath("//input[@id='billing_company']"));
        public IWebElement BillingStreetAddressTextBox => WaitAndFindElement(By.XPath("//input[@id='billing_address_1']"));
        public IWebElement BillingApartmentNumberTextBox => WaitAndFindElement(By.XPath("//input[@id='billing_address_2']"));
        public IWebElement BillingTownTextBox => WaitAndFindElement(By.XPath("//input[@id='billing_city']"));
        public IWebElement BillingZipCodeTextBox => WaitAndFindElement(By.XPath("//input[@id='billing_postcode']"));
        public IWebElement BillingPhoneNumberTextBox => WaitAndFindElement(By.XPath("//input[@id='billing_phone']"));
        public IWebElement BillingEmailAddressTextBox => WaitAndFindElement(By.XPath("//input[@id='billing_email']"));
        public IWebElement CheckoutPageCreateAccountCheckBox => WaitAndFindElement(By.XPath("//input[@id='createaccount']"));
        public IWebElement CheckoutPagePlaceOrderButton => WaitAndFindElement(By.XPath("//button[@id='place_order']"));
        public IWebElement CheckoutPageLabel => WaitAndFindElement(By.XPath("//h1[@class='entry-title']"));
        public IWebElement CheckoutPageProductQuantityLabel => WaitAndFindElement(By.XPath("//strong[@class= 'product-quantity']"));
        public IWebElement BillingCountryArrowButton => WaitAndFindElement(By.XPath("//span[contains(@id,'billing_country')]//following-sibling::span"));
        public IWebElement BillingCountryTextBox => WaitAndFindElement(By.XPath("//*[@class='select2-search__field' and contains(@aria-owns, 'country')]"));
        public IWebElement BillingStateArrowButton => WaitAndFindElement(By.XPath("//span[contains(@id,'billing_state')]//following-sibling::span"));
        public IWebElement BillingStateTextBox => WaitAndFindElement(By.XPath("//*[@class='select2-search__field' and contains(@aria-owns, 'state')]"));
        public IWebElement CheckoutPageOrderLabel => WaitAndFindElement(By.XPath("//li[contains(@class, ' order')]//strong"));
        public IWebElement CheckoutPageMyAccountButton => WaitAndFindElement(By.XPath("//*[contains(@class,'focus')]"));

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