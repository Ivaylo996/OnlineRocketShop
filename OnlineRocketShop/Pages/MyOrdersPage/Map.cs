using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRocketShop.Pages.MyOrdersPage
{
    public partial class MyOrdersPage
    {
        public IWebElement ProductQuantityOrdersLabel => WaitAndFindElement(By.XPath("//strong[@class='product-quantity']"));
        public IWebElement OrderLink => WaitAndFindElement(By.XPath($"//tr[1]//*[contains(@href,'view-order/') and not(contains(@class,'button'))]"));
    }
}
