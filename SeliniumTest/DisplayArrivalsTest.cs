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
        public void DisplayArivalsTest1()
        {
            string url = "file:///C:/Users/annso/KnockKnock/KnockKnock-main/displayArrivals.html";
            //string url = "http://127.0.0.1:5500/index.html";

            //Tjekker titel
            _driver.Navigate().GoToUrl(url);
            Assert.AreEqual("Arrival List", _driver.Title);

            //Tjekker om studerende vises i liste - Testen fejler hvis listen er tom
            IWebElement GetAllButtonShowsStudents = _driver.FindElement(By.Id("getAllButton"));
            GetAllButtonShowsStudents.Click();
            Thread.Sleep(5000);
            IWebElement showElement = _driver.FindElement(By.Id("arrivalsStudent"));
            string student = showElement.Text;
            Assert.AreEqual("1 12345678 2023-05-23T08:25:43.691Z Bo", student);
            
        }

        [TestMethod]
        public void DisplayArivalsTest2()
        {
            string url = "file:///C:/Users/annso/KnockKnock/KnockKnock-main/displayArrivals.html";
            //string url = "http://127.0.0.1:5500/index.html";

            _driver.Navigate().GoToUrl(url);

            //Tjekker om besked kommer frem hvis listen er tom - Testen fejler hvis listen ikke er tom
            IWebElement GetAllButton = _driver.FindElement(By.Id("getAllButton"));
            GetAllButton.Click();
            Thread.Sleep(1000);
            IWebElement outputElement = _driver.FindElement(By.Id("noStudentMessage"));
            string text = outputElement.Text;
            
            Assert.AreEqual("No Students", text);

        }

        [TestMethod]
        public void LoginDetailsTest1()
        {
            string url = "file:///C:/Users/annso/KnockKnock/KnockKnock-main/displayArrivals.html";
            //string url = "http://127.0.0.1:5500/index.html";
 
            _driver.Navigate().GoToUrl(url);

            Assert.AreEqual("Login Form", _driver.Title);

        
        }
    }
}
    
