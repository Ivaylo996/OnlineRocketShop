using NUnit.Framework;

namespace OnlineRocketShop.Pages.CartPage
{
    public partial class CartPage
    {
        public void AssertionCouponAdded_When_UsesHappyBirthdayCoupon()
        {
            Assert.IsTrue(isLabelDisplayed);
        }

        public void AssertionQuantityIncreasedInCartPage_When_IncreasingQuantityByThree()
        {
            Assert.AreEqual("3 items", NumberOFItemsLabel.Text.Trim());
        }
    }
}
