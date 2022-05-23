using System;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace OnlineRocketShop.Pages.CheckoutPage
{
    public partial class CheckoutPage
    {
        public void AssertCheckOutLabelDisplayed(string expectedCheckoutPageLabelText)
        {
            Assert.AreEqual(expectedCheckoutPageLabelText, CheckoutPageHeader.Text.Trim());
        }

        public void AssertBillingInformationPrefilledOnCheckout(string expectedPrefilledFirstName, string expectedPrefilledLastName, string expectedPrefilledCompanyName, string expectedPrefilledEmail)
        {
            Assert.AreEqual(expectedPrefilledFirstName, BillingFirstNameTextBox.GetAttribute("Value"));
            Assert.AreEqual(expectedPrefilledLastName, BillingLastNameTextBox.GetAttribute("Value"));
            Assert.AreEqual(expectedPrefilledCompanyName, BillingCompanyNameTextBox.GetAttribute("Value"));
            Assert.AreEqual(expectedPrefilledEmail, BillingEmailAddressTextBox.GetAttribute("Value"));
        }

        public void AssertQuantityUpdatedByNumber(int expectedQuantityNumber)
        {
            var actualQuantityNumber = Int32.Parse(Regex.Replace(ProductQuantityLabel.Text, @"[^\d]+", "").Trim());

            Assert.AreEqual(expectedQuantityNumber, actualQuantityNumber);
        }
    }
}
