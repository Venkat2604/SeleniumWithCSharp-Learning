using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Practice.com.test
{
    class phantomDriverTest
    {
        IWebDriver driver;
        

        [SetUp]
        public void setUP()
        {
            //driver = new PhantomJSDriver ();
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com");
        }
        [Test]
        public void googleLaunchTest()
        {
            Console.WriteLine("Running through NUnit...");

            driver.FindElement(By.Name("q")).SendKeys("SQS India");
            driver.FindElement(By.Name("btnK")).Submit();
            driver.Close();
        }
        [Test]
        public void titleTest()
        {
            Console.WriteLine("Title: " + driver.Title);

            Assert.AreEqual("Google", driver.Title, "Title Does not Match");
        }
        [TearDown]
        public void tearDown()
        {
            driver.Quit();
        }
    }
}
