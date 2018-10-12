using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.com.test.freecrm
{
    class LogInTest
    {
        IWebDriver driver;
        [SetUp]
        public void setUp()
        {
            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            driver.Navigate().GoToUrl("https://www.freecrm.com/index.html");
        }
        [TearDown]
        public void tearDown()
        {
            driver.Quit();
        }
        [Test]
        public void logInCrmTest()
        {
            IWebElement username = driver.FindElement(By.XPath("//input[@name='username']"));
            username.Clear();
            username.SendKeys("naveenk");

            IWebElement password = driver.FindElement(By.Name("password"));
            password.Clear();
            password.SendKeys("test@123");

            IWebElement loginButton = driver.FindElement(By.XPath("//input[@value='Login' and @type='submit']"));
            loginButton.Click();

            driver.SwitchTo().Frame("mainpanel");
            Assert.AreEqual("CRMPRO" , driver.FindElement(By.XPath("//td[@class='logo_text']")).Text , "The LogIn Test is failed as the Login isn't successful");

        }
    }
}
