using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Practice.com.test
{
    class ElevateStaticPageTest
    {
        IWebDriver driver;
        
        [SetUp]
        public void browserSetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().PageLoad=TimeSpan.FromSeconds(40);

            driver.Navigate().GoToUrl("https://www.elevate.com/");

           
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30); 

            
               }

        [Test]//[Ignore("mouseOverAboutUSTest")]
        public void mouseOverAboutUSTest()
        {
            IWebElement aboutus=driver.FindElement(By.XPath("//a[@class='company']"));

            Actions action = new Actions(driver);
            action.MoveToElement(aboutus).Build().Perform();
            Thread.Sleep(3000);
            //click on our core belief
            driver.FindElement(By.XPath("//div[@id='menuitem-core-beliefs']")).Click();
        }

        [Test]
        public void productPageTest()
        {
            IWebElement product = driver.FindElement(By.LinkText("Our Products"));

            Actions action = new Actions(driver);
            action.MoveToElement(product).Build().Perform();
            Thread.Sleep(3000);
            //click on our core belief
            driver.FindElement(By.XPath("//div[@id='menuitem-analytics']")).Click();
        }

        [TearDown]
        public void tearDown()
        {
            driver.Quit();
        }
    }
}
