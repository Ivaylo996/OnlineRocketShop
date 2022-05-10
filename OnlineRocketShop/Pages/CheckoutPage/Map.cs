using OpenQA.Selenium;

namespace OnlineRocketShop.Pages.CheckoutPage
{
    public partial class CheckoutPage
    {
        public IWebElement FirstNameTextBox => WaitAndFindElement(By.XPath("//input[@id='billing_first_name']"));
        public IWebElement LastNameTextBox => WaitAndFindElement(By.XPath("//input[@id='billing_last_name']"));
        public IWebElement CompanyNameTextBox => WaitAndFindElement(By.XPath("//input[@id='billing_company']"));
        public IWebElement StreetAddressTextBox => WaitAndFindElement(By.XPath("//input[@id='billing_address_1']"));
        public IWebElement ApartmentNumberTextBox => WaitAndFindElement(By.XPath("//input[@id='billing_address_2']"));
        public IWebElement TownTextBox => WaitAndFindElement(By.XPath("//input[@id='billing_city']"));
        public IWebElement ZipCodeTextBox => WaitAndFindElement(By.XPath("//input[@id='billing_postcode']"));
        public IWebElement PhoneNumberTextBox => WaitAndFindElement(By.XPath("//input[@id='billing_phone']"));
        public IWebElement EmailAddressTextBox => WaitAndFindElement(By.XPath("//input[@id='billing_email']"));
        public IWebElement CreateAccountCheckBox => WaitAndFindElement(By.XPath("//input[@id='createaccount']"));
        public IWebElement PlaceOrderButton => WaitAndFindElement(By.XPath("//button[@id='place_order']"));
        public IWebElement CheckoutPageLabel => WaitAndFindElement(By.XPath("//h1[@class='entry-title']"));
        public IWebElement ProductQuantityCheckOutLabel => WaitAndFindElement(By.XPath("//strong[@class= 'product-quantity']"));
        public IWebElement SelectCountryArrowButton => WaitAndFindElement(By.XPath("//span[contains(@id,'billing_country')]//following-sibling::span"));
        public IWebElement SelectCountryTextBox => WaitAndFindElement(By.XPath("//*[@class='select2-search__field' and contains(@aria-owns, 'country')]"));
        public IWebElement SelectStateArrowButton => WaitAndFindElement(By.XPath("//span[contains(@id,'billing_state')]//following-sibling::span"));
        public IWebElement SelectStateTextBox => WaitAndFindElement(By.XPath("//*[@class='select2-search__field' and contains(@aria-owns, 'state')]"));
        public IWebElement OrderLabel => WaitAndFindElement(By.XPath("//li[contains(@class, ' order')]//strong"));
        public IWebElement MyAccountButton => WaitAndFindElement(By.XPath("//*[contains(@class,'focus')]"));
    }
}
////*[contains(@class,'focus')]//*[contains(@href, 'my-account')]