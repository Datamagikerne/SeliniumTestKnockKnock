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
    public class UnitTest1
    {
        private static readonly string DriverDirectory = "C:\\webDrivers";

        private static IWebDriver _driver;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            //Her vælger man hvilken driver man har I sinde at bruge. I dette eksempel er FireFox brugt. 
            //FireFox er den langsommeste, så her har man mulighed for at se hvad der sker. Men det går stadig meget stærkt!
            //_driver = new ChromeDriver(DriverDirectory); // fast
            //_driver = new FirefoxDriver(DriverDirectory);
            _driver = new EdgeDriver(DriverDirectory); //  fast
            // Driver file must be renamed to MicrosoftWebDriver.exe OR msedgedriver.exe
            // depending on the version of Selenium?
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }

        [TestMethod]
        public void TestMethod1()
        {
            string url = "file:///C:/Users/annso/OneDrive/Dokumenter/KnockKnock-main/displayArrivals.html";
            //string url = "http://127.0.0.1:5500/index.html";

            //Tjekker titel
            _driver.Navigate().GoToUrl(url);
            Assert.AreEqual("Arrival List", _driver.Title);

            //Tjekker om studerende vises i liste - Fejler hvis listen er tom
            IWebElement GetAllButtonShowsStudents = _driver.FindElement(By.Id("getAllButton"));
            GetAllButtonShowsStudents.Click();
            Thread.Sleep(5000);
            IWebElement showElement = _driver.FindElement(By.Id("arrivalsStudent"));
            string student = showElement.Text;
            Assert.AreEqual("1 23232323 2023-05-11T13:26:05.377 Lasse", student);
            
        }

        [TestMethod]
        public void TestMethod2()
        {
            string url = "file:///C:/Users/annso/OneDrive/Dokumenter/KnockKnock-main/displayArrivals.html";
            //string url = "http://127.0.0.1:5500/index.html";

            _driver.Navigate().GoToUrl(url);

            //Tjekker om besked kommer frem hvis listen er tom - Fejler hvis listen ikke er tom
            IWebElement GetAllButtonNoStudents = _driver.FindElement(By.Id("getAllButton"));
            GetAllButtonNoStudents.Click();
            Thread.Sleep(5000);
            IWebElement showNoStudents = _driver.FindElement(By.Id("arrivalsStudent"));
            string noStudentsMessage = showNoStudents.Text;
            Assert.AreEqual("No Students", noStudentsMessage);
        }
    }
}
    
