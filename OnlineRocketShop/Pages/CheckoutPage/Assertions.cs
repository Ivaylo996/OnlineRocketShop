using NUnit.Framework;

namespace OnlineRocketShop.Pages.CheckoutPage
{
    public partial class CheckoutPage
    {
        public void AssertionCheckOutLabelDisplayed()
        {
            Assert.AreEqual("Checkout", CheckoutPageLabel.Text.Trim());
        }

        public void AssertionBillingFilled(string fName, string lName, string companyName, string email)
        {
            Assert.AreEqual(fName, FirstNameTextBox.GetAttribute("Value"));
            Assert.AreEqual(lName, LastNameTextBox.GetAttribute("Value"));
            Assert.AreEqual(companyName, CompanyNameTextBox.GetAttribute("Value"));
            Assert.AreEqual(email, EmailAddressTextBox.GetAttribute("Value"));
        }

        public void AssertionQuantityIncreasedInCheckoutPage()
        {
            Assert.AreEqual(3, ParseCheckoutQuantityLabelToString());
        }
    }
}
