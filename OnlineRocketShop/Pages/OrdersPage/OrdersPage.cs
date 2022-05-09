using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;


namespace OnlineRocketShop.Pages.OrdersPage
{
    public partial class OrdersPage : WebPage
    {
        public OrdersPage(IWebDriver _driver) : base(_driver)
        {
        }

        protected override string Url => throw new NotImplementedException();
        public string path;
        public List<string> actualOrdersList = new();
        public List<string> expectedOrdersList = new();
        public int ordersCounter; 

        public void AddOrderNumberToList(string firstName)
        {
            int numOfIterations = 0;

            bool isNextButtonDisplayed = true;

            do
            {
                if (numOfIterations > 0)
                {
                    try
                    {
                        ScrollToElement(NextButton);
                        NextButton.Click();
                    }
                    catch
                    {
                        throw new Exception("No More Pages");
                    }
                }

                numOfIterations = Driver.FindElements(By.XPath("//tbody//tr")).Count;

                for (int i = 1; i <= numOfIterations; i++)
                {
                    string str = OrdersMyAccountLink(i).Text;
                    actualOrdersList.Add(OrdersMyAccountLink(i).Text);
                }
                
                try
                {
                    bool checkIfDisplayed = Driver.FindElement(By.XPath("//a[contains(@class,'woocommerce-Button--next button')]")).Displayed;
                }
                catch
                {
                    isNextButtonDisplayed = false;
                }
            }
            while (isNextButtonDisplayed);

            ReadFileToList(firstName);
            CompareLists();
        }

        public void ReadFileToList(string firstName)
        {
            string path = $@"C:\Users\ivayl\source\repos\OnlineRocketShop\OnlineRocketShop\bin\Debug\net6.0\orders{firstName}.txt";

            expectedOrdersList.AddRange(File.ReadAllText(path).Trim().Split(Environment.NewLine).ToList());
        }

        public void AddOrderNumberToFile(string firstName)
        {
            path = $@"C:\Users\ivayl\source\repos\OnlineRocketShop\OnlineRocketShop\bin\Debug\net6.0\orders{firstName}.txt";
            string orderNum = orderNumber.Text;
            WriteTextToFile(path, orderNum);
        }

        public void WriteTextToFile(string path, string input)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.Write("#" + input + Environment.NewLine);
            }
        }

        public void CompareLists()
        {
            foreach (var actualItem in actualOrdersList)
            {
                if (expectedOrdersList.Contains(actualItem))
                {
                    ordersCounter++;
                }
            }
        }

        public int ParseOrdersQuantityLabelToString()
        {
            return Int32.Parse(Regex.Replace(ProductQuantityOrdersLabel.Text, @"[^\d]+", "").Trim());
        }
    }
}
