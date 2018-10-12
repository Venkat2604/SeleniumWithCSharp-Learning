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

namespace Practice.com.test.CSharpFunc
{
   
    class DragAndDropTest
    {
        private IWebDriver driver;

        [SetUp]
        public void setUp()
        {
            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }
        [TearDown]
        public void tearDown()
        {
            driver.Quit();
        }

        [Test]
        public void dragDropTest()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/drag_and_drop");
            IWebElement srcEle=driver.FindElement(By.XPath("//div[@id='column-a']"));
            IWebElement destEle = driver.FindElement(By.XPath("//div[@id='column-b']"));

            Actions action = new Actions(driver);
            //action.ClickAndHold(srcEle).MoveToElement(destEle).Release().Build().Perform();

            action.DragAndDrop(destEle, srcEle).Build().Perform();
                 

        }

        //
        [Test]
        public void jsAlertTest()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");
            driver.FindElement(By.XPath("//div[@id='content']/div/ul/li[3]/button")).Click();

            IAlert alert = driver.SwitchTo().Alert();
            alert.SendKeys("Hello ! DS. Click to Ok or cancle");
            Thread.Sleep(3000);
            
            alert.Accept();
            
        }
    }
}
