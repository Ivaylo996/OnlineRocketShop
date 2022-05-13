using NUnit.Framework;

namespace OnlineRocketShop.Pages.CartPage
{
    public partial class CartPage : WebPage
    {
        public void AssertCouponApplied(string expectedBannerMessage)
        {
            Assert.AreEqual(expectedBannerMessage, AlertBanner.Text.Trim());
        }

        public void AssertQuantityIncreasedInCartPage(string expectedLabel)
        {
            Assert.AreEqual(expectedLabel, NumberOfItemsLabel.Text.Trim());
        }
    }
}
