using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.com.test.CSharpFunc
{
    class MouseMovee
    {
        IWebDriver driver;

        [SetUp]
        public void setUP()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com");
        }
        [Test]
        public void googleLaunchTest()
        {
            Console.WriteLine("Running through NUnit...");

            driver.FindElement(By.Name("q")).SendKeys("SQS India");
            driver.FindElement(By.Name("btnK")).Submit();

            Actions action = new Actions(driver);

            action.ContextClick();
          // action.SendKeys(Keys.ArrowDown).SendKeys(Keys.ArrowDown);
        }
    }
}
