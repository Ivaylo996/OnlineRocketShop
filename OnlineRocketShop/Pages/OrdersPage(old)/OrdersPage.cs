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
        private string path;
        public List<string> actualOrdersList = new();
        public List<string> expectedOrdersList = new();
        public int ordersCounter;

        public OrdersPage(IWebDriver _driver) : base(_driver)
        {
        }

        protected override string Url => "https://demos.bellatrix.solutions/my-account/orders/";
        public string Path
        {
            get
            {
                return path;
            }
        }

        public void AddOrderNumberToList()
        {
            int numOfIterations = 0;

            bool isNextButtonDisplayed = true;

            do
            {
                if (numOfIterations > 0)
                {
                    ScrollToElement(NextButton);
                    NextButton.Click();
                }

                numOfIterations = Driver.FindElements(By.XPath("//tbody//tr")).Count;

                for (int i = 1; i <= numOfIterations; i++)
                {
                    actualOrdersList.Add(OrdersMyAccountLink(i).Text);
                }

                try
                {
                    bool checkIfDisplayed = NextButton.Displayed;
                }
                catch
                {
                    isNextButtonDisplayed = false;
                }
            }
            while (isNextButtonDisplayed);
        }

        public void CompareListAndListFromFIle(string firstName)
        {
            ReadFileToList(firstName);
            CompareLists();
        }

        public void ReadFileToList(string firstName)
        {
            string path = $@"orders{firstName}.txt";

            expectedOrdersList.AddRange(File.ReadAllText(path).Trim().Split(Environment.NewLine).ToList());
        }

        public void AddOrderNumberToFile(string firstName)
        {
            path = $@"orders{firstName}.txt";
            string orderNum = OrderNumber.Text;
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

        private int ParseOrdersQuantityLabelToString()
        {
            return Int32.Parse(Regex.Replace(ProductQuantityOrdersLabel.Text, @"[^\d]+", "").Trim());
        }
    }
}
