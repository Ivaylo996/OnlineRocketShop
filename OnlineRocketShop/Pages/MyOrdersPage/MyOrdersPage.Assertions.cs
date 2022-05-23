using System;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace OnlineRocketShop.Pages.MyOrdersPage
{
    public partial class MyOrdersPage
    {
        public void AssertOrdersShownInMyAccount(string expectedOrderLabel)
        {
            Assert.AreEqual(expectedOrderLabel, OrderLink.Text.Trim());
        }

        public void AssertQuantityUpdatedByNumber(int expectedQuantityCount)
        {
            var actualQuantityCount = Int32.Parse(Regex.Replace(CurrentOrderProductQuantityLabel.Text, @"[^\d]+", "").Trim());

            Assert.AreEqual(expectedQuantityCount, actualQuantityCount);
        }
    }
}
