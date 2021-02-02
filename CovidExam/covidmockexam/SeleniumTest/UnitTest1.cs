using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumWork
{
    [TestClass]
    public class UnitTest1
    {
        const string URL = "http://localhost:3000/";

        IWebDriver driver = new ChromeDriver();

        [TestInitialize]
        public void TestSetUp()
        {
            driver.Navigate().GoToUrl(URL);
        }

        [TestMethod]
        public void TestMethodGetAll()
        {
            Thread.Sleep(1000);

            IWebElement cityInputElement = driver.FindElement(By.Id("CityInput"));
            Thread.Sleep(1000);

            IWebElement getAllButton = driver.FindElement(By.Id("GetByCity"));
            Thread.Sleep(1000);

            IWebElement resultElement = driver.FindElement(By.Id("cityResult"));
            Thread.Sleep(1000);


            cityInputElement.Clear();
            Thread.Sleep(1000);

            cityInputElement.SendKeys("Roskilde");
            Thread.Sleep(1000);

            getAllButton.Click();

            Thread.Sleep(1000);

            var result = resultElement.Text;

            Assert.IsTrue(result.Contains("Roskilde"));
            Thread.Sleep(3000);
        }


        [TestCleanup]
        public void TestTearDown()
        {
            driver.Quit();
        }
    }
}
