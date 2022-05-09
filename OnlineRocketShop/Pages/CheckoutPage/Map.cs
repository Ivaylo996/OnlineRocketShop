using OpenQA.Selenium;

namespace OnlineRocketShop.Pages.CheckoutPage
{
    public partial class CheckoutPage
    {
        public IWebElement FirstNameTextBox => WaitAndFindElement(By.XPath("//input[@id='billing_first_name']"));
        public IWebElement LastNameTextBox => WaitAndFindElement(By.XPath("//input[@id='billing_last_name']"));
        public IWebElement CompanyNameTextBox => WaitAndFindElement(By.XPath("//input[@id='billing_company']"));
        public IWebElement CountrySelect => WaitAndFindElement(By.XPath("//select[@id='billing_country']"));
        public IWebElement StreetAddressTextBox => WaitAndFindElement(By.XPath("//input[@id='billing_address_1']"));
        public IWebElement ApartmentNumberTextBox => WaitAndFindElement(By.XPath("//input[@id='billing_address_2']"));
        public IWebElement TownTextBox => WaitAndFindElement(By.XPath("//input[@id='billing_city']"));
        public IWebElement StateSelect => WaitAndFindElement(By.XPath("//select[@id='billing_state']"));
        public IWebElement ZipCodeTextBox => WaitAndFindElement(By.XPath("//input[@id='billing_postcode']"));
        public IWebElement PhoneNumberTextBox => WaitAndFindElement(By.XPath("//input[@id='billing_phone']"));
        public IWebElement EmailAddressTextBox => WaitAndFindElement(By.XPath("//input[@id='billing_email']"));
        public IWebElement CreateAccountCheckBox => WaitAndFindElement(By.XPath("//input[@id='createaccount']"));
        public IWebElement PlaceOrderButton => WaitAndFindElement(By.XPath("//button[@id='place_order']"));
        public IWebElement orderRecievedEmailLabel => WaitAndFindElement(By.XPath("//li[contains(@class, 'email')]//*"));
        public IWebElement checkoutPageLabel => WaitAndFindElement(By.XPath("//h1[@class='entry-title']"));
        public IWebElement ProductQuantityCheckOutLabel => WaitAndFindElement(By.XPath("//strong[@class= 'product-quantity']"));
    }
}
