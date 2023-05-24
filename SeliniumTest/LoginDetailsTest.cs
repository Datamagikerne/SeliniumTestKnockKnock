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
    public class LoginDetailsTest
    {
        private static readonly string DriverDirectory = "C:\\webDrivers";

        private static IWebDriver _driver;

        string url = "file:///C:/Users/annso/OneDrive/Dokumenter/KnockKnock-main/LoginPage.html";

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
        public void LoginDetailsTest1() //Tester om man kan skrive i feltet og klikke login knappen
        {
            string url = "file:///C:/Users/annso/KnockKnock/KnockKnock-main/LoginPage.html"; //Local

            _driver.Navigate().GoToUrl(url);

            IWebElement inputEmailElement = _driver.FindElement(By.Id("email"));
            inputEmailElement.SendKeys("knap@live.dk"); //ACT

            IWebElement inputPasswordElement = _driver.FindElement(By.Id("password"));
            inputPasswordElement.SendKeys("1234"); //ACT

            IWebElement loginButtonElement = _driver.FindElement(By.Id("loginButton"));
            loginButtonElement.Click();
        }

        [TestMethod]
        public void LoginDetailsTest2()
        {
            string url = "file:///C:/Users/annso/KnockKnock/KnockKnock-main/LoginPage.html";


            //string url = "http://127.0.0.1:5500/index.html";

            _driver.Navigate().GoToUrl(url);

            Assert.AreEqual("Login Form", _driver.Title);
        }
    }
}
    
