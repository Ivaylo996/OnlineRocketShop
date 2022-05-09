﻿using NUnit.Framework;

namespace OnlineRocketShop.Pages.OrdersPage
{
    public partial class OrdersPage
    {
        public void AssertionOrdersListCount()
        {
            Assert.AreEqual(ordersCounter, actualOrdersList.Count);
        }

        public void AssertionQuantityIncreasedInOrdersPage_When_IncreasesQuantityByThree()
        {
            Assert.AreEqual(3, ParseOrdersQuantityLabelToString());
        }
    }
}
