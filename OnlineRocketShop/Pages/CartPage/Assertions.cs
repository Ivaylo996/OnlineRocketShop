using NUnit.Framework;

namespace OnlineRocketShop.Pages.CartPage
{
    public partial class CartPage
    {
        public void AssertionCouponAdded(string expectedBannerMessage)
        {
            Assert.AreEqual(expectedBannerMessage, AlertBanner.Text.Trim());
        }

        public void AssertionQuantityIncreasedInCartPage(string expectedLabel)
        {
            Assert.AreEqual(expectedLabel, NumberOFItemsLabel.Text.Trim());
        }
    }
}
