using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ChromeDriver chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl("http://localhost:44186/");

            Thread.Sleep(240000);

            IWebElement button = chrome.FindElementsByClassName("element")[0];
            button.Click();

            Thread.Sleep(180000);

            IWebElement bigHeader = chrome.FindElementById("bigHeader");
            Assert.AreEqual(bigHeader.Text, "Группы");
        }
    }
}
