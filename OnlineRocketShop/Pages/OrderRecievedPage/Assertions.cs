using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRocketShop.Pages.OrderRecievedPage
{
    public partial class OrderRecievedPage
    {
        public void AssertionOrderRecieved(string expectedEmail)
        {
            Assert.AreEqual(expectedEmail, OrderRecievedEmailLabel.Text.Trim());
        }
    }
}
