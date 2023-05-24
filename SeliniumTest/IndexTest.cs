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
    public class IndexTest
    {
        private static readonly string DriverDirectory = "C:\\webDrivers";

        private static IWebDriver _driver;

        string url = "file:///C:/Users/annso/OneDrive/Dokumenter/KnockKnock-main/index.html";

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
        public void IndexTest1() //Tester om man kan skrive i felterne og klikke login knappen
        {
            string url = "file:///C:/Users/annso/KnockKnock/KnockKnock-main/index.html"; //Local

            _driver.Navigate().GoToUrl(url);

            IWebElement inputTextToEncode = _driver.FindElement(By.Id("input-text"));
            inputTextToEncode.SendKeys("82483843"); //ACT

            IWebElement inputStudentName = _driver.FindElement(By.Id("input-student-name"));
            inputStudentName.SendKeys("Bailey Madsen"); //ACT

            IWebElement inputAdress = _driver.FindElement(By.Id("input-address"));
            inputAdress.SendKeys("Skovvang 30"); //ACT

            IWebElement inputEmailElement = _driver.FindElement(By.Id("input-email"));
            inputEmailElement.SendKeys("test@live.dk"); //ACT

            IWebElement inputPasswordElement = _driver.FindElement(By.Id("input-password"));
            inputPasswordElement.SendKeys("1234"); //ACT

            IWebElement submitButtonElement = _driver.FindElement(By.Id("submitButton"));
            submitButtonElement.Click();


        }

    }
}
