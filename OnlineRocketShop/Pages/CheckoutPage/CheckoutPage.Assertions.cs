using NUnit.Framework;

namespace OnlineRocketShop.Pages.CheckoutPage
{
    public partial class CheckoutPage
    {
        public void AssertCheckOutLabelDisplayed(string expectedCheckoutPageLabelText)
        {
            Assert.AreEqual(expectedCheckoutPageLabelText, CheckoutPageLabel.Text.Trim());
        }

        public void AssertBillingInformationPrefilledOnCheckout(string expectedPrefilledFirstName, string expectedPrefilledLastName, string expectedPrefilledCompanyName, string expectedPrefilledEmail)
        {
            Assert.AreEqual(expectedPrefilledFirstName, BillingFirstNameTextBox.GetAttribute("Value"));
            Assert.AreEqual(expectedPrefilledLastName, BillingLastNameTextBox.GetAttribute("Value"));
            Assert.AreEqual(expectedPrefilledCompanyName, BillingCompanyNameTextBox.GetAttribute("Value"));
            Assert.AreEqual(expectedPrefilledEmail, BillingEmailAddressTextBox.GetAttribute("Value"));
        }

        public void AssertQuantityIncreasedInCheckoutPageByNumber(int expectedQuantityNumber)
        {
            Assert.AreEqual(expectedQuantityNumber, GetCheckoutPageQuantityLabelTextParsedToInteger());
        }
    }
}
