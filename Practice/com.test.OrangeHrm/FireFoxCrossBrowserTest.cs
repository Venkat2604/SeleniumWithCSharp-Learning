using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.com.test.OrangeHrm
{
    class FireFoxCrossBrowserTest
    {
        private IWebDriver driver;
        [SetUp]
        public void setUp()
        {
          
            driver = new FirefoxDriver();

            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(40);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
        }
        [TearDown]
        public void tearDown()
        {
            driver.Quit();
        }
        [Test]
        public void logInTest1()
        {
            IWebElement userName = driver.FindElement(By.XPath("//input[@id='txtUsername']"));
            userName.Clear();
            userName.SendKeys("admin");

            IWebElement password = driver.FindElement(By.XPath("//input[@id='txtPassword']"));
            password.Clear();
            password.SendKeys("admin123");

            IWebElement logInButton = driver.FindElement(By.Id("btnLogin"));
            logInButton.Click();
        }
    }
}
