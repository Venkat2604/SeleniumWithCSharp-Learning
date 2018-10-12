using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.com.test.OrangeHrm
{
    class HeadLessBrowserTest
    {
        private IWebDriver driver;
        [SetUp]
        public void setUp()
        {
            ChromeOptions op = new ChromeOptions();
            op.AddArguments("Headless");
            op.AddArguments("Window-size=1400,800");
            
            driver = new ChromeDriver(op);

            driver.Manage().Cookies.DeleteAllCookies();
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
            IWebElement userName=driver.FindElement(By.XPath("//input[@id='txtUsername']"));
            userName.Clear();
            userName.SendKeys("admin");

            IWebElement password=driver.FindElement(By.XPath("//input[@id='txtPassword']"));
            password.Clear();
            password.SendKeys("admin123");

            IWebElement logInButton = driver.FindElement(By.Id("btnLogin"));
            logInButton.Click();
        }
    }
}
