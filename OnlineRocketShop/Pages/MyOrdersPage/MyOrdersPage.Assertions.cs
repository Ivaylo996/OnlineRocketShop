using NUnit.Framework;

namespace OnlineRocketShop.Pages.MyOrdersPage
{
    public partial class MyOrdersPage
    {
        public void AssertOrdersShownInMyAccount()
        {
            Assert.AreEqual(expectedOrder, OrderLink.Text.Trim());
        }

        public void AssertQuantityIncreasedInOrdersPage(int expectedQuantityCount)
        {
            Assert.AreEqual(expectedQuantityCount, ParseOrdersQuantityLabelToString());
        }
    }
}
