using NUnit.Framework;

namespace OnlineRocketShop.Pages.CartPage
{
    public partial class CartPage : WebPage
    {
        public void AssertCouponApplied(string expectedBannerMessage)
        {
            Assert.AreEqual(expectedBannerMessage, CartAlertBanner.Text.Trim());
        }

        public void AssertQuantityIncreased(string expectedLabel)
        {
            Assert.AreEqual(expectedLabel, NumberOfItemsInCartLabel.Text.Trim());
        }
    }
}
