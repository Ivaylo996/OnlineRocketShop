using NUnit.Framework;

namespace OnlineRocketShop.Pages.CheckoutPage
{
    public partial class CheckoutPage
    {
        public void AssertionCheckOutLabelDisplayed_When_ProceedingWithOrder()
        {
            Assert.AreEqual("Checkout", checkoutPageLabel.Text.Trim());
        }

        public void AssertionBillingFilled_When_LoggingInWithExistingAccount(string fName, string lName, string companyName, string email)
        {
            Assert.AreEqual(fName, FirstNameTextBox.GetAttribute("Value"));
            Assert.AreEqual(lName, LastNameTextBox.GetAttribute("Value"));
            Assert.AreEqual(companyName, CompanyNameTextBox.GetAttribute("Value"));
            Assert.AreEqual(email, EmailAddressTextBox.GetAttribute("Value"));
        }

        public void AssertionOrderRecieved_With_InitializeBillingInfoEmail(string expectedEmail)
        {
            Assert.AreEqual(expectedEmail, orderRecievedEmailLabel.Text.Trim());
        }

        public void AssertionQuantityIncreasedInCheckoutPage_With_IncreasingQuantityByThree()
        {
            Assert.AreEqual(3, ParseCheckoutQuantityLabelToString());
        }
    }
}
