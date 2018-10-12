using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.com.test.CSharpFunc
{
    class FileUploadTest
    {
        IWebDriver driver;
        [SetUp]
        public void setUp()
        {
            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);            
        }
        [TearDown]
        public void tearDown()
        {
            driver.Quit();
        }

        [Test]
        public void fileUploadTest1()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/upload");

            IWebElement chooseFile=driver.FindElement(By.XPath("//input[@id='file-upload']"));
            chooseFile.SendKeys("C:\\Users\\6867\\Downloads\\logo.png");

            IWebElement uploadButton = driver.FindElement(By.XPath("//input[@id='file-submit']"));
            uploadButton.Submit();

            //driver.FindElement(By.XPath("//div[@class='example']//h3")).Text;
            Assert.AreEqual(driver.FindElement(By.XPath("//div[@class='example']//h3")).Text, "File Uploaded!");

        }

        [Test]
        public void downloadFileTest()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/download");
            driver.FindElement(By.LinkText("logo.png")).Click();
        }
        
    }
}
