using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Practice.com.generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.com.test
{
    class MercuryLogInTest : Base
    {
        IWebDriver driver;

        [SetUp]
        public void setUp()
        {
            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            driver.Navigate().GoToUrl("http://newtours.demoaut.com/");
        }
         [TearDown]
         public void tearDown()
        {
            driver.Quit();
        }
         [Test]
         public void logInTest()
        {
            IWebElement userName=driver.FindElement(By.XPath("//input[@name='userName']"));
            userName.Clear();
            userName.SendKeys("dheerendras06@gmail.com");

            IWebElement password = driver.FindElement(By.XPath("//input[@name='password']"));
            password.Clear();
            password.SendKeys("test@123");

            IWebElement signInButton = driver.FindElement(By.XPath("//input[@value='Login']"));
            signInButton.Click();
        }

        [Test]
        public void reservationTest()
        {
            logInTest();
            IWebElement roundTripRadioButton = driver.FindElement(By.XPath("//input[@value='roundtrip' and @name='tripType']"));
            //roundTripRadioButton.Click();
            IWebElement onewayRadioButton = driver.FindElement(By.XPath("//input[@value='oneway' and @name='tripType']"));
            onewayRadioButton.Click();

            IWebElement noOfPassenger = driver.FindElement(By.XPath("//select[@name='passCount']"));

            SelectElement select = new SelectElement(noOfPassenger);
            select.SelectByValue("2");

            SelectElement departureFrom = new SelectElement(driver.FindElement(By.Name("fromPort")));
            departureFrom.SelectByValue("New York");

            SelectElement fromMonth = new SelectElement(driver.FindElement(By.Name("fromMonth")));
            fromMonth.SelectByValue("10");

            SelectElement fromDay = new SelectElement(driver.FindElement(By.Name("fromDay")));
            fromDay.SelectByValue("5");


            SelectElement destinationTo = new SelectElement(driver.FindElement(By.Name("toPort")));
            destinationTo.SelectByValue("Seattle");

            SelectElement toMonth = new SelectElement(driver.FindElement(By.Name("toMonth")));
            toMonth.SelectByValue("10");

            SelectElement toDay = new SelectElement(driver.FindElement(By.Name("toDay")));
            toDay.SelectByValue("10");

            
            IWebElement firstClassService = driver.FindElement(By.XPath("//input[@value='First' and @name='servClass']"));
            firstClassService.Click();
            IWebElement businessClassService = driver.FindElement(By.XPath("//input[@value='Business' and @name='servClass']"));
            //businessClassService.Click();

            IWebElement economyClassService = driver.FindElement(By.XPath("//input[@value='Coach' and @name='servClass']"));
            //economyClassService.Click();


            IWebElement contibuwButton = driver.FindElement(By.XPath("//input[@name='findFlights']"));
            contibuwButton.Click();

        }
    }
}
