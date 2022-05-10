using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRocketShop.Pages.MyOrdersPage
{
    public partial class MyOrdersPage
    {
        public void AssertionOrdersShownInMyAccount()
        {
            Assert.AreEqual(expectedOrder, OrderLink.Text.Trim());
        }

        public void AssertionQuantityIncreasedInOrdersPage(int expectedQuantityCount)
        {
            Assert.AreEqual(expectedQuantityCount, ParseOrdersQuantityLabelToString());
        }
    }
}
