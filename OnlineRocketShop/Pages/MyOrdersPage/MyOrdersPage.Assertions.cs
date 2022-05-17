using NUnit.Framework;

namespace OnlineRocketShop.Pages.MyOrdersPage
{
    public partial class MyOrdersPage
    {
        public void AssertOrdersShownInMyAccount(string expectedOrderLabel)
        {
            Assert.AreEqual(expectedOrderLabel, MyOrdersOrderLink.Text.Trim());
        }

        public void AssertQuantityIncreasedInOrdersPageByNumber(int expectedQuantityCount)
        {
            Assert.AreEqual(expectedQuantityCount, GetMyOrdersPageQuantityLabelTextParsedToInteger());
        }
    }
}
