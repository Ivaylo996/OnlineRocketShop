﻿using NUnit.Framework;

namespace OnlineRocketShop.Pages.OrderRecievedPage
{
    public partial class OrderRecievedPage
    {
        public void AssertOrderRecieved(string expectedEmail)
        {
            Assert.AreEqual(expectedEmail, EmailLabel.Text);
        }
    }
}
