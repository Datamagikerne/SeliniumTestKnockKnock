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
            string url = "file:///C:/Users/annso/OneDrive/Dokumenter/KnockKnock-main/displayArrivals.html";
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
            Assert.AreEqual("1 23232323 2023-05-11T13:26:05.377 Lasse", student);
            
        }

        [TestMethod]
        public void DisplayArivalsTest2()
        {
            string url = "file:///C:/Users/annso/OneDrive/Dokumenter/KnockKnock-main/displayArrivals.html";
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
            string url = "file:///C:/Users/annso/OneDrive/Dokumenter/KnockKnock-main/LoginPage.html";
            //string url = "http://127.0.0.1:5500/index.html";
 
            _driver.Navigate().GoToUrl(url);

            Assert.AreEqual("Login Form", _driver.Title);

            /*IWebElement inputElement = _driver.FindElement(By.Id("enterAWord"));
            inputElement.SendKeys("Banana"); //ACT

            IWebElement saveButtonElement = _driver.FindElement(By.Id("saveThisWord"));
            saveButtonElement.Click();

            IWebElement showButtonElement = _driver.FindElement(By.Id("showThisWord"));
            showButtonElement.Click();

            IWebElement outputElement = _driver.FindElement(By.Id("message"));
            string text = outputElement.Text;

            Assert.AreEqual("Your word is: Banana", text); */
        }
    }
}
    
