using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using static System.Net.WebRequestMethods;

namespace SeliniumTest
{
    [TestClass]
    public class DisplayArrivalsTest
    {
        private static readonly string DriverDirectory = "C:\\webDrivers";

        private static IWebDriver _driver;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            //_driver = new ChromeDriver(DriverDirectory); // fast
            //_driver = new FirefoxDriver(DriverDirectory);
            _driver = new EdgeDriver(DriverDirectory); //  fast
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }

        [TestMethod]
        public void DisplayArivalsTest1()
        {
            string url = "file:///C:/Users/annso/KnockKnock/KnockKnock-main/displayArrivals.html";

            //Tjekker titel
            _driver.Navigate().GoToUrl(url);
            Assert.AreEqual("Arrival List", _driver.Title);

            //Tjekker om studerende vises i liste - Testen fejler hvis listen er tom
            IWebElement GetAllButtonShowsStudents = _driver.FindElement(By.Id("getAllButton"));
            GetAllButtonShowsStudents.Click();
            Thread.Sleep(5000);
            IWebElement showElement = _driver.FindElement(By.Id("arrivalsStudent"));
            string student = showElement.Text;
            Assert.AreEqual("1 12345678 23/05 08:25 Bo", student);
            
        }

        [TestMethod]
        public void DisplayDeparturesTest1()
        {
            string url = "file:///C:/Users/annso/KnockKnock/KnockKnock-main/displayArrivals.html";

            //Tjekker titel
            _driver.Navigate().GoToUrl(url);
            Assert.AreEqual("Arrival List", _driver.Title);

            //Tjekker om studerende vises i liste - Testen fejler hvis listen er tom
            IWebElement GetAllButtonShowsStudents = _driver.FindElement(By.Id("getAllDeparturesButton"));
            GetAllButtonShowsStudents.Click();
            Thread.Sleep(5000);
            IWebElement showElement = _driver.FindElement(By.Id("departuresStudent"));
            string student = showElement.Text;
            Assert.AreEqual("1 22334455 23/05 11:35 Mary", student);

      
        }

        [TestMethod]
        public void ArrivalsTitleTest1()
        {
            string url = "file:///C:/Users/annso/KnockKnock/KnockKnock-main/displayArrivals.html";
 
            _driver.Navigate().GoToUrl(url);

            Assert.AreEqual("Arrival List", _driver.Title);
        }
    }
}
    
